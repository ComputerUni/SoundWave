using AutoMapper;
using SoundWave.Business.Services.Abstract;
using SoundWave.DataAccess.Repositories.Albums;
using SoundWave.DTO.AlbumDtos;
using SoundWave.DTO.ArtistDtos;

namespace SoundWave.Business.Services.Concrete
{
    public class AlbumService(IAlbumRepository _repository, IMapper _mapper) : IAlbumService
    {
        public async Task<AlbumWithSongsDto> GetAlbumWithDetailsAsync(int id)
        {
            var album = await _repository.GetAlbumWithDetailsAsync(id);
            return _mapper.Map<AlbumWithSongsDto>(album);
        }

        public async Task<List<ResultAlbumDto>> GetAllAsync()
        {
            var albums = await _repository.GetAllAsync();
            return _mapper.Map<List<ResultAlbumDto>>(albums);
        }
    }
}
