using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MusicPlayer.Backend.Core.ProjectAggregate;

namespace MusicPlayer.Backend.Infrastructure.Data.Config;

public class SongConfig : IEntityTypeConfiguration<Song>
{
    public void Configure(EntityTypeBuilder<Song> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(p => p.Id)
            .IsRequired()
            .ValueGeneratedOnAdd();

        builder.Property(p => p.Name)
            .IsRequired()
            .HasMaxLength(50);

        builder.Property(p => p.Duration)
            .IsRequired()
            .HasMaxLength(15);

        builder.Property(p => p.Image)
            .IsRequired();

        builder.Property(p => p.Content)
            .IsRequired();
    }
}