using System;
using AutoMapper;
using WMBProject.Core.Features.Statics.Query.Responses;
using WMBProject.Data.Entities;

namespace WMBProject.Core.Mapping.StaticMapping
{
    public partial class StaticProfile : Profile
    {
        void GetSongsTypeMapping() {
            CreateMap<SongType , StaticDataResponse>().ForMember(dest=>dest.Name , opt=>opt.MapFrom(src=>src.Type));
        }
    }
}

