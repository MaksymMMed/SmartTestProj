using SmartTestProj.BLL.Dto.ProcessEquipmentType;

namespace SmartTestProj.BLL.Services.Interfaces
{
    public interface IProcessEquipmentTypeService
    {
        Task<string> Delete(Guid id);
        Task<List<GetProcessEquipmentTypeDto>> GetAll();
        Task<string> Insert(CreateProcessEquipmentTypeDto dto);
        Task<string> Update(UpdateProcessEquipmentTypeDto dto);
    }
}