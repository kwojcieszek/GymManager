#nullable disable

using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GymManager.Migrations.SqlServer
{
    public partial class _20220301 : Migration
    {
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                "Companies");

            migrationBuilder.DropTable(
                "Employees");

            migrationBuilder.DropTable(
                "GymObjects");

            migrationBuilder.UpdateData(
                "Passes",
                "PassID",
                1,
                "DateAdded",
                new DateTime(2022, 2, 20, 9, 30, 13, 828, DateTimeKind.Local).AddTicks(5066));

            migrationBuilder.UpdateData(
                "Passes",
                "PassID",
                2,
                "DateAdded",
                new DateTime(2022, 2, 20, 9, 30, 13, 828, DateTimeKind.Local).AddTicks(5072));

            migrationBuilder.UpdateData(
                "Passes",
                "PassID",
                3,
                "DateAdded",
                new DateTime(2022, 2, 20, 9, 30, 13, 828, DateTimeKind.Local).AddTicks(5079));

            migrationBuilder.UpdateData(
                "Passes",
                "PassID",
                4,
                "DateAdded",
                new DateTime(2022, 2, 20, 9, 30, 13, 828, DateTimeKind.Local).AddTicks(5082));

            migrationBuilder.UpdateData(
                "Passes",
                "PassID",
                5,
                "DateAdded",
                new DateTime(2022, 2, 20, 9, 30, 13, 828, DateTimeKind.Local).AddTicks(5085));

            migrationBuilder.UpdateData(
                "Passes",
                "PassID",
                6,
                "DateAdded",
                new DateTime(2022, 2, 20, 9, 30, 13, 828, DateTimeKind.Local).AddTicks(5088));

            migrationBuilder.UpdateData(
                "Taxes",
                "TaxID",
                1,
                "DateAdded",
                new DateTime(2022, 2, 20, 9, 30, 13, 828, DateTimeKind.Local).AddTicks(5029));

            migrationBuilder.UpdateData(
                "Taxes",
                "TaxID",
                2,
                "DateAdded",
                new DateTime(2022, 2, 20, 9, 30, 13, 828, DateTimeKind.Local).AddTicks(5033));

            migrationBuilder.UpdateData(
                "Taxes",
                "TaxID",
                3,
                "DateAdded",
                new DateTime(2022, 2, 20, 9, 30, 13, 828, DateTimeKind.Local).AddTicks(5034));

            migrationBuilder.UpdateData(
                "Taxes",
                "TaxID",
                4,
                "DateAdded",
                new DateTime(2022, 2, 20, 9, 30, 13, 828, DateTimeKind.Local).AddTicks(5036));

            migrationBuilder.UpdateData(
                "Users",
                "UserID",
                1,
                "DateAdded",
                new DateTime(2022, 2, 20, 9, 30, 13, 828, DateTimeKind.Local).AddTicks(4875));
        }

        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                "Companies",
                table => new
                {
                    CompanyID = table.Column<int>("int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>("nvarchar(max)", nullable: true),
                    Street1 = table.Column<string>("nvarchar(50)", maxLength: 50, nullable: false),
                    Street2 = table.Column<string>("nvarchar(50)", maxLength: 50, nullable: false),
                    City = table.Column<string>("nvarchar(50)", maxLength: 50, nullable: false),
                    PostCode = table.Column<string>("nvarchar(50)", maxLength: 50, nullable: false),
                    TaxIdNumber = table.Column<string>("nvarchar(max)", nullable: true),
                    Phone = table.Column<string>("nvarchar(50)", maxLength: 50, nullable: true),
                    Email = table.Column<string>("nvarchar(50)", maxLength: 50, nullable: true),
                    DateAdded = table.Column<DateTime>("datetime2", nullable: false),
                    DateModified = table.Column<DateTime>("datetime2", nullable: true),
                    AddedBy = table.Column<int>("int", nullable: true),
                    ModifiedBy = table.Column<int>("int", nullable: true),
                    IsAcive = table.Column<bool>("bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Companies", x => x.CompanyID);

                    table.ForeignKey(
                        "FK_Companies_Users_AddedBy",
                        x => x.AddedBy,
                        "Users",
                        "UserID");

                    table.ForeignKey(
                        "FK_Companies_Users_ModifiedBy",
                        x => x.ModifiedBy,
                        "Users",
                        "UserID");
                });

            migrationBuilder.CreateTable(
                "Employees",
                table => new
                {
                    EmployeeID = table.Column<int>("int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Id = table.Column<string>("nvarchar(50)", maxLength: 50, nullable: false),
                    FirstName = table.Column<string>("nvarchar(50)", maxLength: 50, nullable: false),
                    LastName = table.Column<string>("nvarchar(50)", maxLength: 50, nullable: false),
                    Street1 = table.Column<string>("nvarchar(50)", maxLength: 50, nullable: false),
                    Street2 = table.Column<string>("nvarchar(50)", maxLength: 50, nullable: false),
                    City = table.Column<string>("nvarchar(50)", maxLength: 50, nullable: false),
                    PostCode = table.Column<string>("nvarchar(50)", maxLength: 50, nullable: false),
                    Phone = table.Column<string>("nvarchar(50)", maxLength: 50, nullable: true),
                    Pesel = table.Column<string>("nvarchar(50)", maxLength: 50, nullable: true),
                    BirthDate = table.Column<DateTime>("datetime2", nullable: true),
                    Email = table.Column<string>("nvarchar(50)", maxLength: 50, nullable: true),
                    DateAdded = table.Column<DateTime>("datetime2", nullable: false),
                    DateModified = table.Column<DateTime>("datetime2", nullable: true),
                    AddedBy = table.Column<int>("int", nullable: true),
                    ModifiedBy = table.Column<int>("int", nullable: true),
                    IsAcive = table.Column<bool>("bit", nullable: false),
                    GenderID = table.Column<int>("int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.EmployeeID);

                    table.ForeignKey(
                        "FK_Employees_Genders_GenderID",
                        x => x.GenderID,
                        "Genders",
                        "GenderID");

                    table.ForeignKey(
                        "FK_Employees_Users_AddedBy",
                        x => x.AddedBy,
                        "Users",
                        "UserID");

                    table.ForeignKey(
                        "FK_Employees_Users_ModifiedBy",
                        x => x.ModifiedBy,
                        "Users",
                        "UserID");
                });

            migrationBuilder.CreateTable(
                "GymObjects",
                table => new
                {
                    GymObjectID = table.Column<int>("int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>("nvarchar(max)", nullable: true),
                    Street1 = table.Column<string>("nvarchar(50)", maxLength: 50, nullable: false),
                    Street2 = table.Column<string>("nvarchar(50)", maxLength: 50, nullable: false),
                    City = table.Column<string>("nvarchar(50)", maxLength: 50, nullable: false),
                    PostCode = table.Column<string>("nvarchar(50)", maxLength: 50, nullable: false),
                    Phone = table.Column<string>("nvarchar(50)", maxLength: 50, nullable: true),
                    Email = table.Column<string>("nvarchar(50)", maxLength: 50, nullable: true),
                    DateAdded = table.Column<DateTime>("datetime2", nullable: false),
                    DateModified = table.Column<DateTime>("datetime2", nullable: true),
                    AddedBy = table.Column<int>("int", nullable: true),
                    ModifiedBy = table.Column<int>("int", nullable: true),
                    IsAcive = table.Column<bool>("bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GymObjects", x => x.GymObjectID);

                    table.ForeignKey(
                        "FK_GymObjects_Users_AddedBy",
                        x => x.AddedBy,
                        "Users",
                        "UserID");

                    table.ForeignKey(
                        "FK_GymObjects_Users_ModifiedBy",
                        x => x.ModifiedBy,
                        "Users",
                        "UserID");
                });

            migrationBuilder.UpdateData(
                "Passes",
                "PassID",
                1,
                "DateAdded",
                new DateTime(2022, 3, 1, 15, 38, 21, 135, DateTimeKind.Local).AddTicks(1543));

            migrationBuilder.UpdateData(
                "Passes",
                "PassID",
                2,
                "DateAdded",
                new DateTime(2022, 3, 1, 15, 38, 21, 135, DateTimeKind.Local).AddTicks(1549));

            migrationBuilder.UpdateData(
                "Passes",
                "PassID",
                3,
                "DateAdded",
                new DateTime(2022, 3, 1, 15, 38, 21, 135, DateTimeKind.Local).AddTicks(1558));

            migrationBuilder.UpdateData(
                "Passes",
                "PassID",
                4,
                "DateAdded",
                new DateTime(2022, 3, 1, 15, 38, 21, 135, DateTimeKind.Local).AddTicks(1561));

            migrationBuilder.UpdateData(
                "Passes",
                "PassID",
                5,
                "DateAdded",
                new DateTime(2022, 3, 1, 15, 38, 21, 135, DateTimeKind.Local).AddTicks(1563));

            migrationBuilder.UpdateData(
                "Passes",
                "PassID",
                6,
                "DateAdded",
                new DateTime(2022, 3, 1, 15, 38, 21, 135, DateTimeKind.Local).AddTicks(1566));

            migrationBuilder.UpdateData(
                "Taxes",
                "TaxID",
                1,
                "DateAdded",
                new DateTime(2022, 3, 1, 15, 38, 21, 135, DateTimeKind.Local).AddTicks(1503));

            migrationBuilder.UpdateData(
                "Taxes",
                "TaxID",
                2,
                "DateAdded",
                new DateTime(2022, 3, 1, 15, 38, 21, 135, DateTimeKind.Local).AddTicks(1507));

            migrationBuilder.UpdateData(
                "Taxes",
                "TaxID",
                3,
                "DateAdded",
                new DateTime(2022, 3, 1, 15, 38, 21, 135, DateTimeKind.Local).AddTicks(1509));

            migrationBuilder.UpdateData(
                "Taxes",
                "TaxID",
                4,
                "DateAdded",
                new DateTime(2022, 3, 1, 15, 38, 21, 135, DateTimeKind.Local).AddTicks(1510));

            migrationBuilder.UpdateData(
                "Users",
                "UserID",
                1,
                "DateAdded",
                new DateTime(2022, 3, 1, 15, 38, 21, 135, DateTimeKind.Local).AddTicks(1350));

            migrationBuilder.CreateIndex(
                "IX_Companies_AddedBy",
                "Companies",
                "AddedBy");

            migrationBuilder.CreateIndex(
                "IX_Companies_ModifiedBy",
                "Companies",
                "ModifiedBy");

            migrationBuilder.CreateIndex(
                "IX_Employees_AddedBy",
                "Employees",
                "AddedBy");

            migrationBuilder.CreateIndex(
                "IX_Employees_GenderID",
                "Employees",
                "GenderID");

            migrationBuilder.CreateIndex(
                "IX_Employees_Id",
                "Employees",
                "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                "IX_Employees_ModifiedBy",
                "Employees",
                "ModifiedBy");

            migrationBuilder.CreateIndex(
                "IX_GymObjects_AddedBy",
                "GymObjects",
                "AddedBy");

            migrationBuilder.CreateIndex(
                "IX_GymObjects_ModifiedBy",
                "GymObjects",
                "ModifiedBy");
        }
    }
}