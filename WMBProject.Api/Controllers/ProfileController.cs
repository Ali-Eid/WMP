using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WMBProject.Api.Controllers.Base;
using WMBProject.Core.Features.Authentication.Queries.Models;
using WMBProject.Core.Features.Statics.Query.Models;
using WMBProject.Data.AppMetaData;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WMBProject.Api.Controllers
{
    
    public class ProfileController : AppControllerBase
    {
        [Authorize]
        [HttpPost(Router.ProfileRouting.prefix)]
        public async Task<IActionResult> GetProfile()
        {
            return Ok(await Mediator.Send(new GetUserQuery()));
        }
       
    }

}

