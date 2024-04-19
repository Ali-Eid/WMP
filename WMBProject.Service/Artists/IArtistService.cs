using System;
using WMBProject.Data.Entities;
using WMBProject.Data.Enums;

namespace WMBProject.Service.Artists
{
    public interface IArtistService
    {
        public Task<List<Artist>> GetArtistsListAsync();

        public Artist? GetArtistsById(int Id);

        public Task<CreateStatus> CreateArtist(Artist artist);

        public Task UpdateArtist(Artist artist);

        public Task DeleteArtist(Artist artist);
    }
}

