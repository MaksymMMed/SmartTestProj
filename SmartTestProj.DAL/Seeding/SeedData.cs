using SmartTestProj.DAL.Entities;

namespace SmartTestProj.DAL.Seeding
{
    public static class SeedData
    {
        public static ProductionFacility[] Facilities { get; set; } = [];
        public static ProcessEquipmentType[] EquipmentTypes { get; set; } = [];
        public static EquipmentPlacementContract[] Contracts { get; set; } = [];
        private static void SeedFacility()
        {
            Facilities =
            [
                new ProductionFacility{
                    Id = new Guid("BBD5C0D3-A45D-490A-B26D-D503B6A82261"),
                    Name = "Hangar 1",
                    StandartArea = 120
                },
                new ProductionFacility{
                    Id = new Guid("BBD5C0D3-A45D-490A-B26D-D503B6A82262"),
                    Name = "Hangar 2",
                    StandartArea = 200
                },
                new ProductionFacility{
                    Id = new Guid("BBD5C0D3-A45D-490A-B26D-D503B6A82263"),
                    Name = "Hangar 3",
                    StandartArea = 50
                },
                new ProductionFacility{
                    Id = new Guid("BBD5C0D3-A45D-490A-B26D-D503B6A82264"),
                    Name = "Hangar 4",
                    StandartArea = 100
                },
                new ProductionFacility{
                    Id = new Guid("BBD5C0D3-A45D-490A-B26D-D503B6A82265"),
                    Name = "Hangar 5",
                    StandartArea = 150
                },
                new ProductionFacility{
                    Id = new Guid("BBD5C0D3-A45D-490A-B26D-D503B6A82266"),
                    Name = "Hangar 6",
                    StandartArea = 150
                },
                new ProductionFacility{
                    Id = new Guid("BBD5C0D3-A45D-490A-B26D-D503B6A82267"),
                    Name = "Hangar 7",
                    StandartArea = 130
                },
                new ProductionFacility{
                    Id = new Guid("BBD5C0D3-A45D-490A-B26D-D503B6A82268"),
                    Name = "Hangar 8",
                    StandartArea = 190
                },
                new ProductionFacility{
                    Id = new Guid("BBD5C0D3-A45D-490A-B26D-D503B6A82269"),
                    Name = "Hangar 9",
                    StandartArea = 200
                },
                new ProductionFacility{
                    Id = new Guid("BBD5C0D3-A45D-490A-B26D-D503B6A82270"),
                    Name = "Hangar 10",
                    StandartArea = 150
                },
            ];
        }

        private static void SeedEquipmentTypes()
        {
            EquipmentTypes =
            [
                new ProcessEquipmentType{
                    Id = new Guid("ABD5C0D3-A45D-490A-B26D-D503B6A82261"),
                    Name = "Wood Processing",
                    Area = 50
                },
                new ProcessEquipmentType{
                    Id = new Guid("ABD5C0D3-A45D-490A-B26D-D503B6A82262"),
                    Name = "Textile Mill",
                    Area = 100
                },
                new ProcessEquipmentType{
                    Id = new Guid("ABD5C0D3-A45D-490A-B26D-D503B6A82263"),
                    Name = "Paper Mill",
                    Area = 180
                },
                new ProcessEquipmentType{
                    Id = new Guid("ABD5C0D3-A45D-490A-B26D-D503B6A82264"),
                    Name = "Food Processing Plant",
                    Area = 120
                },
                new ProcessEquipmentType{
                    Id = new Guid("ABD5C0D3-A45D-490A-B26D-D503B6A82265"),
                    Name = "Glass Factory",
                    Area = 140
                }
            ];
        }

        private static void SeedContracts()
        {
            Contracts =
            [
                new EquipmentPlacementContract{
                    ProcessEquipmentTypeId = EquipmentTypes[0].Id,
                    ProductionFacilityId = Facilities[2].Id,
                    UnitsCount = 25
                },
                new EquipmentPlacementContract{
                    ProcessEquipmentTypeId = EquipmentTypes[2].Id,
                    ProductionFacilityId = Facilities[1].Id,
                    UnitsCount = 15
                },
                new EquipmentPlacementContract{
                    ProcessEquipmentTypeId = EquipmentTypes[1].Id,
                    ProductionFacilityId = Facilities[0].Id,
                    UnitsCount = 30
                },
                new EquipmentPlacementContract{
                    ProcessEquipmentTypeId = EquipmentTypes[3].Id,
                    ProductionFacilityId = Facilities[4].Id,
                    UnitsCount = 20
                },
                new EquipmentPlacementContract{
                    ProcessEquipmentTypeId = EquipmentTypes[4].Id,
                    ProductionFacilityId = Facilities[5].Id,
                    UnitsCount = 10
                },
            ];
        }

        static SeedData() 
        {
            SeedFacility();
            SeedEquipmentTypes();
            SeedContracts();
        }
    }
}
