using System;
using MediatR;
using WMBProject.Core.Bases.ResponseBase;
using WMBProject.Core.Features.Artists.Query.Responses;
using WMBProject.Data.Entities;

namespace WMBProject.Core.Features.Artists.Query.Models
{
    public class GetArtistsListQuery : IRequest<Response<List<GetArtistsListResponse>>>
    {
        public string? artistName { get; set; }

        public GetArtistsListQuery(string? artistName)
        {
            this.artistName = artistName;
        }
    }
}

