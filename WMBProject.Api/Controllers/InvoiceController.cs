using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using WMBProject.Api.Controllers.Base;
using WMBProject.Core.Features.Invoices.Command.Models;
using WMBProject.Core.Features.Orders.Command.Models;
using WMBProject.Data.AppMetaData;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WMBProject.Api.Controllers
{
    [Authorize]
    public class InvoiceController : AppControllerBase
    {

        [HttpPost(Router.InvoiceRouting.create)]
        public async Task<IActionResult> CreateInvoice([FromBody] CreateInvoiceCommand command)
        {
            return NewResult(await Mediator.Send(command));
        }
    }
}

