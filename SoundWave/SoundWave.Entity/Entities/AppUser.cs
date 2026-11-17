using Microsoft.AspNetCore.Identity;
using SoundWave.Entity.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace SoundWave.Entity.Entities
{
    public class AppUser : IdentityUser<int>
    {
        public string FullName { get; set; }
        public string? ProfileImageUrl { get; set; }
        public DateTime CreatedAt { get; set; }
        public SubscriptionLevel SubscriptionLevel { get; set; }
    }
}
