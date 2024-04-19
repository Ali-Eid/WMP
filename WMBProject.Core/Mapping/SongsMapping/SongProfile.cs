using System;
using AutoMapper;

namespace WMBProject.Core.Mapping.SongsMapping
{
    public partial class SongProfile : Profile
    {
        public SongProfile()
        {
            GetSongsListMapping();
            CreateSongMapping();
            UpdateSongMapping();
        }
    }
}

