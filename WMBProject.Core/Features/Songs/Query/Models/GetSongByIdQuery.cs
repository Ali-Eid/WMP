using System;
using MediatR;
using WMBProject.Core.Bases.ResponseBase;
using WMBProject.Core.Features.Songs.Query.Responses;

namespace WMBProject.Core.Features.Songs.Query.Models
{
    public class GetSongByIdQuery : IRequest<Response<GetSongsListResponse>>
    {
        public int Id { get; set; }

        public GetSongByIdQuery(int Id)
        {
            this.Id = Id;   
        }
    }
}

