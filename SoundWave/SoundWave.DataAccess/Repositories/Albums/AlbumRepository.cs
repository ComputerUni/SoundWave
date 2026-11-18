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
    }
}
