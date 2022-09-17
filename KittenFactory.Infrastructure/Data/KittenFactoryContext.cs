using KittenFactory.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace KittenFactory.Infrastructure.Data
{
    public class KittenFactoryContext : DbContext
    {
        public KittenFactoryContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Cat> Cats { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Cat>(ConfigureCat);
        }

        private void ConfigureCat(EntityTypeBuilder<Cat> builder)
        {
            builder.ToTable("Cat");

            builder.HasKey(ci => ci.Id);

            builder.Property(cb => cb.Name)
                .IsRequired()
                .HasMaxLength(50);

            builder.Property(cb => cb.Address)
               .HasMaxLength(50);

            builder.Property(cb => cb.PhoneNumber)
              .HasMaxLength(20);

            builder.Property(cb => cb.ImageUrl)
                .IsRequired()
             .HasMaxLength(250);

            builder.Property(cb => cb.DateOfBirth);
        }

    }
}