using SoundWave.Entity.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace SoundWave.DTO.UserDtos
{
    public class ResultUserDto
    {
        public int Id { get; set; }
        public string FullName { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public DateTime CreatedAt { get; set; }
        public SubscriptionLevel SubscriptionLevel { get; set; }
        public bool IsAdmin { get; set; }
        public bool IsLockedOut { get; set; }
    }
}
