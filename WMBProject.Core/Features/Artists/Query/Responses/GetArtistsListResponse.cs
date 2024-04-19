using System;
using WMBProject.Data.Entities;

namespace WMBProject.Core.Features.Artists.Query.Responses
{
    public class GetArtistsListResponse
    {
        public int Id { get; set; }

        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        public string? Country { get; set; }
    } 
}

