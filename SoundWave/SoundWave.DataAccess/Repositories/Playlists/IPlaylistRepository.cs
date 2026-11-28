using SoundWave.DataAccess.Repositories.GenericRepositories;
using SoundWave.Entity.Entities;

namespace SoundWave.DataAccess.Repositories.Playlists
{
    public interface IPlaylistRepository : IGenericRepository<Playlist>
    {
        Task<List<Playlist>> GetPlaylistsByUserIdAsync(int userId);
        Task<Playlist?> GetPlaylistWithSongsAsync(int playlistId);
        Task<PlaylistSong?> GetPlaylistSongAsync(int playlistId, int songId);
        Task AddPlaylistSongAsync(PlaylistSong playlistSong);
        Task RemovePlayListSongAsync(PlaylistSong playlistSong);
    }
}
