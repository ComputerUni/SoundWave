using SoundWave.Entity.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace SoundWave.Entity.Entities
{
    public class Playlist : BaseEntity
    {
        public string Name { get; set; }
        public string? Description { get; set; }
        public string? CoverImageUrl { get; set; }
        public int AppUserId { get; set; }
        public AppUser AppUser { get; set; }
        public List<PlaylistSong> PlaylistSongs { get; set; }
    }
}
