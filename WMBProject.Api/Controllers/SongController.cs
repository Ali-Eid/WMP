using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WMBProject.Api.Controllers.Base;
using WMBProject.Core.Features.Artists.Command.Models;
using WMBProject.Core.Features.Artists.Query.Models;
using WMBProject.Core.Features.Songs.Command.Models;
using WMBProject.Core.Features.Songs.Query.Models;
using WMBProject.Data.AppMetaData;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WMBProject.Api.Controllers
{
    [Authorize]
    public class SongController : AppControllerBase
    {
        [HttpGet(Router.SongRouting.list)]
        public async Task<IActionResult> GetSongsList([FromQuery] string? title)
        {
            return Ok(await Mediator.Send(new GetSongsListQuery(title)));
        }
        [HttpGet(Router.SongRouting.songById)]
        public async Task<IActionResult> GetSongById([FromRoute] int Id)
        {
            return NewResult(await Mediator.Send(new GetSongByIdQuery(Id)));
        }
        [HttpGet(Router.SongRouting.songsByArtist)]
        public async Task<IActionResult> GetSongsByArtistId([FromQuery] int ArtistId)
        {
            return Ok(await Mediator.Send(new GetSongsByArtistIdQuery(ArtistId)));
        }

        [HttpPost(Router.SongRouting.create)]
        public async Task<IActionResult> CreateSong([FromBody] CreateSongCommand command)
        {
            return NewResult(await Mediator.Send(command));
        }
        [HttpPut(Router.SongRouting.update)]
        public async Task<IActionResult> UpdateSong([FromBody] UpdateSongCommand command)
        {
            return NewResult(await Mediator.Send(command));
        }
        [HttpDelete(Router.SongRouting.delete)]
        public async Task<IActionResult> DeleteSong([FromRoute] int Id)
        {
            return NewResult(await Mediator.Send(new DeleteSongCommand(Id)));
        }

    }
}

