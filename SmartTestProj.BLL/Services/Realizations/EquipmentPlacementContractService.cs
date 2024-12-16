using SmartTestProj.BLL.Dto.EquipmentPlacementContract;
using SmartTestProj.BLL.Dto.ProcessEquipmentType;
using SmartTestProj.BLL.Dto.ProductionFacility;
using SmartTestProj.DAL.Entities;
using SmartTestProj.DAL.Repository.Interface;

namespace SmartTestProj.BLL.Services.Realizations
{
    public class EquipmentPlacementContractService
    {
        private readonly IEquipmentPlacementContractRepository _equipmentPlacementContractRepository;

        public EquipmentPlacementContractService(IEquipmentPlacementContractRepository equipmentPlacementContractRepository)
        {
            _equipmentPlacementContractRepository = equipmentPlacementContractRepository;
        }

        public async Task<string> Delete(Guid id)
        {
            try
            {
                await _equipmentPlacementContractRepository.Delete(id);
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

        public async Task<string> Insert(CreateEquipmentPlacementContractDto dto)
        {
            try
            {
                var item = new EquipmentPlacementContract();
                {
                    item.ProductionFacilityId = dto.ProductionFacilityId;
                    item.ProcessEquipmentTypeId = dto.ProcessEquipmentTypeId;
                    item.UnitsCount = dto.UnitsCount;
                }
                await _equipmentPlacementContractRepository.Insert(item);
                return "Created successful";
            }
            catch (Exception ex)
            {
                throw new ApplicationException($"Something went wrong", ex);
            }
        }

        public async Task<List<GetEquipmentPlacementContractDto>> GetAll()
        {
            try
            {
                var items = await _equipmentPlacementContractRepository.GetAll();
                var result = items.Select(item => new GetEquipmentPlacementContractDto
                {
                    ProductionFacilityId = item.ProductionFacilityId,
                    ProcessEquipmentTypeId = item.ProcessEquipmentTypeId,
                    UnitsCount = item.UnitsCount,
                    ProductionFacility = new GetProductionFacilityDto(){
                        Id = item.ProductionFacility!.Id,
                        Name = item.ProductionFacility.Name,
                        StandartArea = item.ProductionFacility.StandartArea,
                    },
                    ProcessEquipmentType = new GetProcessEquipmentType()
                    {
                        Id = item.ProcessEquipmentType!.Id,
                        Name = item.ProcessEquipmentType.Name,
                        Area = item.ProcessEquipmentType.Area,
                    }

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
