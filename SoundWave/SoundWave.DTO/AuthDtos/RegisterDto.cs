using SoundWave.Entity.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace SoundWave.DTO.AuthDtos
{
    public class RegisterDto
    {
        public string FullName { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
    }
}
