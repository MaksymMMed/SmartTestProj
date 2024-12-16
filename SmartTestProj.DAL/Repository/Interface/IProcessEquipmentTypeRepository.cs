using SmartTestProj.DAL.Entities;

namespace SmartTestProj.DAL.Repository.Interface
{
    public interface IProcessEquipmentTypeRepository:IRepository<ProcessEquipmentType>
    {
        Task<ProcessEquipmentType> GetCompleteById(Guid id);
    }
}