﻿using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace SmartTestProj.DAL.Migrations
{
    /// <inheritdoc />
    public partial class initwithdata : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "AspNetRoles",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUsers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedUserName = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    Email = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    NormalizedEmail = table.Column<string>(type: "nvarchar(256)", maxLength: 256, nullable: true),
                    EmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    PasswordHash = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    PhoneNumberConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    TwoFactorEnabled = table.Column<bool>(type: "bit", nullable: false),
                    LockoutEnd = table.Column<DateTimeOffset>(type: "datetimeoffset", nullable: true),
                    LockoutEnabled = table.Column<bool>(type: "bit", nullable: false),
                    AccessFailedCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUsers", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProcessEquipmentType",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Area = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProcessEquipmentType", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ProductionFaciliti",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    StandartArea = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProductionFaciliti", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "AspNetRoleClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetRoleClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetRoleClaims_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserClaims",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ClaimType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ClaimValue = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserClaims", x => x.Id);
                    table.ForeignKey(
                        name: "FK_AspNetUserClaims_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserLogins",
                columns: table => new
                {
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderKey = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    ProviderDisplayName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserLogins", x => new { x.LoginProvider, x.ProviderKey });
                    table.ForeignKey(
                        name: "FK_AspNetUserLogins_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserRoles",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    RoleId = table.Column<string>(type: "nvarchar(450)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetRoles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "AspNetRoles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_AspNetUserRoles_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "AspNetUserTokens",
                columns: table => new
                {
                    UserId = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    LoginProvider = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    Value = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AspNetUserTokens", x => new { x.UserId, x.LoginProvider, x.Name });
                    table.ForeignKey(
                        name: "FK_AspNetUserTokens_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EquipmentPlacementContract",
                columns: table => new
                {
                    ProductionFacilityId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ProcessEquipmentTypeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    UnitsCount = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EquipmentPlacementContract", x => new { x.ProductionFacilityId, x.ProcessEquipmentTypeId });
                    table.ForeignKey(
                        name: "FK_EquipmentPlacementContract_ProcessEquipmentType_ProcessEquipmentTypeId",
                        column: x => x.ProcessEquipmentTypeId,
                        principalTable: "ProcessEquipmentType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EquipmentPlacementContract_ProductionFaciliti_ProductionFacilityId",
                        column: x => x.ProductionFacilityId,
                        principalTable: "ProductionFaciliti",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

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
                    { new Guid("bbd5c0d3-a45d-490a-b26d-d503b6a82266"), "Hangar 6", 150 },
                    { new Guid("bbd5c0d3-a45d-490a-b26d-d503b6a82267"), "Hangar 7", 130 },
                    { new Guid("bbd5c0d3-a45d-490a-b26d-d503b6a82268"), "Hangar 8", 190 },
                    { new Guid("bbd5c0d3-a45d-490a-b26d-d503b6a82269"), "Hangar 9", 200 },
                    { new Guid("bbd5c0d3-a45d-490a-b26d-d503b6a82270"), "Hangar 10", 150 }
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

            migrationBuilder.CreateIndex(
                name: "IX_AspNetRoleClaims_RoleId",
                table: "AspNetRoleClaims",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "RoleNameIndex",
                table: "AspNetRoles",
                column: "NormalizedName",
                unique: true,
                filter: "[NormalizedName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserClaims_UserId",
                table: "AspNetUserClaims",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserLogins_UserId",
                table: "AspNetUserLogins",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_AspNetUserRoles_RoleId",
                table: "AspNetUserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "EmailIndex",
                table: "AspNetUsers",
                column: "NormalizedEmail");

            migrationBuilder.CreateIndex(
                name: "UserNameIndex",
                table: "AspNetUsers",
                column: "NormalizedUserName",
                unique: true,
                filter: "[NormalizedUserName] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_EquipmentPlacementContract_ProcessEquipmentTypeId",
                table: "EquipmentPlacementContract",
                column: "ProcessEquipmentTypeId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_EquipmentPlacementContract_ProductionFacilityId",
                table: "EquipmentPlacementContract",
                column: "ProductionFacilityId",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AspNetRoleClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserClaims");

            migrationBuilder.DropTable(
                name: "AspNetUserLogins");

            migrationBuilder.DropTable(
                name: "AspNetUserRoles");

            migrationBuilder.DropTable(
                name: "AspNetUserTokens");

            migrationBuilder.DropTable(
                name: "EquipmentPlacementContract");

            migrationBuilder.DropTable(
                name: "AspNetRoles");

            migrationBuilder.DropTable(
                name: "AspNetUsers");

            migrationBuilder.DropTable(
                name: "ProcessEquipmentType");

            migrationBuilder.DropTable(
                name: "ProductionFaciliti");
        }
    }
}
