using System;
using MediatR;
using WMBProject.Core.Bases.ResponseBase;
using WMBProject.Core.Features.Artists.Command.Responses;

namespace WMBProject.Core.Features.Artists.Command.Models
{
    public class CreateArtistCommand :IRequest<Response<string>>
    {
        public required string FName { get; set; }

        public required string LName { get; set; }

        public int Gender { get; set; }

        public int CountryId { get; set; }
    }
}

