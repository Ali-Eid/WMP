using System;
using WMBProject.Core.Features.Artists.Query.Responses;
using WMBProject.Data.Entities;

namespace WMBProject.Core.Mapping.ArtistsMapping
{
    public partial class ArtistProfile
    {
       void GetArtistsListMapping()
        {
            CreateMap<Artist, GetArtistsListResponse>()
                .ForMember(dest => dest.FirstName, opt => opt.MapFrom(src => src.FName))
                .ForMember(dest => dest.LastName, opt => opt.MapFrom(src => src.LName))
                .ForMember(dest => dest.Country, opt => opt.MapFrom(src => src.Country.CountryName));
        }
    }
}

