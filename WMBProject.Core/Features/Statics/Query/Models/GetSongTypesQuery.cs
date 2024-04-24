using System;
using MediatR;
using WMBProject.Core.Bases.ResponseBase;
using WMBProject.Core.Features.Statics.Query.Responses;

namespace WMBProject.Core.Features.Statics.Query.Models
{
    public class GetSongTypesQuery : IRequest<Response<List<StaticDataResponse>>>
    {
       
    }
}

