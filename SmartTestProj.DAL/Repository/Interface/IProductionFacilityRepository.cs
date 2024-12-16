using SmartTestProj.DAL.Entities;

namespace SmartTestProj.DAL.Repository.Interface
{
    public interface IProductionFacilityRepository
    {
        Task<ProductionFacility> GetCompleteById(Guid id);
    }
}