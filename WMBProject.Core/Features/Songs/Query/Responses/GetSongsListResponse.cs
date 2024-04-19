using System;
namespace WMBProject.Core.Features.Songs.Query.Responses
{
    public class GetSongsListResponse
    {
        public int Id { get; set; }

        public string? Title { get; set; }

        public decimal? Price { get; set; }

        public string? Type { get; set; }

        public int ArtistId { get; set; }

        public string? ArtistName { get; set; }
    }
}

