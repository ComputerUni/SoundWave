using System;
using System.Collections.Generic;
using System.Text;

namespace SoundWave.DTO.PlaylistDtos
{
    public class CreatePlaylistDto
    {
        public string Name { get; set; }
        public string? Description { get; set; }
        public string? CoverImageUrl { get; set; }
        public int AppUserId { get; set; }
    }
}
