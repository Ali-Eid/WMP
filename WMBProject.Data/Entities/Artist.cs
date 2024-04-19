using System;
namespace WMBProject.Data.Entities
{
    public class Artist : BaseEntity
    {
        public Artist()
        {
            Songs = new HashSet<Song>();
        }
        public required string FName { get; set; }

        public required string LName { get;  set; }

        public int Gender { get; set; }

        public int CountryId { get; set; }

        public virtual required Country Country { get; set; }

        public ICollection<Song> Songs { get; set; }
    }
}

