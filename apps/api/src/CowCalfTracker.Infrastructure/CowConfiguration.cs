using CowCalfTracker.Domain.Cattle;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CowCalfTracker.Infrastructure
{
    public sealed class CowConfiguration : IEntityTypeConfiguration<Cow>
    {
        public void Configure(EntityTypeBuilder<Cow> builder)
        {
            builder.ToTable("cows");

            builder.HasKey(cow => cow.Id);

            builder.Property(cow => cow.Name)
            .HasColumnName("name")
            .HasMaxLength(200);

            builder.Property(cow => cow.TagNumber)
                .HasColumnName("tag_number")
                .IsRequired();

            builder.HasIndex(cow => cow.TagNumber)
                .IsUnique();
        }
    }
}