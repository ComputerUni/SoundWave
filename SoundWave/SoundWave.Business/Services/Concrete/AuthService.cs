using Microsoft.AspNetCore.Identity;
using SoundWave.Business.Services.Abstract;
using SoundWave.DTO.AuthDtos;
using SoundWave.Entity.Entities;
using SoundWave.Entity.Enums;

namespace SoundWave.Business.Services.Concrete
{
    public class AuthService : IAuthService
    {
        private readonly UserManager<AppUser> _userManager;
        private readonly ITokenService _tokenService;

        public AuthService(UserManager<AppUser> userManager, ITokenService tokenService)
        {
            _userManager = userManager;
            _tokenService = tokenService;
        }

        public async Task<string> Login(LoginDto dto)
        {
            var user = await _userManager.FindByEmailAsync(dto.UserNameOrEmail);

            if (user is null)
            {
                user = await _userManager.FindByNameAsync(dto.UserNameOrEmail);
            }

            if (user is null)
            {
                return null;
            }

            var passwordCheck = await _userManager.CheckPasswordAsync(user, dto.Password);

            if(!passwordCheck)
            {
                return null;
            }

            var token = await _tokenService.GenerateTokenAsync(user);
            return token;

        }

        public async Task<IdentityResult> Register(RegisterDto dto)
        {
            var newUser = new AppUser
            {
                UserName = dto.UserName,
                Email = dto.Email,
                FullName = dto.FullName,
                CreatedAt = DateTime.UtcNow,
                SubscriptionLevel = SubscriptionLevel.Free
            };

            var result = await _userManager.CreateAsync(newUser, dto.Password);

            if(result.Succeeded)
            {
                await _userManager.AddToRoleAsync(newUser, SubscriptionLevel.Free.ToString());
            }

            return result;
        }
    }
}
