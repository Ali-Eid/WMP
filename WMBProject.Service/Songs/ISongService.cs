using System;
using WMBProject.Data.Entities;
using WMBProject.Data.Enums;

namespace WMBProject.Service.Songs
{
    public interface ISongService
    {
        public Task<List<Song>> GetSongsListAsync(string? title);

        public Task<List<Song>> GetSongsListByIdsAsync(List<int> ids);

        public Task<List<Song>> GetSongsByArtistIdAsync(int artistId);


        public Task<List<Song>> GetSongByIds(List<int> Ids);

        public Task<CreateStatus> CreateSong(Song song);

        public Task UpdateSong(Song artist);

        public Task DeleteSong(Song artist);
    }
}

