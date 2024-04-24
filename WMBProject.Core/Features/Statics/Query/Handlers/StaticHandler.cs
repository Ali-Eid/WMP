using System;
using AutoMapper;
using MediatR;
using WMBProject.Core.Bases.ResponseBase;
using WMBProject.Core.Features.Statics.Query.Models;
using WMBProject.Core.Features.Statics.Query.Responses;
using WMBProject.Service.StaticServices;

namespace WMBProject.Core.Features.Statics.Query.Handlers
{
    public class StaticHandler :ResponseHandler , IRequestHandler<GetCountriesQuery, Response<List<StaticDataResponse>>>,
                                                  IRequestHandler<GetSongTypesQuery , Response<List<StaticDataResponse>>>
    {
        private readonly IStaticService _staticService;
        private readonly IMapper _mapper;
        public StaticHandler(IMapper mapper,IStaticService staticService)
        {
            _staticService = staticService;
            _mapper = mapper;
        }

        public async Task<Response<List<StaticDataResponse>>> Handle(GetCountriesQuery request, CancellationToken cancellationToken)
        {
            var countries =  _staticService.GetCountries();

            var countriesMapping = _mapper.Map<List<StaticDataResponse>>(countries);

            return Success(countriesMapping);
        }

        public async Task<Response<List<StaticDataResponse>>> Handle(GetSongTypesQuery request, CancellationToken cancellationToken)
        {
            var songsTypes = _staticService.GetSongTypes();

            var songsTypesMapping = _mapper.Map<List<StaticDataResponse>>(songsTypes);

            return Success(songsTypesMapping);
        }
    }
}

