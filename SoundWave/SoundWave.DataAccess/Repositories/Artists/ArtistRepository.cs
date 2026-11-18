using SoundWave.DataAccess.Context;
using SoundWave.DataAccess.Repositories.GenericRepositories;
using SoundWave.Entity.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace SoundWave.DataAccess.Repositories.Artists
{
    public class ArtistRepository : GenericRepository<Artist>, IArtistRepository
    {
        public ArtistRepository(AppDbContext context) : base(context)
        {
        }
    }
}
