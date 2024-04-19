using System;
namespace WMBProject.Data.Entities
{
    public class BaseEntity
    {
        public int Id { get; set; }

        public DateTime Created_At { get; set; } = DateTime.UtcNow;

        public DateTime Updated_At { get; set; } = DateTime.UtcNow;
    }
}

