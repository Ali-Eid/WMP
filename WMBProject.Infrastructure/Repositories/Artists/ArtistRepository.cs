using System;
using Microsoft.EntityFrameworkCore;
using WMBProject.Data.Entities;
using WMBProject.Infrastructure.Bases.RepositoryBase;
using WMBProject.Infrastructure.Context;

namespace WMBProject.Infrastructure.Repositories.Artists
{
    public class ArtistRepository : GenericRepositoryAsync<Artist> , IArtistRepository
    {
        private readonly DbSet<Artist> _artists;

        public ArtistRepository(ApplicationDbContext dbContext) : base(dbContext)
        {
            _artists = dbContext.Artist;
        }

        public async Task<List<Artist>> GetArtistsListAsync()
        {
            return await _artists.Include(art=>art.Country).ToListAsync();
        }
    }
}

