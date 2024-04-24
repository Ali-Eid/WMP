using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WMBProject.Api.Controllers.Base;
using WMBProject.Core.Features.Authentication.Commands.Models;
using WMBProject.Core.Features.Invoices.Command.Models;
using WMBProject.Data.AppMetaData;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WMBProject.Api.Controllers
{
    public class AuthenticationController : AppControllerBase
    {
        [HttpPost(Router.AuthenticaionRouting.register)]
        public async Task<IActionResult> CreateUser([FromBody] RegisterUserCommand command)
        {
            return NewResult(await Mediator.Send(command));
        }
        [HttpPost(Router.AuthenticaionRouting.login)]
        public async Task<IActionResult> LoginUser([FromBody] LoginUserCommand command)
        {
            return NewResult(await Mediator.Send(command));
        }
    }
}

