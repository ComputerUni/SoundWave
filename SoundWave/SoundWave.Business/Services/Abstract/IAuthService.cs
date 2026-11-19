using Microsoft.AspNetCore.Identity;
using SoundWave.DTO.AuthDtos;
using SoundWave.Entity.Enums;

namespace SoundWave.Business.Services.Abstract
{
    public interface IAuthService
    {
        Task<IdentityResult> Register(RegisterDto dto);
        Task<string> Login(LoginDto dto);
        Task<string> SelectPlanAsync(int userId, SubscriptionLevel level);
    }
}
