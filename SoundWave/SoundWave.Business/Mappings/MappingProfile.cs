using AutoMapper;
using SoundWave.DTO.AlbumDtos;
using SoundWave.DTO.ArtistDtos;
using SoundWave.DTO.SongDtos;
using SoundWave.Entity.Entities;

namespace SoundWave.Business.Mappings
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<Song, ResultSongDto>();
            CreateMap<Artist, ResultArtistDto>();
            CreateMap<Album, ResultAlbumDto>();
        }
    }
}
