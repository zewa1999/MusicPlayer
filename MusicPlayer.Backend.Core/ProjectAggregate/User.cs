using MusicPlayer.Backend.SharedKernel;

namespace MusicPlayer.Backend.Core.ProjectAggregate;

public class User : BaseEntity
{
    public string FirstName { get; set; } = string.Empty;
    public string LastName { get; set; } = string.Empty;
    public string Country { get; set; } = string.Empty;
    public virtual Account Account { get; set; } = new();
    public virtual IList<Song> Songs { get; set; } = new List<Song>();
}