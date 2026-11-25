using AutoMapper;
using SoundWave.Business.Services.Abstract;
using SoundWave.DataAccess.Repositories.Songs;
using SoundWave.DTO.SongDtos;
using SoundWave.Entity.Entities;

namespace SoundWave.Business.Services.Concrete
{
    public class SongService(ISongRepository _repository, IMapper _mapper) : ISongService
    {
        public async Task CreateSongAsync(CreateSongDto createSongDto)
        {
            var song = _mapper.Map<Song>(createSongDto);
            await _repository.CreateAsync(song);
        }

        public async Task DeleteSongAsync(int id)
        {
            var song = await _repository.GetByIdAsync(id);
            await _repository.DeleteAsync(song);
        }

        public async Task<List<ResultSongDto>> GetAllAsync()
        {
            var songs = await _repository.GetAllWithDetailsAsync();
            return _mapper.Map<List<ResultSongDto>>(songs);
        }

        public async Task<UpdateSongDto> GetByIdAsync(int id)
        {
            var song = await _repository.GetByIdAsync(id);
            return _mapper.Map<UpdateSongDto>(song);
        }

        public async Task<SongDetailDto> GetSongByIdAsync(int id)
        {
            var song = await _repository.GetByIdWithDetailsAsync(id);
            return _mapper.Map<SongDetailDto>(song);
        }

        public async Task UpdateSongAsync(UpdateSongDto updateSongDto)
        {
            var song = await _repository.GetByIdAsync(updateSongDto.Id);
            _mapper.Map(updateSongDto, song);
            await _repository.UpdateAsync(song);
        }
    }
}
