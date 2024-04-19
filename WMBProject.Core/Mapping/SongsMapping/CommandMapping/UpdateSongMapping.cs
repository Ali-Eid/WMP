using System;
using AutoMapper;
using WMBProject.Core.Features.Songs.Command.Models;
using WMBProject.Data.Entities;

namespace WMBProject.Core.Mapping.SongsMapping
{
    public partial class SongProfile : Profile
    {
        void UpdateSongMapping()
        {
            CreateMap<UpdateSongCommand, Song>();
        }
    }
}
