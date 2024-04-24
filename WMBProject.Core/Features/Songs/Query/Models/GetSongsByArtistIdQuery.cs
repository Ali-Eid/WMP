using System;
using MediatR;
using WMBProject.Core.Bases.ResponseBase;
using WMBProject.Core.Features.Songs.Query.Responses;

namespace WMBProject.Core.Features.Songs.Query.Models
{
    public class GetSongsByArtistIdQuery : IRequest<Response<List<GetSongsListResponse>>>
    {
        public int ArtistId { get; set; }

        public GetSongsByArtistIdQuery(int ArtistId)
        {
            this.ArtistId = ArtistId;
        }
    }
}

