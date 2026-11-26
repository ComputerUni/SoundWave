using AutoMapper;
using SoundWave.Business.Services.Abstract;
using SoundWave.DataAccess.Repositories.Albums;
using SoundWave.DTO.AlbumDtos;
using SoundWave.DTO.ArtistDtos;
using SoundWave.Entity.Entities;

namespace SoundWave.Business.Services.Concrete
{
    public class AlbumService(IAlbumRepository _repository, IMapper _mapper) : IAlbumService
    {
        public async Task CreateAlbumAsync(CreateAlbumDto createAlbumDto)
        {
            var album = _mapper.Map<Album>(createAlbumDto);
            await _repository.CreateAsync(album);
        }

        public async Task DeleteAlbumAsync(int id)
        {
            var album = await _repository.GetByIdAsync(id);
            await _repository.DeleteAsync(album);
        }

        public async Task<UpdateAlbumDto> GetAlbumByIdAsync(int id)
        {
            var album = await _repository.GetByIdAsync(id);
            return _mapper.Map<UpdateAlbumDto>(album);
        }

        public async Task<AlbumWithSongsDto> GetAlbumWithDetailsAsync(int id)
        {
            var album = await _repository.GetAlbumWithDetailsAsync(id);
            return _mapper.Map<AlbumWithSongsDto>(album);
        }

        public async Task<List<ResultAlbumDto>> GetAllAsync()
        {
            var albums = await _repository.GetAlbumAllAsync();
            return _mapper.Map<List<ResultAlbumDto>>(albums);
        }

        public async Task UpdateAlbumAsync(UpdateAlbumDto updateAlbumDto)
        {
            var album = await _repository.GetByIdAsync(updateAlbumDto.Id);
            _mapper.Map(updateAlbumDto, album);
            await _repository.UpdateAsync(album);
        }
    }
}
