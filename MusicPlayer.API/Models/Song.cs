using System.ComponentModel.DataAnnotations;

namespace MusicPlayer.API.Models;

public class Song
{
    public int Id { get; set; }

    [StringLength(30)]
    public string Name { get; set; }

    [StringLength(10)]
    public string Duration { get; set; }

    public virtual IList<Artist> Artists { get; set; }
    public byte[] Content { get; set; }
    public byte[] Image { get; set; }

    public static byte[] GetFileAsBytes(string path)
    {
        if (string.IsNullOrEmpty(path))
        {
            throw new ArgumentNullException($"Path to file is null or empty.");
        }
        if (!File.Exists(path))
        {
            throw new DirectoryNotFoundException($"{path} could not been found.");
        }

        return File.ReadAllBytes(path);
    }
}