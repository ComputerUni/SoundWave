using SoundWave.Entity.Common;
using SoundWave.Entity.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace SoundWave.Entity.Entities
{
    public class Song : BaseEntity
    {
        public string Title { get; set; }
        public TimeSpan Duration { get; set; }
        public string AudioUrl { get; set; }
        public int PlayCount { get; set; }
        public SubscriptionLevel SubscriptionLevel { get; set; }
        public int AlbumId { get; set; }
        public Album Album { get; set; }
        public List<PlaylistSong> PlaylistSongs { get; set; }
    }
}
