using System;
using AutoMapper;

namespace WMBProject.Core.Mapping.StaticMapping
{
    public partial class StaticProfile : Profile
    {
        public StaticProfile()
        {
            GetCountriesMapping();
            GetSongsTypeMapping();
        }
    }
}

