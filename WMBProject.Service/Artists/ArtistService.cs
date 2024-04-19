using System;
using Microsoft.EntityFrameworkCore;
using WMBProject.Data.Entities;
using WMBProject.Data.Enums;
using WMBProject.Infrastructure.Repositories.Artists;

namespace WMBProject.Service.Artists 
{
    public class ArtistService : IArtistService
    {
        private readonly IArtistRepository _artistRepository;

        public ArtistService(IArtistRepository artistRepository)
        {
            _artistRepository = artistRepository;
        }

        public async Task<CreateStatus> CreateArtist(Artist artist)
        {
            var artistResult = _artistRepository.GetTableNoTracking()
                                                .Where(x => x.FName == artist.FName && x.LName == artist.LName)
                                                .FirstOrDefault();
            if(artistResult != null)
            {
                return CreateStatus.Exist;
            }

            await _artistRepository.AddAsync(artist);

            return CreateStatus.Added;
        }

        public async Task DeleteArtist(Artist artist)
        {
            var trans = _artistRepository.BeginTransaction();
            try
            {
                await _artistRepository.DeleteAsync(artist);
                await trans.CommitAsync();

            }
            catch (Exception ex)
            {
               await trans.RollbackAsync();
            }
        }

        public Artist? GetArtistsById(int Id)
        {
            var artist = _artistRepository.GetTableNoTracking().Include(x => x.Country).Where(x=>x.Id == Id).FirstOrDefault();
            return artist;
        }

        public async Task<List<Artist>> GetArtistsListAsync()
        {   
            return await _artistRepository.GetArtistsListAsync();
        }

        public async Task UpdateArtist(Artist artist)
        {
            await _artistRepository.UpdateAsync(artist);
        }
    }
}

