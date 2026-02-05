using CarShop.Entityes;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CarShop.Data.Configs
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.HasKey(x => x.Id);

            builder.Property(x => x.Name).HasMaxLength(50).IsRequired();

            builder.HasMany(x => x.Cars).
                WithOne(x => x.Category).
                HasForeignKey(x => x.CategoryId).
                OnDelete(DeleteBehavior.Restrict);
        }
    }
}
