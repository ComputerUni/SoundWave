using AutoMapper;
using SoundWave.Business.Services.Abstract;
using SoundWave.DataAccess.Repositories.Songs;
using SoundWave.DTO.SongDtos;

namespace SoundWave.Business.Services.Concrete
{
    public class SongService(ISongRepository _repository, IMapper _mapper) : ISongService
    {
        public async Task<List<ResultSongDto>> GetAllAsync()
        {
            var songs = await _repository.GetAllAsync();
            return _mapper.Map<List<ResultSongDto>>(songs);
        }
    }
}
