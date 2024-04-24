using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WMBProject.Api.Controllers.Base;
using WMBProject.Core.Features.Songs.Query.Models;
using WMBProject.Core.Features.Statics.Query.Models;
using WMBProject.Data.AppMetaData;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WMBProject.Api.Controllers
{
    public class StaticsController : AppControllerBase
    {
        [HttpGet(Router.StaticRouting.countries)]
        public async Task<IActionResult> GetCountries()
        {
            return Ok(await Mediator.Send(new GetCountriesQuery()));
        }
        [HttpGet(Router.StaticRouting.songsType)]
        public async Task<IActionResult> GetSongsType()
        {
            return Ok(await Mediator.Send(new GetSongTypesQuery()));
        }
    }

}