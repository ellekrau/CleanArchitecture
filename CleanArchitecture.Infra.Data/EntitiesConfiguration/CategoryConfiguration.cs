using CleanArchitecture.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CleanArchitecture.Infra.Data.EntitiesConfiguration
{
    public class CategoryConfiguration : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> entityTypeBuilder)
        {
            entityTypeBuilder.HasKey(h => h.Id);
            entityTypeBuilder.Property(p => p.Name).HasMaxLength(100).IsRequired();

            PupulateWithDefaultValues(entityTypeBuilder);
        }

        private static void PupulateWithDefaultValues(EntityTypeBuilder<Category> entityTypeBuilder)
        {
            entityTypeBuilder.HasData(
                new Category(1, "Material escolar"), 
                new Category(2, "Eletrônicos"), 
                new Category(3, "Acessórios"));
        }
    }
}
