using SoundWave.DTO.SongDtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace SoundWave.DTO.ArtistDtos
{
    public class AlbumWithSongsDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string CoverImageUrl { get; set; }
        public int ReleaseYear { get; set; }
        public List<ResultSongDto> Songs { get; set; }
    }
}
