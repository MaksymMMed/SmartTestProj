using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SmartTestProj.DAL.Entities;
using SmartTestProj.DAL.Seeding;

namespace SmartTestProj.DAL.Configuration
{
    public class ProductionFacilityConfig : IEntityTypeConfiguration<ProductionFacility>
    {
        public void Configure(EntityTypeBuilder<ProductionFacility> builder)
        {
            builder
               .HasKey(x => x.Id);

            builder
                .HasOne(x => x.EquipmentPlacementContract)
                .WithOne(x => x.ProductionFacility);

            builder
                .Property(x => x.Name)
                .HasMaxLength(100)
                .IsRequired();

            builder
                .Property(x => x.StandartArea)
                .IsRequired();

            builder.HasData(SeedData.Facilities);

        }
    }
}
