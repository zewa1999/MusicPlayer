using System.ComponentModel.DataAnnotations;
using System.Security.Cryptography;
using System.Text;

namespace MusicPlayer.API.Models
{
    public class Account
    {
        public int Id { get; set; }

        [Required]
        [StringLength(30)]
        [DataType(DataType.EmailAddress)]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        [StringLength(30)]
        public string Username { get; set; }

        private string _password;

        [Required]
        public string Password
        {
            get { return _password; }
            set { _password = HashPassword(value); }
        }

        public static string HashPassword(string password, string algorithm = "sha256")
        {
            return Hash(Encoding.UTF8.GetBytes(password), algorithm);
        }

        private static string Hash(byte[] input, string algorithm = "sha256")
        {
            using (var hashAlgorithm = HashAlgorithm.Create(algorithm))
            {
                return Convert.ToBase64String(hashAlgorithm.ComputeHash(input));
            }
        }
    }
}