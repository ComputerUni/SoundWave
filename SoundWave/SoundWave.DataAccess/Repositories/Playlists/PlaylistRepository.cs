using Microsoft.EntityFrameworkCore;
using SoundWave.DataAccess.Context;
using SoundWave.DataAccess.Repositories.GenericRepositories;
using SoundWave.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SoundWave.DataAccess.Repositories.Playlists
{
    public class PlaylistRepository : GenericRepository<Playlist>, IPlaylistRepository
    {
        public PlaylistRepository(AppDbContext context) : base(context)
        {
        }

        public async Task AddPlaylistSongAsync(PlaylistSong playlistSong)
        {
            _context.PlaylistSongs.AddAsync(playlistSong);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Playlist>> GetPlaylistsByUserIdAsync(int userId)
        {
            return await _context.Playlists.Include(x => x.PlaylistSongs).Where(x => x.AppUserId == userId && !x.IsDeleted).OrderByDescending(x => x.Id).ToListAsync();
        }

        public async Task<PlaylistSong?> GetPlaylistSongAsync(int playlistId, int songId)
        {
            return await _context.PlaylistSongs.FirstOrDefaultAsync(x => x.PlaylistId == playlistId && x.SongId == songId);
        }

        public async Task<Playlist?> GetPlaylistWithSongsAsync(int playlistId)
        {
            return await _context.Playlists.Include(x => x.AppUser).Include(x => x.PlaylistSongs).ThenInclude(x => x.Song).ThenInclude(x => x.Album).ThenInclude(x => x.Artist).FirstOrDefaultAsync(x => x.Id == playlistId && !x.IsDeleted);
        }

        public async Task RemovePlayListSongAsync(PlaylistSong playlistSong)
        {
            _context.PlaylistSongs.Remove(playlistSong);
            await _context.SaveChangesAsync();
        }
    }
}
