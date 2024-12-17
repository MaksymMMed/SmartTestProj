using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SmartTestProj.DAL.Migrations
{
    /// <inheritdoc />
    public partial class addinitialdata : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "EquipmentPlacementContractId",
                table: "ProductionFaciliti");

            migrationBuilder.DropColumn(
                name: "EquipmentPlacementContractId",
                table: "ProcessEquipmentType");

            migrationBuilder.InsertData(
                table: "ProcessEquipmentType",
                columns: new[] { "Id", "Area", "Name" },
                values: new object[,]
                {
                    { new Guid("abd5c0d3-a45d-490a-b26d-d503b6a82261"), 50, "Wood Processing" },
                    { new Guid("abd5c0d3-a45d-490a-b26d-d503b6a82262"), 100, "Textile Mill" },
                    { new Guid("abd5c0d3-a45d-490a-b26d-d503b6a82263"), 180, "Paper Mill" },
                    { new Guid("abd5c0d3-a45d-490a-b26d-d503b6a82264"), 120, "Food Processing Plant" },
                    { new Guid("abd5c0d3-a45d-490a-b26d-d503b6a82265"), 140, "Glass Factory" }
                });

            migrationBuilder.InsertData(
                table: "ProductionFaciliti",
                columns: new[] { "Id", "Name", "StandartArea" },
                values: new object[,]
                {
                    { new Guid("bbd5c0d3-a45d-490a-b26d-d503b6a82261"), "Hangar 1", 120 },
                    { new Guid("bbd5c0d3-a45d-490a-b26d-d503b6a82262"), "Hangar 2", 200 },
                    { new Guid("bbd5c0d3-a45d-490a-b26d-d503b6a82263"), "Hangar 3", 50 },
                    { new Guid("bbd5c0d3-a45d-490a-b26d-d503b6a82264"), "Hangar 4", 100 },
                    { new Guid("bbd5c0d3-a45d-490a-b26d-d503b6a82265"), "Hangar 5", 150 },
                    { new Guid("bbd5c0d3-a45d-490a-b26d-d503b6a82266"), "Hangar 6", 150 }
                });

            migrationBuilder.InsertData(
                table: "EquipmentPlacementContract",
                columns: new[] { "ProcessEquipmentTypeId", "ProductionFacilityId", "UnitsCount" },
                values: new object[,]
                {
                    { new Guid("abd5c0d3-a45d-490a-b26d-d503b6a82262"), new Guid("bbd5c0d3-a45d-490a-b26d-d503b6a82261"), 30 },
                    { new Guid("abd5c0d3-a45d-490a-b26d-d503b6a82263"), new Guid("bbd5c0d3-a45d-490a-b26d-d503b6a82262"), 15 },
                    { new Guid("abd5c0d3-a45d-490a-b26d-d503b6a82261"), new Guid("bbd5c0d3-a45d-490a-b26d-d503b6a82263"), 25 },
                    { new Guid("abd5c0d3-a45d-490a-b26d-d503b6a82264"), new Guid("bbd5c0d3-a45d-490a-b26d-d503b6a82265"), 20 },
                    { new Guid("abd5c0d3-a45d-490a-b26d-d503b6a82265"), new Guid("bbd5c0d3-a45d-490a-b26d-d503b6a82266"), 10 }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "EquipmentPlacementContract",
                keyColumns: new[] { "ProcessEquipmentTypeId", "ProductionFacilityId" },
                keyValues: new object[] { new Guid("abd5c0d3-a45d-490a-b26d-d503b6a82262"), new Guid("bbd5c0d3-a45d-490a-b26d-d503b6a82261") });

            migrationBuilder.DeleteData(
                table: "EquipmentPlacementContract",
                keyColumns: new[] { "ProcessEquipmentTypeId", "ProductionFacilityId" },
                keyValues: new object[] { new Guid("abd5c0d3-a45d-490a-b26d-d503b6a82263"), new Guid("bbd5c0d3-a45d-490a-b26d-d503b6a82262") });

            migrationBuilder.DeleteData(
                table: "EquipmentPlacementContract",
                keyColumns: new[] { "ProcessEquipmentTypeId", "ProductionFacilityId" },
                keyValues: new object[] { new Guid("abd5c0d3-a45d-490a-b26d-d503b6a82261"), new Guid("bbd5c0d3-a45d-490a-b26d-d503b6a82263") });

            migrationBuilder.DeleteData(
                table: "EquipmentPlacementContract",
                keyColumns: new[] { "ProcessEquipmentTypeId", "ProductionFacilityId" },
                keyValues: new object[] { new Guid("abd5c0d3-a45d-490a-b26d-d503b6a82264"), new Guid("bbd5c0d3-a45d-490a-b26d-d503b6a82265") });

            migrationBuilder.DeleteData(
                table: "EquipmentPlacementContract",
                keyColumns: new[] { "ProcessEquipmentTypeId", "ProductionFacilityId" },
                keyValues: new object[] { new Guid("abd5c0d3-a45d-490a-b26d-d503b6a82265"), new Guid("bbd5c0d3-a45d-490a-b26d-d503b6a82266") });

            migrationBuilder.DeleteData(
                table: "ProductionFaciliti",
                keyColumn: "Id",
                keyValue: new Guid("bbd5c0d3-a45d-490a-b26d-d503b6a82264"));

            migrationBuilder.DeleteData(
                table: "ProcessEquipmentType",
                keyColumn: "Id",
                keyValue: new Guid("abd5c0d3-a45d-490a-b26d-d503b6a82261"));

            migrationBuilder.DeleteData(
                table: "ProcessEquipmentType",
                keyColumn: "Id",
                keyValue: new Guid("abd5c0d3-a45d-490a-b26d-d503b6a82262"));

            migrationBuilder.DeleteData(
                table: "ProcessEquipmentType",
                keyColumn: "Id",
                keyValue: new Guid("abd5c0d3-a45d-490a-b26d-d503b6a82263"));

            migrationBuilder.DeleteData(
                table: "ProcessEquipmentType",
                keyColumn: "Id",
                keyValue: new Guid("abd5c0d3-a45d-490a-b26d-d503b6a82264"));

            migrationBuilder.DeleteData(
                table: "ProcessEquipmentType",
                keyColumn: "Id",
                keyValue: new Guid("abd5c0d3-a45d-490a-b26d-d503b6a82265"));

            migrationBuilder.DeleteData(
                table: "ProductionFaciliti",
                keyColumn: "Id",
                keyValue: new Guid("bbd5c0d3-a45d-490a-b26d-d503b6a82261"));

            migrationBuilder.DeleteData(
                table: "ProductionFaciliti",
                keyColumn: "Id",
                keyValue: new Guid("bbd5c0d3-a45d-490a-b26d-d503b6a82262"));

            migrationBuilder.DeleteData(
                table: "ProductionFaciliti",
                keyColumn: "Id",
                keyValue: new Guid("bbd5c0d3-a45d-490a-b26d-d503b6a82263"));

            migrationBuilder.DeleteData(
                table: "ProductionFaciliti",
                keyColumn: "Id",
                keyValue: new Guid("bbd5c0d3-a45d-490a-b26d-d503b6a82265"));

            migrationBuilder.DeleteData(
                table: "ProductionFaciliti",
                keyColumn: "Id",
                keyValue: new Guid("bbd5c0d3-a45d-490a-b26d-d503b6a82266"));

            migrationBuilder.AddColumn<Guid>(
                name: "EquipmentPlacementContractId",
                table: "ProductionFaciliti",
                type: "uniqueidentifier",
                nullable: true);

            migrationBuilder.AddColumn<Guid>(
                name: "EquipmentPlacementContractId",
                table: "ProcessEquipmentType",
                type: "uniqueidentifier",
                nullable: true);
        }
    }
}
