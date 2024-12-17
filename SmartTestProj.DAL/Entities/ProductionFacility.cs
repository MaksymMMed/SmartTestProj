namespace SmartTestProj.DAL.Entities
{
    public class ProductionFacility
    {
        public Guid Id { get; set; }
        public EquipmentPlacementContract? EquipmentPlacementContract { get; set; }
        public string Name { get; set; }
        public int StandartArea { get; set; }
    }
}
