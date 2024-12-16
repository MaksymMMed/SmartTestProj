using SmartTestProj.BLL.Dto.EquipmentPlacementContract;

namespace SmartTestProj.BLL.Services.Interfaces
{
    public interface IEquipmentPlacementContractService
    {
        Task<string> Delete(Guid id);
        Task<List<GetEquipmentPlacementContractDto>> GetAll();
        Task<string> Insert(CreateEquipmentPlacementContractDto dto);
    }
}