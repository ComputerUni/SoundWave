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
            CreateMap<Song, ResultSongDto>()
                .ForMember(dest => dest.ArtistName, opt => opt.MapFrom(src => src.Album.Artist.Name))
                .ForMember(dest => dest.AlbumTitle, opt => opt.MapFrom(src => src.Album.Title))
                .ForMember(dest => dest.ArtistId, opt => opt.MapFrom(src => src.Album.ArtistId))
                .ForMember(dest => dest.AlbumId, opt => opt.MapFrom(src => src.Album.Id))
                .ForMember(dest => dest.AlbumCoverImageUrl, opt => opt.MapFrom(src => src.Album.CoverImageUrl));

            CreateMap<Song, SongDetailDto>()
                .ForMember(dest => dest.ArtistName, opt => opt.MapFrom(src => src.Album.Artist.Name))
                .ForMember(dest => dest.AlbumTitle, opt => opt.MapFrom(src => src.Album.Title))
                .ForMember(dest => dest.ArtistImageUrl, opt => opt.MapFrom(src => src.Album.Artist.ImageUrl))
                .ForMember(dest => dest.AlbumCoverImageUrl, opt => opt.MapFrom(src => src.Album.CoverImageUrl));

            CreateMap<Artist, ResultArtistDto>();
            CreateMap<CreateArtistDto, Artist>();
            CreateMap<Artist, UpdateArtistDto>().ReverseMap();
            CreateMap<Artist, ArtistDetailDto>().ReverseMap();

            CreateMap<Album, ResultAlbumDto>();
            CreateMap<CreateAlbumDto, Album>();
            CreateMap<UpdateAlbumDto, Album>();
            CreateMap<Album, AlbumWithSongsDto>().ReverseMap();
        }
    }
}
