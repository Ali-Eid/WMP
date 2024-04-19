using System;
namespace WMBProject.Core.Features.Orders.Query.Responses
{
    public class GetOrdersListResponse
    {
        public int Id { get; set; }

        public string? Title { get; set; }

        public decimal? Price { get; set; }

        public string? Type { get; set; }

        public int ArtistId { get; set; }

        public string? ArtistName { get; set; }

        public DateTime CreatedAt { get; set; }

        public decimal Total { get; set; }

        public string? CreditCard { get; set; }
    }
}

