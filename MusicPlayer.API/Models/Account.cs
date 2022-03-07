using System.ComponentModel.DataAnnotations;

namespace MusicPlayer.API.Models
{
    public class Account
    {
        public int Id { get; set; }
        [StringLength(30)]
        public string Email { get; set; }
        [StringLength(30)]
        public string Username { get; set; }
        [StringLength(30)]
        public string Password { get; set; }

    }
}