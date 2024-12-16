namespace SmartTestProj.DAL.Entities
{
    public class EquipmentPlacementContract
    {
        public Guid Id { get; set; }
        public Guid ProductionFacilityId { get; set; }
        public Guid ProcessEquipmentType { get; set; }
        public ProcessEquipmentType? ProcessEquipment { get; set; }
        public ProductionFacility? Facility { get; set; }  
        public int UnitsCount { get; set; }
    }
}
