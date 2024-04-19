using System;
using MediatR;
using WMBProject.Core.Bases.ResponseBase;

namespace WMBProject.Core.Features.Orders.Command.Models
{
    public class CreateOrderCommand : IRequest<Response<string>>
    {
        public int SongId { get; set; }

        public int InvoiceId { get; set; }
    }
}

