using SoundWave.DTO.ArtistDtos;

namespace SoundWave.Business.Services.Abstract
{
    public interface IArtistService
    {
        Task<List<ResultArtistDto>> GetAllAsync();
    }
}
