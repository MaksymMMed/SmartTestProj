using SmartTestProj.BLL.Dto.ProcessEquipmentType;
using SmartTestProj.BLL.Dto.ProductionFacility;

namespace SmartTestProj.BLL.Dto.EquipmentPlacementContract
{
    public class GetEquipmentPlacementContractDto
    {
        public Guid ProductionFacilityId { get; set; }
        public Guid ProcessEquipmentTypeId { get; set; }
        public int UnitsCount { get; set; }
        public GetProcessEquipmentType ProcessEquipmentType { get; set; }
        public GetProductionFacilityDto ProductionFacility { get; set; }
    }
}
