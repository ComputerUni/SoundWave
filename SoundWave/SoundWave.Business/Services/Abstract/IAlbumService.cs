using SoundWave.DTO.AlbumDtos;
using SoundWave.DTO.ArtistDtos;

namespace SoundWave.Business.Services.Abstract
{
    public interface IAlbumService
    {
        Task<List<ResultAlbumDto>> GetAllAsync();
        Task<AlbumWithSongsDto> GetAlbumWithDetailsAsync(int id);
    }
}
