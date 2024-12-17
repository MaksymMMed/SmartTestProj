namespace SmartTestProj.DAL.Entities
{
    public class ProcessEquipmentType
    {
        public Guid Id { get; set; }
        public EquipmentPlacementContract? EquipmentPlacementContract { get; set; }
        public string Name { get; set; }
        public int Area { get; set; }
    }
}
