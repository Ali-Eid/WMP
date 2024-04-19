using System;
using MediatR;
using WMBProject.Core.Bases.ResponseBase;

namespace WMBProject.Core.Features.Songs.Command.Models
{
    public class UpdateSongCommand : IRequest<Response<string>>
    {
        public int Id { get; set; }

        public string? Title { get; set; }

        public int TypeId { get; set; }

        public decimal Price { get; set; }

        public int ArtistId { get; set; }
    }
}

