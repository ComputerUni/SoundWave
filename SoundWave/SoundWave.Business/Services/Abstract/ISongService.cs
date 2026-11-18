using SoundWave.DTO.SongDtos;

namespace SoundWave.Business.Services.Abstract
{
    public interface ISongService
    {
        Task<List<ResultSongDto>> GetAllAsync();
    }
}
