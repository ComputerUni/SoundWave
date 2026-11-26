using SoundWave.DataAccess.Repositories.GenericRepositories;
using SoundWave.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SoundWave.DataAccess.Repositories.Albums
{
    public interface IAlbumRepository : IGenericRepository<Album>
    {
        Task<Album> GetAlbumWithDetailsAsync(int id);
        Task<List<Album>> GetAlbumAllAsync();
    }
}
