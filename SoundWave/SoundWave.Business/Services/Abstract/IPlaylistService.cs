using SoundWave.DTO.PlaylistDtos;
using System;
using System.Collections.Generic;
using System.Text;

namespace SoundWave.Business.Services.Abstract
{
    public interface IPlaylistService
    {
        Task<List<ResultPlaylistDto>> GetPlaylistsByUserIdAsync(int userId);
        Task<PlaylistDetailDto> GetPlaylistWithSongsAsync(int playlistId);
        Task CreatePlaylistAsync(CreatePlaylistDto dto);
        Task UpdatePlaylistAsync(UpdatePlaylistDto dto);
        Task DeletePlaylistAsync(int id);
        Task<bool> AddSongToPlaylistAsync(int playlistId, int songId);
        Task<bool> RemoveSongToPlaylistAsync(int playlistId, int songId);
    }
}
