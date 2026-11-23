using SoundWave.DataAccess.Repositories.GenericRepositories;
using SoundWave.Entity.Entities;

namespace SoundWave.DataAccess.Repositories.Artists
{
    public interface IArtistRepository : IGenericRepository<Artist>
    {
        Task<Artist> GetArtistWithDetailsAsync(int id);
    }
}
