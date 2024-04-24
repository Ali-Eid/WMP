using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WMBProject.Api.Controllers.Base;
using WMBProject.Core.Features.Artists.Command.Models;
using WMBProject.Core.Features.Artists.Query.Models;
using WMBProject.Data.AppMetaData;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WMBProject.Api.Controllers
{
   // [ApiController]
   [Authorize]
    public class ArtistController : AppControllerBase
    {
        [HttpGet(Router.ArtistRouting.list)]
        public async Task<IActionResult> GetArtistsList([FromQuery] string? artistName)
        {
            return Ok(await Mediator.Send(new GetArtistsListQuery(artistName)));
        }
        [HttpGet(Router.ArtistRouting.artistById)]
        public async Task<IActionResult> GetArtistsById([FromRoute] int Id)
        {
            return NewResult(await Mediator.Send(new GetArtistByIdQuery(Id)));
        }
        [HttpPost(Router.ArtistRouting.create)]
        public async Task<IActionResult> CreateArtist([FromBody] CreateArtistCommand command)
        {
            return NewResult(await Mediator.Send(command));
        }
        [HttpPut(Router.ArtistRouting.update)]
        public async Task<IActionResult> UpdateArtist([FromBody] EditArtisCommand command)
        {
            return NewResult(await Mediator.Send(command));
        }
        [HttpDelete(Router.ArtistRouting.delete)]
        public async Task<IActionResult> DeleteArtist([FromRoute] int Id)
        {
            return NewResult(await Mediator.Send(new DeleteArtistCommand(Id)));
        }
    }
}

