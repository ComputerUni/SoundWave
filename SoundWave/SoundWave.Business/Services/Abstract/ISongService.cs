using SoundWave.DTO.SongDtos;

namespace SoundWave.Business.Services.Abstract
{
    public interface ISongService
    {
        Task<List<ResultSongDto>> GetAllAsync();
        Task CreateSongAsync(CreateSongDto createSongDto);
        Task UpdateSongAsync(UpdateSongDto updateSongDto);
        Task<UpdateSongDto> GetByIdAsync(int id);
        Task DeleteSongAsync(int id);
        Task<SongDetailDto> GetSongByIdAsync(int id);
    }
}
