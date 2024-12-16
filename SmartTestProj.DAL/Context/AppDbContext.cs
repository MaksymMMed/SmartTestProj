using Microsoft.EntityFrameworkCore;
using SmartTestProj.DAL.Configuration;
using SmartTestProj.DAL.Entities;

namespace SmartTestProj.DAL.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions options) : base(options) { }
        public DbSet<EquipmentPlacementContract> EquipmentPlacementContract { get; set; }
        public DbSet<ProductionFacility> ProductionFaciliti { get; set; }
        public DbSet<ProcessEquipmentType> ProcessEquipmentType { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfiguration(new EquipmentPlacementContractConfig());
            builder.ApplyConfiguration(new ProductionFacilityConfig());
            builder.ApplyConfiguration(new ProcessEquipmentTypeConfig());
        }
    }
}
