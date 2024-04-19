using System;
namespace WMBProject.Data.Entities
{
    public class SongType : BaseEntity
    {
        public SongType()
        {
            Songs = new HashSet<Song>();
        }
        public required string Type { get; set; }

        public ICollection<Song> Songs { get; set; }

    }
}

