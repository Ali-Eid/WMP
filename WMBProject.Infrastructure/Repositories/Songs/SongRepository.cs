using System;
using Microsoft.EntityFrameworkCore;
using WMBProject.Data.Entities;
using WMBProject.Infrastructure.Bases.RepositoryBase;
using WMBProject.Infrastructure.Context;

namespace WMBProject.Infrastructure.Repositories.Songs
{
    public class SongRepository : GenericRepositoryAsync<Song> ,  ISongRepository
    {
        private readonly DbSet<Song> _songs;
        public SongRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _songs = dbContext.Song;
        }
    }
}

