using System.Security.Cryptography;
using System.Text;

namespace MusicPlayer.Backend.Infrastructure
{
    public class EntitiesHelper
    {
        public string HashPassword(string password, string algorithm = "sha256")
        {
            return Hash(Encoding.UTF8.GetBytes(password), algorithm);
        }

        private string Hash(byte[] input, string algorithm = "sha256")
        {
            using (var hashAlgorithm = HashAlgorithm.Create(algorithm))
            {
                return Convert.ToBase64String(hashAlgorithm!.ComputeHash(input));
            }
        }

        public byte[] GetFileAsBytes(string? path)
        {
            if (string.IsNullOrEmpty(path))
            {
                throw new ArgumentNullException("Path to file is null or empty.");
            }
            if (!File.Exists(path))
            {
                throw new DirectoryNotFoundException($"{path} could not been found.");
            }

            return File.ReadAllBytes(path);
        }
    }
}