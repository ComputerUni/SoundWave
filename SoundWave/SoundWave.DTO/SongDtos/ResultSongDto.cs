using SoundWave.Entity.Entities;
using SoundWave.Entity.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace SoundWave.DTO.SongDtos
{
    public class ResultSongDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public TimeSpan Duration { get; set; }
        public string AudioUrl { get; set; }
        public int PlayCount { get; set; }
        public SubscriptionLevel SubscriptionLevel { get; set; }
        public int AlbumId { get; set; }
        public string AlbumTitle { get; set; }
        public int ArtistId { get; set; }
        public string ArtistName { get; set; }
        public string AlbumCoverImageUrl { get; set; }
    }
}
