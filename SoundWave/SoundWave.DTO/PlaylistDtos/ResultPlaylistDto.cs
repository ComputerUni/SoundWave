using SoundWave.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SoundWave.DTO.PlaylistDtos
{
    public class ResultPlaylistDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string? Description { get; set; }
        public string? CoverImageUrl { get; set; }
        public List<PlaylistSong> PlaylistSongs { get; set; }
    }
}
