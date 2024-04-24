using System;
using WMBProject.Data.Entities;

namespace WMBProject.Service.StaticServices
{
    public interface IStaticService
    {
        List<Country> GetCountries();

        List<SongType> GetSongTypes();
    }
}

