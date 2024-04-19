using System;
namespace WMBProject.Data.Entities
{
    public class Song : BaseEntity
    {
        public Song()
        {
            Order = new HashSet<Order>();
        }
        public required string Title { get; set; }

        public int TypeId { get; set; }

        public decimal Price { get; set; }

        public int ArtistId { get; set; }

        public virtual required Artist Artist { get; set; }

        public virtual required SongType Type { get; set; }

        public  ICollection<Order> Order { get; set; }
    }
}

