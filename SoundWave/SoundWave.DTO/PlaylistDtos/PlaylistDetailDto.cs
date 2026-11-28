using SoundWave.DTO.SongDtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace SoundWave.DTO.PlaylistDtos
{
    public class PlaylistDetailDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public string? CoverImageUrl { get; set; }
        public List<ResultSongDto> Songs { get; set; }
    }
}
