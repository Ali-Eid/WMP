using System;
namespace WMBProject.Core.Features.Artists.Command.Responses
{
    public class CreateArtistResponse
    {
        public int Id { get; set; }

        public string? FirstName { get; set; }

        public string? LastName { get; set; }

        public string? Country { get; set; }
    }
}

