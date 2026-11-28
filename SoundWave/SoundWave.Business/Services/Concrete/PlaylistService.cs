using AutoMapper;
using SoundWave.Business.Services.Abstract;
using SoundWave.DataAccess.Repositories.Playlists;
using SoundWave.DTO.PlaylistDtos;
using SoundWave.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SoundWave.Business.Services.Concrete
{
    public class PlaylistService(IPlaylistRepository _repository, IMapper _mapper) : IPlaylistService
    {
        public async Task<bool> AddSongToPlaylistAsync(int playlistId, int songId)
        {
            var song = await _repository.GetPlaylistSongAsync(playlistId, songId);
            if (song is not null) return false;

            var playlistSong = new PlaylistSong
            {
                PlaylistId = playlistId,
                SongId = songId,
            };

            await _repository.AddPlaylistSongAsync(playlistSong);
            return true;
        }

        public async Task<bool> RemoveSongToPlaylistAsync(int playlistId, int songId)
        {
            var song = await _repository.GetPlaylistSongAsync(playlistId, songId);
            if (song is null) return false;
            await _repository.RemovePlayListSongAsync(song);
            return true;

        }

        public async Task CreatePlaylistAsync(CreatePlaylistDto dto)
        {
            var playlist = _mapper.Map<Playlist>(dto);
            await _repository.CreateAsync(playlist);
        }

        public async Task DeletePlaylistAsync(int id)
        {
            var playlist = await _repository.GetByIdAsync(id);
            await _repository.DeleteAsync(playlist);
        }

        public async Task<List<ResultPlaylistDto>> GetPlaylistsByUserIdAsync(int userId)
        {
            var playlists = await _repository.GetPlaylistsByUserIdAsync(userId);
            return _mapper.Map<List<ResultPlaylistDto>>(playlists);
        }

        public async Task<PlaylistDetailDto> GetPlaylistWithSongsAsync(int playlistId)
        {
            var playlist = await _repository.GetPlaylistWithSongsAsync(playlistId);
            return _mapper.Map<PlaylistDetailDto>(playlist);
        }

        public async Task UpdatePlaylistAsync(UpdatePlaylistDto dto)
        {
            var playlist = await _repository.GetByIdAsync(dto.Id);
            _mapper.Map(dto, playlist);
            await _repository.UpdateAsync(playlist);
        }
    }
}
