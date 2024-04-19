using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WMBProject.Api.Controllers.Base;
using WMBProject.Core.Features.Orders.Command.Models;
using WMBProject.Core.Features.Orders.Query.Models;
using WMBProject.Core.Features.Songs.Query.Models;
using WMBProject.Data.AppMetaData;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WMBProject.Api.Controllers
{
    public class OrderController : AppControllerBase
    {
        [HttpGet(Router.OrderRouting.list)]
        public async Task<IActionResult> GetOrdersList()
        {
            return Ok(await Mediator.Send(new GetOrdersListQuery()));
        }
        [HttpPost(Router.OrderRouting.create)]
        public async Task<IActionResult> CreateOrder([FromBody] CreateOrderCommand command)
        {
            return NewResult(await Mediator.Send(command));
        }
    }
}

