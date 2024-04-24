using System;
using MediatR;
using WMBProject.Core.Bases.ResponseBase;

namespace WMBProject.Core.Features.Orders.Command.Models
{
    public class CreateOrderCommand : IRequest<Response<string>>
    {
        public List<int> SongsIds { get; set; } = new List<int>();

        public int InvoiceId { get; set; }
    }
}

