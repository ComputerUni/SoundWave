using Microsoft.AspNetCore.Identity;
using SoundWave.DTO.AuthDtos;

namespace SoundWave.Business.Services.Abstract
{
    public interface IAuthService
    {
        Task<IdentityResult> Register(RegisterDto dto);
        Task<string> Login(LoginDto dto);
    }
}
