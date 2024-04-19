using System;
namespace WMBProject.Data.Entities
{
    public class Invoice : BaseEntity
    {
        public Invoice()
        {
            Order = new HashSet<Order>();
        }
        public long UserId { get; set; }

        public DateTime Date { get; set; }

        public decimal Total { get; set; }

        public required string CreditCard { get; set; }

        public required User User { get; set; }

        public ICollection<Order> Order { get; set; }

    }
}

