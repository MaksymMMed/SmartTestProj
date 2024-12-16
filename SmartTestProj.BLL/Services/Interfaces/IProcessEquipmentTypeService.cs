using SmartTestProj.BLL.Dto.ProcessEquipmentType;

namespace SmartTestProj.BLL.Services.Interfaces
{
    public interface IProcessEquipmentTypeService
    {
        Task<string> Delete(Guid id);
        Task<List<GetProcessEquipmentType>> GetAll();
        Task<string> Insert(CreateProcessEquipmentType dto);
        Task<string> Update(UpdateProcessEquipmentType dto);
    }
}