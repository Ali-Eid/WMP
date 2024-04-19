using System;
using WMBProject.Data.Entities;
using WMBProject.Infrastructure.Bases.RepositoryBase;

namespace WMBProject.Infrastructure.Repositories.Artists
{
    public interface IArtistRepository : IGenericRepositoryAsync<Artist>
    {
        public Task<List<Artist>> GetArtistsListAsync();
    }
}

