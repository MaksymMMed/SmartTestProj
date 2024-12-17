using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SmartTestProj.DAL.Entities;
using SmartTestProj.DAL.Seeding;

namespace SmartTestProj.DAL.Configuration
{
    public class EquipmentPlacementContractConfig : IEntityTypeConfiguration<EquipmentPlacementContract>
    {
        public void Configure(EntityTypeBuilder<EquipmentPlacementContract> builder)
        {
            builder
                .HasKey(x => new { x.ProductionFacilityId, x.ProcessEquipmentTypeId});

            builder
                .HasOne(x => x.ProcessEquipmentType)
                .WithOne(x => x.EquipmentPlacementContract)
                .HasForeignKey<EquipmentPlacementContract>(x => x.ProcessEquipmentTypeId);

            builder
                .HasOne(x => x.ProductionFacility)
                .WithOne(x => x.EquipmentPlacementContract)
                .HasForeignKey<EquipmentPlacementContract>(x => x.ProductionFacilityId);

            builder
                .Property(x => x.UnitsCount)
                .IsRequired();

            builder.HasData(SeedData.Contracts);
        }
    }
}
