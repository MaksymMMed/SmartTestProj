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

        public override async Task<IEnumerable<EquipmentPlacementContract>> GetAll()
        {
            var items = await table.Include(x => x.ProcessEquipmentType).Include(x => x.ProductionFacility).ToListAsync();
            return items;
        }
    }
}
