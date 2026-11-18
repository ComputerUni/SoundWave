using SoundWave.DataAccess.Repositories.GenericRepositories;
using SoundWave.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SoundWave.DataAccess.Repositories.Songs
{
    public interface ISongRepository : IGenericRepository<Song>
    {
    }
}
