using AutoMapper;
using SoundWave.Business.Services.Abstract;
using SoundWave.DataAccess.Repositories.Artists;
using SoundWave.DTO.ArtistDtos;
using SoundWave.Entity.Entities;

namespace SoundWave.Business.Services.Concrete
{
    public class ArtistService(IArtistRepository _repository, IMapper _mapper) : IArtistService
    {
        public async Task CreateArtistAsync(CreateArtistDto createArtistDto)
        {
            var artist = _mapper.Map<Artist>(createArtistDto);
            await _repository.CreateAsync(artist);

        }

        public async Task DeleteArtistAsync(int id)
        {
            var artist = await _repository.GetByIdAsync(id);
            await _repository.DeleteAsync(artist);
        }

        public async Task<List<ResultArtistDto>> GetAllAsync()
        {
            var artists = await _repository.GetAllAsync();
            return _mapper.Map<List<ResultArtistDto>>(artists);
        }

        public async Task<ArtistDetailDto> GetArtistWithDetailsAsync(int id)
        {
            var artist = await _repository.GetArtistWithDetailsAsync(id);
            return _mapper.Map<ArtistDetailDto>(artist);
        }

        public async Task UpdateArtistAsync(UpdateArtistDto updateArtistDto)
        {
            var artist = await _repository.GetByIdAsync(updateArtistDto.ArtistId);
            _mapper.Map(updateArtistDto, artist);
            await _repository.UpdateAsync(artist);
        }
    }
}
