using SoundWave.Entity.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace SoundWave.DTO.UserDtos
{
    public class AssignPackageDto
    {
        public int UserId { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public SubscriptionLevel CurrentPackage { get; set; }
        public SubscriptionLevel SelectedPackage { get; set; }
    }
}
