namespace SmartTestProj.BLL.Dto.EquipmentPlacementContract
{
    public class CreateEquipmentPlacementContractDto
    {
        public Guid ProductionFacilityId { get; set; } 
        public Guid ProcessEquipmentTypeId { get; set; } 
        public int UnitsCount { get; set; }
    }
}
