using Microsoft.EntityFrameworkCore;
using SmartTestProj.DAL.Context;
using SmartTestProj.DAL.Entities;
using SmartTestProj.DAL.Repository.Interface;

namespace SmartTestProj.DAL.Repository.Realization
{
    public class ProductionFacilityRepository : GenericRepository<ProductionFacility>, IProductionFacilityRepository
    {
        public ProductionFacilityRepository(AppDbContext context) : base(context)
        {
        }

        public override async Task<ProductionFacility> GetCompleteById(Guid id)
        {
            //var item = await table.Include(x => x.EquipmentPlacementContract).Where(x => x.Id == id).FirstOrDefaultAsync();
            var item = await table.Where(x => x.Id == id).FirstOrDefaultAsync();
            return item;
        }
    }
}
