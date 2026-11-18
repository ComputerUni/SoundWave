using SoundWave.DTO.AlbumDtos;

namespace SoundWave.Business.Services.Abstract
{
    public interface IAlbumService
    {
        Task<List<ResultAlbumDto>> GetAllAsync();
    }
}
