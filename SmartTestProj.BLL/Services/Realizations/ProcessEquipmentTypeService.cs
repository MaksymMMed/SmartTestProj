using SmartTestProj.BLL.Dto.ProcessEquipmentType;
using SmartTestProj.DAL.Entities;
using SmartTestProj.DAL.Repository.Interface;

namespace SmartTestProj.BLL.Services.Realizations
{
    public class ProcessEquipmentTypeService
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
            catch (KeyNotFoundException)
            {
                return "Item not found";
            }
           
            catch (Exception ex)
            {
                throw new ApplicationException($"Something went wrong", ex);
            }
        }

        public async Task<string> Insert(CreateProcessEquipmentType dto)
        {
            try
            {
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

        public async Task<string> Update(UpdateProcessEquipmentType dto)
        {
            try
            {
                var item = new ProcessEquipmentType();
                {
                    item.Id = dto.Id;
                    item.Area = dto.Area;
                    item.Name = dto.Name;
                }
                await _processEquipmentTypeRepository.Insert(item);
                return "Updated successful";
            }
            catch (Exception ex)
            {
                throw new ApplicationException($"Something went wrong", ex);
            }
        }

        public async Task<List<GetProcessEquipmentType>> GetAll()
        {
            try
            {
                var items = await _processEquipmentTypeRepository.GetAll();
                var result = items.Select(item => new GetProcessEquipmentType
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
