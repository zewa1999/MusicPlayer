using System.ComponentModel.DataAnnotations;

namespace MusicPlayer.API.Models
{
    public class Artist
    {
        public int Id { get; set; }
        [StringLength(30)]
        public string Name { get; set; }
        public virtual IList<Song> CreatedSongs { get; set; }
    }
}
