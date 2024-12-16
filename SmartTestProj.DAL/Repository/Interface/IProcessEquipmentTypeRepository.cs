using SmartTestProj.DAL.Entities;

namespace SmartTestProj.DAL.Repository.Interface
{
    internal interface IProcessEquipmentTypeRepository
    {
        Task<ProcessEquipmentType> GetCompleteById(Guid id);
    }
}