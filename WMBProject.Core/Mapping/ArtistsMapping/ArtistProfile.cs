using System;
using AutoMapper;

namespace WMBProject.Core.Mapping.ArtistsMapping
{
    public partial class ArtistProfile : Profile
    {
        public ArtistProfile()
        {
            GetArtistsListMapping();
            GetArtistsByIdMapping();
            CreateArtistMapping();
            UpdateArtistMapping();
        }
    }
}

