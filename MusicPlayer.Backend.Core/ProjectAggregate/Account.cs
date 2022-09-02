using MusicPlayer.Backend.SharedKernel;

namespace MusicPlayer.Backend.Core.ProjectAggregate
{
    public class Account : BaseEntity
    {
        public string Email { get; set; } = string.Empty;

        public string Username { get; set; } = string.Empty;

        public string Password { get; set; } = string.Empty;
    }
}