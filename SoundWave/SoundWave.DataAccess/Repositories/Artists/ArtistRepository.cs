using Microsoft.EntityFrameworkCore;
using SoundWave.DataAccess.Context;
using SoundWave.DataAccess.Repositories.GenericRepositories;
using SoundWave.Entity.Entities;

namespace SoundWave.DataAccess.Repositories.Artists
{
    public class ArtistRepository : GenericRepository<Artist>, IArtistRepository
    {
        public ArtistRepository(AppDbContext context) : base(context)
        {
        }

        public async Task<Artist> GetArtistWithDetailsAsync(int id)
        {
            return await _context.Artists.Include(x => x.Albums).ThenInclude(al => al.Songs).FirstOrDefaultAsync(x => x.Id == id && !x.IsDeleted);
        }
    }
}
