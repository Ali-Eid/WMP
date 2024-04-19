using System;
using MediatR;
using WMBProject.Core.Bases.ResponseBase;

namespace WMBProject.Core.Features.Songs.Command.Models
{
    public class DeleteSongCommand : IRequest<Response<string>>
    {
        public int Id { get; set; }
        public DeleteSongCommand(int Id)
        {
            this.Id = Id;
        }
    }
}

