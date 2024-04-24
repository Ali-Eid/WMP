using System;
using WMBProject.Data.Entities;
using WMBProject.Infrastructure.Bases.RepositoryBase;

namespace WMBProject.Service.StaticServices
{
    public class StaticService : IStaticService
    {
        private readonly IGenericRepositoryAsync<Country> _countries;
        private readonly IGenericRepositoryAsync<SongType> _songsTypes;

        public StaticService(IGenericRepositoryAsync<Country> countries, IGenericRepositoryAsync<SongType> songsTypes)
        {
            _countries = countries;
            _songsTypes = songsTypes;
        }

        public  List<Country> GetCountries()
        {
            return _countries.GetTableNoTracking().ToList();
        }

        public List<SongType> GetSongTypes()
        {
            return _songsTypes.GetTableNoTracking().ToList();
        }
    }
}

