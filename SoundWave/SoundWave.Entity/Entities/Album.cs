using SoundWave.Entity.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace SoundWave.Entity.Entities
{
    public class Album : BaseEntity
    {
        public string Title { get; set; }
        public string CoverImageUrl { get; set; }
        public int ReleaseYear { get; set; }
        public int ArtistId { get; set; }
        public Artist Artist { get; set; }
        public ICollection<Song> Songs { get; set; }
    }
}
