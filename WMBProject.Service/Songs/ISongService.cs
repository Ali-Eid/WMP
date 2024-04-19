using System;
using WMBProject.Data.Entities;
using WMBProject.Data.Enums;

namespace WMBProject.Service.Songs
{
    public interface ISongService
    {
        public Task<List<Song>> GetSongsListAsync();

        public Task<List<Song>> GetSongsListByIdsAsync(List<int> ids);

        public Song? GetSongById(int Id);

        public Task<CreateStatus> CreateSong(Song song);

        public Task UpdateSong(Song artist);

        public Task DeleteSong(Song artist);
    }
}

