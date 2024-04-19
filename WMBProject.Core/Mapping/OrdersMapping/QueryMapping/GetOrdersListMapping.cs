using System;
using AutoMapper;
using WMBProject.Core.Features.Orders.Query.Responses;
using WMBProject.Data.Entities;

namespace WMBProject.Core.Mapping.OrdersMapping
{
    public partial class OrderProfile : Profile
    {
        void GetOrdersListMapping()
        {
            CreateMap<Order, GetOrdersListResponse>()
               .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.Song.Title))
               .ForMember(dest => dest.Price, opt => opt.MapFrom(src => src.Song.Price))
               .ForMember(dest => dest.Type, opt => opt.MapFrom(src => src.Song.Type.Type))
               .ForMember(dest => dest.ArtistId, opt => opt.MapFrom(src => src.Song.ArtistId))
               .ForMember(dest => dest.ArtistName, opt => opt.MapFrom(src => src.Song.Artist.FName + " " + src.Song.Artist.LName))
               .ForMember(dest => dest.CreatedAt, opt => opt.MapFrom(src => src.Invoice.Date))
               .ForMember(dest => dest.Total, opt => opt.MapFrom(src => src.Invoice.Total))
               .ForMember(dest => dest.CreditCard, opt => opt.MapFrom(src => src.Invoice.CreditCard));
        }
    }
}
