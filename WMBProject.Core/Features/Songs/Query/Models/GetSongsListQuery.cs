using System;
using MediatR;
using WMBProject.Core.Bases.ResponseBase;
using WMBProject.Core.Features.Songs.Query.Responses;

namespace WMBProject.Core.Features.Songs.Query.Models
{
    public class GetSongsListQuery : IRequest<Response<List<GetSongsListResponse>>>
    {
        public string? title { get; set; }

        public GetSongsListQuery(string? title)
        {
            this.title = title;
        }
    }
}

