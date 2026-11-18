using AutoMapper;
using SoundWave.Business.Services.Abstract;
using SoundWave.DataAccess.Repositories.Artists;
using SoundWave.DTO.ArtistDtos;

namespace SoundWave.Business.Services.Concrete
{
    public class ArtistService(IArtistRepository _repository, IMapper _mapper) : IArtistService
    {
        public async Task<List<ResultArtistDto>> GetAllAsync()
        {
            var artists = await _repository.GetAllAsync();
            return _mapper.Map<List<ResultArtistDto>>(artists);
        }
    }
}
