using System;
using WMBProject.Data.Entities;

namespace WMBProject.Service.Invoices
{
    public interface IInvoiceService
    {
        public Task<Invoice> CreateInvoice(Invoice invoice);
    }
}

