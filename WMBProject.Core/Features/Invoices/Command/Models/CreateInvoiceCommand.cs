using System;
using MediatR;
using WMBProject.Core.Bases.ResponseBase;

namespace WMBProject.Core.Features.Invoices.Command.Models
{
    public class CreateInvoiceCommand : IRequest<Response<string>>
    {
        public List<int> SongsIds { get; set; } = new List<int>();

        public long UserId { get; set; }

        public required string CreditCard { get; set; }
    }
}

