using System;
namespace WMBProject.Data.Entities
{
    public class Country : BaseEntity
    {
        public Country()
        {
            Artists = new HashSet<Artist>();
        }
        public required string CountryName { get; set; }

        public ICollection<Artist> Artists { get; set; }
    }
}

