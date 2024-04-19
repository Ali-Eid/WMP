using System;
using AutoMapper;
using WMBProject.Core.Features.Artists.Command.Models;
using WMBProject.Data.Entities;

namespace WMBProject.Core.Mapping.ArtistsMapping
{
    public partial class ArtistProfile : Profile
    {
        void CreateArtistMapping()
        {
            CreateMap<CreateArtistCommand, Artist>();
        }
    }
}

