using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MusicPlayer.Backend.Core.ProjectAggregate;

namespace MusicPlayer.Backend.Infrastructure.Data.Config;

public class ArtistConfig : IEntityTypeConfiguration<Artist>
{
    public void Configure(EntityTypeBuilder<Artist> builder)
    {
        builder.HasKey(p => p.Id);
        builder.Property(p => p.Id)
            .IsRequired()
            .ValueGeneratedOnAdd();

        builder.Property(p => p.Name)
            .IsRequired()
            .HasMaxLength(50);
    }
}