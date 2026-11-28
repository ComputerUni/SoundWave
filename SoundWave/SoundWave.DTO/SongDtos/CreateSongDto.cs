using SoundWave.Entity.Enums;

namespace SoundWave.DTO.SongDtos
{
    public class CreateSongDto
    {
        public string Title { get; set; }
        public TimeSpan Duration { get; set; }
        public string AudioUrl { get; set; }
        public int PlayCount { get; set; }
        public SubscriptionLevel SubscriptionLevel { get; set; }
        public int AlbumId { get; set; }
    }
}
