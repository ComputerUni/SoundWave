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
    }
}
