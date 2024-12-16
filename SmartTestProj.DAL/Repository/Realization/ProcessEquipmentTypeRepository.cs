using Microsoft.EntityFrameworkCore;
using SmartTestProj.DAL.Context;
using SmartTestProj.DAL.Entities;
using SmartTestProj.DAL.Repository.Interface;

namespace SmartTestProj.DAL.Repository.Realization
{
    internal class ProcessEquipmentTypeRepository : GenericRepository<ProcessEquipmentType>, IProcessEquipmentTypeRepository
    {
        public ProcessEquipmentTypeRepository(AppDbContext context) : base(context)
        {
        }

        public override async Task<ProcessEquipmentType> GetCompleteById(Guid id)
        {
            var item = await table.Include(x => x.EquipmentPlacementContract).Where(x => x.Id == id).FirstOrDefaultAsync();
            return item;
        }
    }
}
