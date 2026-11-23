using SoundWave.DataAccess.Repositories.GenericRepositories;
using SoundWave.Entity.Entities;

namespace SoundWave.DataAccess.Repositories.Songs
{
    public interface ISongRepository : IGenericRepository<Song>
    {
        Task<List<Song>> GetAllWithDetailsAsync();
        Task<Song> GetByIdWithDetailsAsync(int id);
    }
}
