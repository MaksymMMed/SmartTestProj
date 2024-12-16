using SmartTestProj.DAL.Entities;

namespace SmartTestProj.DAL.Repository.Interface
{
    public interface IProductionFacilityRepository:IRepository<ProductionFacility>
    {
        Task<ProductionFacility> GetCompleteById(Guid id);
    }
}