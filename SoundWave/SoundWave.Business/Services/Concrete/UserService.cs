using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using SoundWave.Business.Services.Abstract;
using SoundWave.DTO.UserDtos;
using SoundWave.Entity.Entities;
using SoundWave.Entity.Enums;

namespace SoundWave.Business.Services.Concrete
{
    public class UserService(UserManager<AppUser> _userManager) : IUserService
    {
        public async Task<bool> DeleteUserAsync(int id)
        {
            var user = await _userManager.FindByIdAsync(id.ToString());
            if (user == null) return false;

            if (await _userManager.IsInRoleAsync(user, "Admin")) return false;

            var result = await _userManager.DeleteAsync(user);
            return result.Succeeded;
        }

        public async Task<List<ResultUserDto>> GetAllUsersAsync()
        {
            var users = await _userManager.Users.OrderByDescending(u => u.CreatedAt).ToListAsync();
            var result = new List<ResultUserDto>();
            foreach (var user in users)
            {
                var roles = await _userManager.GetRolesAsync(user);
                var packageRole = roles.FirstOrDefault(r => Enum.TryParse<SubscriptionLevel>(r, out _));
                var package = Enum.TryParse<SubscriptionLevel>(packageRole, out var parsedPackage) ? parsedPackage : SubscriptionLevel.Free;

                result.Add(new ResultUserDto
                {
                    Id = user.Id,
                    FullName = user.FullName,
                    UserName = user.UserName,
                    Email = user.Email,
                    CreatedAt = user.CreatedAt,
                    SubscriptionLevel = package,
                    IsAdmin = roles.Contains("Admin"),
                    IsLockedOut = await _userManager.IsLockedOutAsync(user)
                });
            }

            return result;
        }

        public async Task<AssignPackageDto> GetUserForPackageUpdateAsync(int id)
        {
            var user = await _userManager.FindByIdAsync(id.ToString());
            var role = await _userManager.GetRolesAsync(user);
            var packageRole = role.FirstOrDefault(r => Enum.TryParse<SubscriptionLevel>(r, out _));
            var package = Enum.TryParse<SubscriptionLevel>(packageRole, out var parsedPackage) ? parsedPackage : SubscriptionLevel.Free;

            var result = new AssignPackageDto
            {
                UserId = user.Id,
                FullName = user.FullName,
                Email = user.Email,
                CurrentPackage = package,
                SelectedPackage = package
            };

            return result;
        }

        public async Task<bool> ToggleUserLockoutAsync(int id)
        {
            var user = await _userManager.FindByIdAsync(id.ToString());
            if (user == null) return false;

            if (!user.LockoutEnabled)
            {
                await _userManager.SetLockoutEnabledAsync(user, true);
            }

            var isCurrentlyLockedOut = await _userManager.IsLockedOutAsync(user);
           
            if(isCurrentlyLockedOut)
            {
                await _userManager.SetLockoutEndDateAsync(user, null);
            }
            else
            {
                await _userManager.SetLockoutEndDateAsync(user, DateTimeOffset.MaxValue);
            }
            
            return true;
        }

        public async Task<bool> UpdateUserPackageAsync(AssignPackageDto dto)
        {
            var user = await _userManager.FindByIdAsync(dto.UserId.ToString());
            if (user == null) return false;

            var role = await _userManager.GetRolesAsync(user);
            if (role.Contains("Admin")) return false;

            if(role.Any())
            {
                var removeResult = await _userManager.RemoveFromRolesAsync(user, role);
                if (!removeResult.Succeeded) return false;
            }

            var addResult = await _userManager.AddToRoleAsync(user, dto.SelectedPackage.ToString());
            if (!addResult.Succeeded) return false;

            user.SubscriptionLevel = dto.SelectedPackage;
            await _userManager.UpdateAsync(user);

            return true;

        }
    }
}
