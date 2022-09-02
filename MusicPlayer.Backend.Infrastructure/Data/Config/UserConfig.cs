using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MusicPlayer.Backend.Core.ProjectAggregate;

namespace MusicPlayer.Backend.Infrastructure.Data.Config
{
    public class UserConfig : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(p => p.Id)
                .IsRequired()
                .ValueGeneratedOnAdd();

            builder.Property(p => p.FirstName)
            .IsRequired()
            .HasMaxLength(50);

            builder.Property(p => p.LastName)
            .IsRequired()
            .HasMaxLength(50);
        }
    }
}