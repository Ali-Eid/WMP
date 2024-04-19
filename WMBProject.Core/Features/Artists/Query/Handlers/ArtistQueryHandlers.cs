using System;
using AutoMapper;
using MediatR;
using WMBProject.Core.Bases.ResponseBase;
using WMBProject.Core.Features.Artists.Query.Models;
using WMBProject.Core.Features.Artists.Query.Responses;
using WMBProject.Data.Entities;
using WMBProject.Service.Artists;

namespace WMBProject.Core.Features.Artists.Query.Handlers
{
    public class ArtistQueryHandlers : ResponseHandler, IRequestHandler<GetArtistsListQuery, Response<List<GetArtistsListResponse>>>,
                                                        IRequestHandler<GetArtistByIdQuery, Response<GetArtistByIdResponse>>
    {
        private readonly IArtistService _artistService;
        private readonly IMapper _mapper;

        public ArtistQueryHandlers(IArtistService artistService,IMapper mapper)
        {
            _artistService = artistService;
            _mapper = mapper;
        }
        public async Task<Response<List<GetArtistsListResponse>>> Handle(GetArtistsListQuery request, CancellationToken cancellationToken)
        {
            var artistsList = await _artistService.GetArtistsListAsync();
            var artistsListMapper = _mapper.Map<List<GetArtistsListResponse>>(artistsList);
            return Success(artistsListMapper);

        }

        public async Task<Response<GetArtistByIdResponse>> Handle(GetArtistByIdQuery request, CancellationToken cancellationToken)
        {
            var artist = _artistService.GetArtistsById(request.Id);
            if (artist == null) return  NotFound<GetArtistByIdResponse>();
            var artistMapping = _mapper.Map<GetArtistByIdResponse>(artist);
            return Success(artistMapping);
        }

       
    }
}

