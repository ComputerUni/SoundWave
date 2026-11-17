using System;
using System.Collections.Generic;
using System.Text;

namespace SoundWave.Entity.Common
{
    public class BaseEntity
    {
        public int Id { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime CreatedAt { get; set; }
    }
}
