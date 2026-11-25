using SoundWave.DTO.ArtistDtos;

namespace SoundWave.Business.Services.Abstract
{
    public interface IArtistService
    {
        Task<List<ResultArtistDto>> GetAllAsync();
        Task CreateArtistAsync(CreateArtistDto createArtistDto);
        Task UpdateArtistAsync(UpdateArtistDto updateArtistDto);
        Task DeleteArtistAsync(int id);
        Task<ArtistDetailDto> GetArtistWithDetailsAsync(int id);
    }
}
