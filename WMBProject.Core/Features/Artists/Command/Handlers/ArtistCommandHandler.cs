using System;
using AutoMapper;
using MediatR;
using WMBProject.Core.Bases.ResponseBase;
using WMBProject.Core.Features.Artists.Command.Models;
using WMBProject.Core.Features.Artists.Command.Responses;
using WMBProject.Data.Entities;
using WMBProject.Data.Enums;
using WMBProject.Service.Artists;

namespace WMBProject.Core.Features.Artists.Command.Handlers
{
    public class ArtistCommandHandler :ResponseHandler ,  IRequestHandler<CreateArtistCommand, Response<string>>,
                                                          IRequestHandler<EditArtisCommand, Response<string>>,
                                                          IRequestHandler<DeleteArtistCommand, Response<string>>


    {

        private readonly IArtistService _artistService;
        private readonly IMapper _mapper;

        public ArtistCommandHandler(IArtistService artistService, IMapper mapper)
        {
            _artistService = artistService;
            _mapper = mapper;
        }

        public async Task<Response<string>> Handle(CreateArtistCommand request, CancellationToken cancellationToken)
        {
            var artistMapping = _mapper.Map<Artist>(request);
            var result = await _artistService.CreateArtist(artistMapping);
            return result switch
            {
                CreateStatus.Added => Created("Created artist successfully"),
                CreateStatus.Exist => UnprocessableEntity<string>("Artist is exist"),
                _ => BadRequest<string>(),
            };
        }

        public async Task<Response<string>> Handle(EditArtisCommand request, CancellationToken cancellationToken)
        {
            var artist =  _artistService.GetArtistsById(request.Id);
            if (artist == null) return NotFound<string>("The artist is not exist");

            var artistMapping = _mapper.Map<Artist>(request);

            await _artistService.UpdateArtist(artistMapping);

            return Success<string>("Updated successfully");
        }

        public async Task<Response<string>> Handle(DeleteArtistCommand request, CancellationToken cancellationToken)
        {
            var artist = _artistService.GetArtistsById(request.Id);
            if (artist == null) return NotFound<string>("The artist is not exist");

            await _artistService.DeleteArtist(artist);

            return Deleted<string>("Deleted successfully");
        }
    }
}

