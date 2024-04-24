using System;
using Microsoft.EntityFrameworkCore;
using WMBProject.Data.Entities;
using WMBProject.Data.Enums;
using WMBProject.Infrastructure.Repositories.Songs;

namespace WMBProject.Service.Songs
{
    public class SongService : ISongService
    {
        private readonly ISongRepository _songRepository;
        public SongService(ISongRepository songRepository)
        {
            _songRepository = songRepository;
        }

        public async Task<CreateStatus> CreateSong(Song song)
        {
            var newSong =  _songRepository.GetTableNoTracking().Where(x => x.Id == song.Id).FirstOrDefault();
            if (newSong != null)
                return CreateStatus.Exist;
            await _songRepository.AddAsync(song);
            return CreateStatus.Added;
        }

        public async Task DeleteSong(Song song)
        {
            var trans =  _songRepository.BeginTransaction();
            try
            {
                await _songRepository.DeleteAsync(song);
              await  trans.CommitAsync();
            }
            catch (Exception ex)
            {
              await  trans.RollbackAsync();
            }
        }

        public async Task<List<Song>> GetSongByIds(List<int> Ids)
        {
            return await _songRepository.GetTableNoTracking()
                                            .Where(x => Ids.Contains(x.Id))
                                            .Include(x => x.Artist)
                                            .Include(x => x.Type)
                                            .ToListAsync();
        }

        public async Task<List<Song>> GetSongsListAsync(string? title)
        {
            if(title != null)
            {
                return await _songRepository.GetTableNoTracking().Where(x=>x.Title.ToLower().Contains(title))
                                       .Include(x => x.Artist)
                                       .Include(x => x.Type)
                                       .ToListAsync();
            }
            else
            {
                return await _songRepository.GetTableNoTracking()
                                       .Include(x => x.Artist)
                                       .Include(x => x.Type)
                                       .ToListAsync();
            }
           
        }

        public async Task UpdateSong(Song song)
        {
            await _songRepository.UpdateAsync(song);
        }

        public async Task<List<Song>> GetSongsListByIdsAsync(List<int> ids)
        {
            if (ids.Count == 0)
            {
                return new List<Song>() { };
            }
            return await _songRepository.GetTableNoTracking()
                                        .Where(x => ids.Contains(x.Id))
                                        .Include(x => x.Artist)
                                        .Include(x => x.Type)
                                        .ToListAsync();
        }

        public async Task<List<Song>> GetSongsByArtistIdAsync(int artistId)
        {
            return await _songRepository.GetTableNoTracking().Where(x=>x.ArtistId==artistId).Include(x => x.Artist)
                                        .Include(x => x.Type)
                                        .ToListAsync();
        }
    }
}

