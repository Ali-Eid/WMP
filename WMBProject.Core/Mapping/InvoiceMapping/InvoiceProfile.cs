using System;
using AutoMapper;

namespace WMBProject.Core.Mapping.InvoiceMapping
{
    public partial class InvoiceProfile : Profile
    {
        public InvoiceProfile()
        {
            CreateInvoiceMapping();
        }
    }
}

