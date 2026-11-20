using Microsoft.EntityFrameworkCore;
using SoundWave.DataAccess.Context;
using SoundWave.DataAccess.Repositories.GenericRepositories;
using SoundWave.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SoundWave.DataAccess.Repositories.Songs
{
    public class SongRepository : GenericRepository<Song>, ISongRepository
    {
        public SongRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<List<Song>> GetAllWithDetailsAsync()
        {
            return await _context.Songs.Include(s => s.Album).ThenInclude(a => a.Artist).Where(a => !a.IsDeleted).ToListAsync();
        }

        public async Task<Song> GetByIdWithDetailsAsync(int id)
        {
            return await _context.Songs.Include(s => s.Album).ThenInclude(a => a.Artist).FirstOrDefaultAsync(a => a.Id == id && !a.IsDeleted);
        }
    }
}
