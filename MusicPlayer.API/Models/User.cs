using System.ComponentModel.DataAnnotations;

namespace MusicPlayer.API.Models
{
    public class User
    {
        public int Id { get; set; }

        [Required]
        [StringLength(30)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(30)]
        public string LastName { get; set; }

        [Required]
        [StringLength(30)]
        public string Country { get; set; }

        [Required]
        [StringLength(30)]
        public virtual Account Account { get; set; }

        [Required]
        public virtual IList<Song> Songs { get; set; }
    }
}