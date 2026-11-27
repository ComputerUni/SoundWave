using SoundWave.DTO.UserDtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace SoundWave.Business.Services.Abstract
{
    public interface IUserService
    {
        Task<List<ResultUserDto>> GetAllUsersAsync();
        Task<AssignPackageDto> GetUserForPackageUpdateAsync(int id);
        Task<bool> UpdateUserPackageAsync(AssignPackageDto dto);
        Task<bool> ToggleUserLockoutAsync(int id);
        Task<bool> DeleteUserAsync(int id);
    }
}
