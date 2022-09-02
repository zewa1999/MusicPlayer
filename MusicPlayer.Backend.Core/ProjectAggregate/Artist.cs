using MusicPlayer.Backend.SharedKernel;

namespace MusicPlayer.Backend.Core.ProjectAggregate;

public class Artist : BaseEntity
{
    public string Name { get; set; } = string.Empty;
}