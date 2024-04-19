using System;
using WMBProject.Data.Entities;
using WMBProject.Infrastructure.Bases.RepositoryBase;

namespace WMBProject.Infrastructure.Repositories.Songs
{
    public interface ISongRepository : IGenericRepositoryAsync<Song>
    {
    }
}

