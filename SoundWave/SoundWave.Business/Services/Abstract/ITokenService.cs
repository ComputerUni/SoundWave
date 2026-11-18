using SoundWave.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SoundWave.Business.Services.Abstract
{
    public interface ITokenService
    {
        Task<string> GenerateTokenAsync(AppUser user);
    }
}
