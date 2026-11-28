using SoundWave.Entity.Common;

namespace SoundWave.Entity.Entities
{
    public class Artist : BaseEntity
    {
        public string Name { get; set; }
        public string ImageUrl { get; set; }
        public string Bio { get; set; }
        public ICollection<Album> Albums { get; set; }
    }
}
