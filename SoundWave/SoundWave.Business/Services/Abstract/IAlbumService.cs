using SoundWave.DTO.AlbumDtos;
using SoundWave.DTO.ArtistDtos;

namespace SoundWave.Business.Services.Abstract
{
    public interface IAlbumService
    {
        Task<List<ResultAlbumDto>> GetAllAsync();
        Task CreateAlbumAsync(CreateAlbumDto createAlbumDto);
        Task UpdateAlbumAsync(UpdateAlbumDto updateAlbumDto);
        Task<UpdateAlbumDto> GetAlbumByIdAsync(int id);
        Task DeleteAlbumAsync(int id);
        Task<AlbumWithSongsDto> GetAlbumWithDetailsAsync(int id);
    }
}
