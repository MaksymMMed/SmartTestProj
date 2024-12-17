using Microsoft.EntityFrameworkCore;
using SmartTestProj.DAL.Context;
using SmartTestProj.DAL.Entities;
using SmartTestProj.DAL.Repository.Interface;

namespace SmartTestProj.DAL.Repository.Realization
{
    public class EquipmentPlacementContractRepository : GenericRepository<EquipmentPlacementContract>, IEquipmentPlacementContractRepository
    {
        public EquipmentPlacementContractRepository(AppDbContext context) : base(context)
        {
        }

        public override Task<EquipmentPlacementContract> GetCompleteById(Guid id)
        {
            throw new NotImplementedException();
        }

        public override Task Delete(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task Delete(Guid equipmentId,Guid facilityId)
        {
            var item = await table
                .FirstOrDefaultAsync(c => c.ProductionFacilityId == facilityId
                && c.ProcessEquipmentTypeId == equipmentId);

            if (item == null)
            {
                throw new KeyNotFoundException("Item not found.");
            }

            table.Remove(item);
            await context.SaveChangesAsync();
        }

        public override async Task<IEnumerable<EquipmentPlacementContract>> GetAll()
        {
            var items = await table.Include(x => x.ProcessEquipmentType).Include(x => x.ProductionFacility).ToListAsync();
            return items;
        }
    }
}
