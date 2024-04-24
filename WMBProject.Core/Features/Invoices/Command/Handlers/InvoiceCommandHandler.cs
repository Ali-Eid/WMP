using System;
using AutoMapper;
using MediatR;
using WMBProject.Core.Bases.ResponseBase;
using WMBProject.Core.Features.Invoices.Command.Models;
using WMBProject.Data.Entities;
using WMBProject.Service.Invoices;
using WMBProject.Service.Orders;
using WMBProject.Service.Songs;

namespace WMBProject.Core.Features.Invoices.Command.Handlers
{
    public class InvoiceCommandHandler : ResponseHandler , IRequestHandler<CreateInvoiceCommand, Response<string>>
    {
        private readonly IInvoiceService _invoiceService;
        private readonly IOrderService _orderService;
        private readonly ISongService _songService;
        private readonly IMapper _mapper;
        public InvoiceCommandHandler(IInvoiceService invoiceService, ISongService songService, IMapper mapper, IOrderService orderService)
        {
            _invoiceService = invoiceService;
            _songService = songService;
            _orderService = orderService;
            _mapper = mapper;
        }

        public async Task<Response<string>> Handle(CreateInvoiceCommand request, CancellationToken cancellationToken)
        {
            var songs = await _songService.GetSongByIds(request.SongsIds);
            if (songs == null) return NotFound<string>("The songs is not exist");

            var songMapper = _mapper.Map<Invoice>(request);

            foreach (var song in songs)
            {
                songMapper.Total += song.Price;
            }
            songMapper.Date = DateTime.UtcNow;
           var invoice =  await _invoiceService.CreateInvoice(songMapper);
            foreach (var song in songs)
            {
               await _orderService.CreateOrder(new Order() { SongId = song.Id , InvoiceId = invoice.Id});
            }
            return Success("Created invoice successfully");

        }
    }
}

