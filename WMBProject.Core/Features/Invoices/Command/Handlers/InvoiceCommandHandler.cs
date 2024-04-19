using System;
using AutoMapper;
using MediatR;
using WMBProject.Core.Bases.ResponseBase;
using WMBProject.Core.Features.Invoices.Command.Models;
using WMBProject.Data.Entities;
using WMBProject.Service.Invoices;
using WMBProject.Service.Songs;

namespace WMBProject.Core.Features.Invoices.Command.Handlers
{
    public class InvoiceCommandHandler : ResponseHandler , IRequestHandler<CreateInvoiceCommand, Response<string>>
    {
        private readonly IInvoiceService _invoiceService;
        private readonly ISongService _songService;
        private readonly IMapper _mapper;
        public InvoiceCommandHandler(IInvoiceService invoiceService, ISongService songService, IMapper mapper)
        {
            _invoiceService = invoiceService;
            _songService = songService;
            _mapper = mapper;
        }

        public async Task<Response<string>> Handle(CreateInvoiceCommand request, CancellationToken cancellationToken)
        {
            var song = _songService.GetSongById(request.SongId);
            if (song == null) return NotFound<string>("The song is not exist");

            var songMapper = _mapper.Map<Invoice>(request);

            songMapper.UserId = 1;

            songMapper.Total = song.Price;
            songMapper.Date = DateTime.UtcNow;
            await _invoiceService.CreateInvoice(songMapper);

            return Success("Created invoice successfully");

        }
    }
}

