using System;
namespace WMBProject.Core.Features.Artists.Query.Responses
{
    public class GetArtistByIdResponse
    {
        public int Id { get; set; }

        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        public string? Country { get; set; }
    }
}

