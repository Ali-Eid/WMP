using System;
using AutoMapper;
using MediatR;
using WMBProject.Core.Bases.ResponseBase;
using WMBProject.Core.Features.Songs.Command.Models;
using WMBProject.Data.Entities;
using WMBProject.Data.Enums;
using WMBProject.Service.Songs;

namespace WMBProject.Core.Features.Songs.Command.Handlers
{
    public class SongCommandHandler : ResponseHandler , IRequestHandler<CreateSongCommand , Response<string>>,
                                                        IRequestHandler<UpdateSongCommand, Response<string>>,
                                                        IRequestHandler<DeleteSongCommand, Response<string>>
    {
        private readonly ISongService _songService;
        private readonly IMapper _mapper;
        public SongCommandHandler(ISongService songService, IMapper mapper)
        {
            _songService = songService;
            _mapper = mapper;
        }

        public async Task<Response<string>> Handle(CreateSongCommand request, CancellationToken cancellationToken)
        {
            var songMapping = _mapper.Map<Song>(request);
            var result = await _songService.CreateSong(songMapping);
            return result switch
            {
                CreateStatus.Added => Created("Created song successfully"),
                CreateStatus.Exist => UnprocessableEntity<string>("The song is Exist"),
                _ => BadRequest<string>("")
            };
        }

        public async Task<Response<string>> Handle(UpdateSongCommand request, CancellationToken cancellationToken)
        {
            var song = await _songService.GetSongByIds(new List<int>() { request.Id });
            if (song == null) return NotFound<string>("The song is not exist");

            var songMapper = _mapper.Map<Song>(request);
            await _songService.UpdateSong(songMapper);

            return Success("Updated successfully");
        }

        public async Task<Response<string>> Handle(DeleteSongCommand request, CancellationToken cancellationToken)
        {
            var song = await _songService.GetSongByIds(new List<int>() { request.Id });
            if (song == null) return NotFound<string>("The song is not exist");

            await _songService.DeleteSong(song.FirstOrDefault());
            return Deleted<string>("Deleted successfully");

        }
    }
}

