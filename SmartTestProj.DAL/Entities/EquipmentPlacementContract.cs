namespace SmartTestProj.DAL.Entities
{
    public class EquipmentPlacementContract
    {
        public Guid ProductionFacilityId { get; set; }
        public Guid ProcessEquipmentTypeId { get; set; }
        public ProcessEquipmentType? ProcessEquipmentType { get; set; }
        public ProductionFacility? ProductionFacility { get; set; }  
        public int UnitsCount { get; set; }
    }
}
