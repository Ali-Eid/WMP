using System;
using WMBProject.Core.Features.Songs.Query.Responses;
using WMBProject.Data.Entities;

namespace WMBProject.Core.Mapping.SongsMapping
{
    public partial class SongProfile
    {
       void GetSongsListMapping()
        {
            CreateMap<Song, GetSongsListResponse>()
                .ForMember(dest=>dest.ArtistName , opt=>opt.MapFrom(src=>src.Artist.FName+" "+src.Artist.LName))
                .ForMember(dest => dest.Type, opt => opt.MapFrom(src => src.Type.Type))
                ;
        }
    }
}

