using System;
using MediatR;
using WMBProject.Core.Bases.ResponseBase;
using WMBProject.Core.Features.Artists.Query.Responses;

namespace WMBProject.Core.Features.Artists.Query.Models
{
    public class GetArtistByIdQuery : IRequest<Response<GetArtistByIdResponse>>
    {
        public int Id { get; set; }

        public GetArtistByIdQuery(int Id)
        {
            this.Id = Id;
        }
    }
}

