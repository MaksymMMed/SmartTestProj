using SmartTestProj.BLL.Dto.EquipmentPlacementContract;
using SmartTestProj.BLL.Dto.ProcessEquipmentType;
using SmartTestProj.BLL.Dto.ProductionFacility;
using SmartTestProj.BLL.Services.Interfaces;
using SmartTestProj.DAL.Entities;
using SmartTestProj.DAL.Repository.Interface;

namespace SmartTestProj.BLL.Services.Realizations
{
    public class EquipmentPlacementContractService : IEquipmentPlacementContractService
    {
        private readonly IEquipmentPlacementContractRepository _equipmentPlacementContractRepository;
        private readonly IProductionFacilityRepository _productionFacilityRepository;
        private readonly IProcessEquipmentTypeRepository _processEquipmentTypeRepository;

        public EquipmentPlacementContractService(IEquipmentPlacementContractRepository equipmentPlacementContractRepository,
            IProductionFacilityRepository productionFacilityRepository,
            IProcessEquipmentTypeRepository processEquipmentTypeRepository)
        {
            _equipmentPlacementContractRepository = equipmentPlacementContractRepository;
            _productionFacilityRepository = productionFacilityRepository;
            _processEquipmentTypeRepository = processEquipmentTypeRepository;
        }

        public async Task<string> Delete(Guid equipmentId,Guid facilityId)
        {
            try
            {
                await _equipmentPlacementContractRepository.Delete(equipmentId,facilityId);
                return "Deleted successful";
            }
            catch (KeyNotFoundException notFound)
            {
                throw new KeyNotFoundException(notFound.Message);
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
                if (dto.UnitsCount <=0)
                {
                    return ("Units count must be creater than 0");
                }
                var facility = await _productionFacilityRepository.GetById(dto.ProductionFacilityId);
                var equipment = await _processEquipmentTypeRepository.GetById(dto.ProcessEquipmentTypeId);

                if (facility == null) 
                {
                    return ("Target production facility not found");
                }
                if (equipment == null)
                {
                    return ("Target process equipment type not found");
                }
                if (facility.StandartArea < equipment.Area)
                {
                    return ($"Not enough space in target facility, available {facility.StandartArea} m^2, needed {equipment.Area} m^2");
                }

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
                    ProductionFacility = new GetProductionFacilityDto()
                    {
                        Id = item.ProductionFacility!.Id,
                        Name = item.ProductionFacility.Name,
                        StandartArea = item.ProductionFacility.StandartArea,
                    },
                    ProcessEquipmentType = new GetProcessEquipmentTypeDto()
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
