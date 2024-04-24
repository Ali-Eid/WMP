using System;
using WMBProject.Data.Entities;
using WMBProject.Infrastructure.Bases.RepositoryBase;

namespace WMBProject.Service.Invoices
{
    public class InvoiceService : IInvoiceService
    {
        private readonly IGenericRepositoryAsync<Invoice> _invoiceRepository;

        public InvoiceService(IGenericRepositoryAsync<Invoice> invoiceRepository)
        {
            _invoiceRepository = invoiceRepository;
        }

        public async Task<Invoice> CreateInvoice(Invoice invoice)
        {
         return await  _invoiceRepository.AddAsync(invoice);
        }
    }
}

