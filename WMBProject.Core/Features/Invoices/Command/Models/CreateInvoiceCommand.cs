using System;
using MediatR;
using WMBProject.Core.Bases.ResponseBase;

namespace WMBProject.Core.Features.Invoices.Command.Models
{
    public class CreateInvoiceCommand : IRequest<Response<string>>
    {
        public int SongId { get; set; }
        public required string CreditCard { get; set; }
    }
}

