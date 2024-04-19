using System;
namespace WMBProject.Data.Entities
{
    public class Order : BaseEntity
    {
        public int SongId { get; set; }

        public int InvoiceId { get; set; }

        public virtual Song Song { get; set; }

        public virtual Invoice Invoice { get; set; }
    }
}

