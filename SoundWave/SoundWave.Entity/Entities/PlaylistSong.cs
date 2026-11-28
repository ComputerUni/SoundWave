using SoundWave.Entity.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace SoundWave.Entity.Entities
{
    public class PlaylistSong : BaseEntity
    {
        public int PlaylistId { get; set; }
        public Playlist Playlist { get; set; }
        public int SongId { get; set; }
        public Song Song { get; set; }
    }
}
