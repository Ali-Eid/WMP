using System;
using AutoMapper;
using MediatR;
using WMBProject.Core.Bases.ResponseBase;
using WMBProject.Core.Features.Songs.Query.Models;
using WMBProject.Core.Features.Songs.Query.Responses;
using WMBProject.Service.Songs;

namespace WMBProject.Core.Features.Songs.Query.Handlers
{
    public class SongsQueryHandler : ResponseHandler ,IRequestHandler<GetSongsListQuery, Response<List<GetSongsListResponse>>>,
                                                      IRequestHandler<GetSongByIdQuery, Response<GetSongsListResponse>>,
                                                      IRequestHandler<GetSongsByArtistIdQuery, Response<List<GetSongsListResponse>>>
    {
        private readonly ISongService _songService;
        private readonly IMapper _mapper;
        public SongsQueryHandler(ISongService songService, IMapper mapper)
        {
            _songService = songService;
            _mapper = mapper;
        }

        public async Task<Response<List<GetSongsListResponse>>> Handle(GetSongsListQuery request, CancellationToken cancellationToken)
        {
            var songs = await _songService.GetSongsListAsync(request.title);
            var songsMapping = _mapper.Map<List<GetSongsListResponse>>(songs);
            return Success(songsMapping);
        }

        public async Task<Response<GetSongsListResponse>> Handle(GetSongByIdQuery request, CancellationToken cancellationToken)
        {
            var song =  _songService.GetSongByIds(new List<int>() {request.Id});
            if (song == null) return NotFound<GetSongsListResponse>();
            var songMapper = _mapper.Map<GetSongsListResponse>(song);
            return Success(songMapper);
        }

        public async Task<Response<List<GetSongsListResponse>>> Handle(GetSongsByArtistIdQuery request, CancellationToken cancellationToken)
        {
            var songs = await _songService.GetSongsByArtistIdAsync(request.ArtistId);
            var songsMapping = _mapper.Map<List<GetSongsListResponse>>(songs);
            return Success(songsMapping);
        }
    }
}

