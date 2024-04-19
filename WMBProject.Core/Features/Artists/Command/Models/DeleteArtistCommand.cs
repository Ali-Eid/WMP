using System;
using MediatR;
using WMBProject.Core.Bases.ResponseBase;

namespace WMBProject.Core.Features.Artists.Command.Models
{
    public class DeleteArtistCommand : IRequest<Response<string>>
    {
        public int Id { get; set; }

        public DeleteArtistCommand(int Id)
        {
            this.Id = Id;
        }
    }
}

