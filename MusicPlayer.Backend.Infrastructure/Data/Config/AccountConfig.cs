using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using MusicPlayer.Backend.Core.ProjectAggregate;

namespace MusicPlayer.Backend.Infrastructure.Data.Config;

public class AccountConfig : IEntityTypeConfiguration<Account>
{
    public void Configure(EntityTypeBuilder<Account> builder)
    {
        builder.HasKey(x => x.Id);

        builder.Property(p => p.Id)
            .IsRequired()
            .ValueGeneratedOnAdd();

        builder.Property(p => p.Password)
            .IsRequired();

        builder.Property(p => p.Username)
            .IsRequired()
            .HasMaxLength(25);
    }
}