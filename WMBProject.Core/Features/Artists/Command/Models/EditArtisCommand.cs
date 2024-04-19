using System;
using MediatR;
using WMBProject.Core.Bases.ResponseBase;

namespace WMBProject.Core.Features.Artists.Command.Models
{
    public class EditArtisCommand : IRequest<Response<string>>
    {
        public int Id { get; set; }

        public required string FName { get; set; }

        public required string LName { get; set; }

        public int Gender { get; set; }

        public int CountryId { get; set; }
    }
}

