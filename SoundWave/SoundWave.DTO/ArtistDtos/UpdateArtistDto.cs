using System;
using System.Collections.Generic;
using System.Text;

namespace SoundWave.DTO.ArtistDtos
{
    public class UpdateArtistDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string ImageUrl { get; set; }
        public string Bio { get; set; }
    }
}
