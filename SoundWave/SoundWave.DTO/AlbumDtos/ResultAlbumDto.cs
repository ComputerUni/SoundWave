using SoundWave.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SoundWave.DTO.AlbumDtos
{
    public class ResultAlbumDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string CoverImageUrl { get; set; }
        public int ReleaseYear { get; set; }
        public string ArtistName { get; set; }
    }
}
