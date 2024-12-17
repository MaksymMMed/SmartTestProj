

using SmartTestProj.BLL.Dto.ProcessEquipmentType;
using SmartTestProj.BLL.Services.Interfaces;
using SmartTestProj.DAL.Entities;
using SmartTestProj.DAL.Repository.Interface;

namespace SmartTestProj.BLL.Services.Realizations
{
    public class ProcessEquipmentTypeService : IProcessEquipmentTypeService
    {
        private readonly IProcessEquipmentTypeRepository _processEquipmentTypeRepository;
        public ProcessEquipmentTypeService(IProcessEquipmentTypeRepository processEquipmentTypeRepository)
        {
            _processEquipmentTypeRepository = processEquipmentTypeRepository;
        }

        public async Task<string> Delete(Guid id)
        {
            try
            {
                await _processEquipmentTypeRepository.Delete(id);
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

        public async Task<string> Insert(CreateProcessEquipmentTypeDto dto)
        {
            try
            {
                if (dto.Area<=0)
                {
                    return "Area must be creater than 0";
                }
                if (dto.Name == "")
                {
                    return "Invalid name";
                }
                var item = new ProcessEquipmentType();
                {
                    item.Area = dto.Area;
                    item.Name = dto.Name;
                }
                await _processEquipmentTypeRepository.Insert(item);
                return "Created successful";
            }
            catch (Exception ex)
            {
                throw new ApplicationException($"Something went wrong", ex);
            }
        }

        public async Task<string> Update(UpdateProcessEquipmentTypeDto dto)
        {
            try
            {
                if (dto.Area <= 0)
                {
                    return "Area must be creater than 0";
                }
                if (dto.Name == "")
                {
                    return "Invalid name";
                }
                var item = new ProcessEquipmentType();
                {
                    item.Id = dto.Id;
                    item.Area = dto.Area;
                    item.Name = dto.Name;
                }
                await _processEquipmentTypeRepository.Update(item);
                return "Updated successful";
            }
            catch (Exception ex)
            {
                throw new ApplicationException($"Something went wrong", ex);
            }
        }

        public async Task<List<GetProcessEquipmentTypeDto>> GetAll()
        {
            try
            {
                var items = await _processEquipmentTypeRepository.GetAll();
                var result = items.Select(item => new GetProcessEquipmentTypeDto
                {
                    Id = item.Id,
                    Name = item.Name,
                    Area = item.Area,
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
