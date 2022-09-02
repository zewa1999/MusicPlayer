using MusicPlayer.Backend.SharedKernel;

namespace MusicPlayer.Backend.Core.ProjectAggregate;

public class Song : BaseEntity
{
    public string Name { get; set; } = string.Empty;
    public string Duration { get; set; } = string.Empty;
    public virtual ICollection<Artist> Artists { get; set; } = new List<Artist>();
    public byte[] Content { get; set; } = new byte[] { };
    public byte[] Image { get; set; } = new byte[] { };
}