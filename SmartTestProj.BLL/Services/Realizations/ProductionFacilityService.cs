using SmartTestProj.BLL.Dto.ProductionFacility;
using SmartTestProj.DAL.Entities;
using SmartTestProj.DAL.Repository.Interface;

namespace SmartTestProj.BLL.Services.Realizations
{
    public class ProductionFacilityService
    {
        private readonly IProductionFacilityRepository _productionFacilityRepository;

        public ProductionFacilityService(IProductionFacilityRepository productionFacilityRepository)
        {
            _productionFacilityRepository = productionFacilityRepository;
        }

        public async Task<string> Delete(Guid id)
        {
            try
            {
                await _productionFacilityRepository.Delete(id);
                return "Deleted successful";
            }
            catch (KeyNotFoundException)
            {
                return "Item not found";
            }
           
            catch (Exception ex)
            {
                throw new ApplicationException($"Something went wrong", ex);
            }
        }

        public async Task<string> Insert(CreateProductionFacilityDto dto)
        {
            try
            {
                var item = new ProductionFacility();
                {
                    item.StandartArea = dto.StandartArea;
                    item.Name = dto.Name;
                }
                await _productionFacilityRepository.Insert(item);
                return "Created successful";
            }
            catch (Exception ex)
            {
                throw new ApplicationException($"Something went wrong", ex);
            }
        }

        public async Task<string> Update(UpdateProductionFacilityDto dto)
        {
            try
            {
                var item = new ProductionFacility();
                {
                    item.Id = dto.Id;
                    item.StandartArea = dto.StandartArea;
                    item.Name = dto.Name;
                }
                await _productionFacilityRepository.Insert(item);
                return "Updated successful";
            }
            catch (Exception ex)
            {
                throw new ApplicationException($"Something went wrong", ex);
            }
        }

        public async Task<List<GetProductionFacilityDto>> GetAll()
        {
            try
            {
                var items = await _productionFacilityRepository.GetAll();
                var result = items.Select(item => new GetProductionFacilityDto
                {
                    Id = item.Id,
                    Name = item.Name,
                    StandartArea = item.StandartArea,
                }).ToList();

                return result;
            }
            catch (Exception ex)
            {
                throw new ApplicationException($"Something went wrong", ex);
            }
        }
    }
}
