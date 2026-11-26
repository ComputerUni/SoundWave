using Microsoft.EntityFrameworkCore;
using SoundWave.DataAccess.Context;
using SoundWave.DataAccess.Repositories.GenericRepositories;
using SoundWave.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SoundWave.DataAccess.Repositories.Albums
{
    public class AlbumRepository : GenericRepository<Album>, IAlbumRepository
    {
        public AlbumRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<List<Album>> GetAlbumAllAsync()
        {
            return await _context.Albums.AsNoTracking().Include(x => x.Artist).ToListAsync();
        }

        public async Task<Album> GetAlbumWithDetailsAsync(int id)
        {
            return await _context.Albums.AsNoTracking().Include(x => x.Songs).Include(x => x.Artist).FirstOrDefaultAsync(x => x.Id == id && !x.IsDeleted);
        }
    }
}
