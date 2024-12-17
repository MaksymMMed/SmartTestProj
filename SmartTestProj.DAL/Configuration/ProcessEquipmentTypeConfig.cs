using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using SmartTestProj.DAL.Entities;
using SmartTestProj.DAL.Seeding;

namespace SmartTestProj.DAL.Configuration
{
    public class ProcessEquipmentTypeConfig : IEntityTypeConfiguration<ProcessEquipmentType>
    {
        public void Configure(EntityTypeBuilder<ProcessEquipmentType> builder)
        {
            builder
                .HasKey(x => x.Id);

            builder
                .HasOne(x => x.EquipmentPlacementContract)
                .WithOne(x => x.ProcessEquipmentType);

            builder
                .Property(x => x.Name)
                .HasMaxLength(100)
                .IsRequired();

            builder
                .Property(x => x.Area)
                .IsRequired();

            builder.HasData(SeedData.EquipmentTypes);

        }
    }
}
