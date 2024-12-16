using SmartTestProj.BLL.Dto.ProductionFacility;

namespace SmartTestProj.BLL.Services.Interfaces
{
    public interface IProductionFacilityService
    {
        Task<string> Delete(Guid id);
        Task<List<GetProductionFacilityDto>> GetAll();
        Task<string> Insert(CreateProductionFacilityDto dto);
        Task<string> Update(UpdateProductionFacilityDto dto);
    }
}