using CarShop.Entityes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CarShop.Data.Configs
{
    public class CarConfiguration : IEntityTypeConfiguration<Car>
    {
        public void Configure(EntityTypeBuilder<Car> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Brand).IsRequired().HasMaxLength(50);
            builder.Property(x => x.Model).IsRequired().HasMaxLength(50);
            builder.Property(x => x.Year).IsRequired();
            builder.Property(x => x.Price).IsRequired();
            builder.Property(x => x.Color).IsRequired();
            builder.Property(x => x.IsAvailable).HasDefaultValue(true);

            builder.HasOne(x => x.Category).
                WithMany(x => x.Cars).
                HasForeignKey(x => x.CategoryId).
                OnDelete(DeleteBehavior.Restrict);
        }
    }
}
