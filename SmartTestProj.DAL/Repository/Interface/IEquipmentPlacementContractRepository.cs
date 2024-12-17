using SmartTestProj.DAL.Entities;

namespace SmartTestProj.DAL.Repository.Interface
{
    public interface IEquipmentPlacementContractRepository:IRepository<EquipmentPlacementContract>
    {
        public Task Delete(Guid equipmentId, Guid facilityId);
    }
}