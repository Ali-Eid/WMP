using System;
using AutoMapper;
using WMBProject.Core.Features.Invoices.Command.Models;
using WMBProject.Data.Entities;

namespace WMBProject.Core.Mapping.InvoiceMapping
{
    public partial class InvoiceProfile : Profile
    {
       void CreateInvoiceMapping()
        {
            CreateMap<CreateInvoiceCommand, Invoice>();
        }
    }
}



