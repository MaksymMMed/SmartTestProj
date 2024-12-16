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
    }
}
