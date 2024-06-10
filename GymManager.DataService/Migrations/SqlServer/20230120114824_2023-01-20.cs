#nullable disable

using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GymManager.DataService.Migrations.SqlServer
{
    public partial class _20230120 : Migration
    {
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                "PassTimes",
                "PassTimeID",
                99);

            migrationBuilder.DropColumn(
                "PassTimeDays",
                "Passes");

            migrationBuilder.UpdateData(
                "Passes",
                "PassID",
                1,
                "DateAdded",
                new DateTime(2022, 11, 30, 10, 41, 22, 813, DateTimeKind.Local).AddTicks(4374));

            migrationBuilder.UpdateData(
                "Passes",
                "PassID",
                2,
                "DateAdded",
                new DateTime(2022, 11, 30, 10, 41, 22, 813, DateTimeKind.Local).AddTicks(4378));

            migrationBuilder.UpdateData(
                "Passes",
                "PassID",
                3,
                "DateAdded",
                new DateTime(2022, 11, 30, 10, 41, 22, 813, DateTimeKind.Local).AddTicks(4384));

            migrationBuilder.UpdateData(
                "Passes",
                "PassID",
                4,
                "DateAdded",
                new DateTime(2022, 11, 30, 10, 41, 22, 813, DateTimeKind.Local).AddTicks(4386));

            migrationBuilder.UpdateData(
                "Passes",
                "PassID",
                5,
                "DateAdded",
                new DateTime(2022, 11, 30, 10, 41, 22, 813, DateTimeKind.Local).AddTicks(4387));

            migrationBuilder.UpdateData(
                "Passes",
                "PassID",
                6,
                "DateAdded",
                new DateTime(2022, 11, 30, 10, 41, 22, 813, DateTimeKind.Local).AddTicks(4389));

            migrationBuilder.UpdateData(
                "Taxes",
                "TaxID",
                1,
                "DateAdded",
                new DateTime(2022, 11, 30, 10, 41, 22, 813, DateTimeKind.Local).AddTicks(4344));

            migrationBuilder.UpdateData(
                "Taxes",
                "TaxID",
                2,
                "DateAdded",
                new DateTime(2022, 11, 30, 10, 41, 22, 813, DateTimeKind.Local).AddTicks(4346));

            migrationBuilder.UpdateData(
                "Taxes",
                "TaxID",
                3,
                "DateAdded",
                new DateTime(2022, 11, 30, 10, 41, 22, 813, DateTimeKind.Local).AddTicks(4347));

            migrationBuilder.UpdateData(
                "Taxes",
                "TaxID",
                4,
                "DateAdded",
                new DateTime(2022, 11, 30, 10, 41, 22, 813, DateTimeKind.Local).AddTicks(4349));

            migrationBuilder.UpdateData(
                "Users",
                "UserID",
                1,
                "DateAdded",
                new DateTime(2022, 11, 30, 10, 41, 22, 813, DateTimeKind.Local).AddTicks(4228));
        }

        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                "PassTimeDays",
                "Passes",
                "int",
                nullable: true);

            migrationBuilder.InsertData(
                "PassTimes",
                new[] { "PassTimeID", "Name" },
                new object[] { 99, "Zdefiniowanych dni" });

            migrationBuilder.UpdateData(
                "Passes",
                "PassID",
                1,
                "DateAdded",
                new DateTime(2023, 1, 20, 12, 48, 24, 129, DateTimeKind.Local).AddTicks(1966));

            migrationBuilder.UpdateData(
                "Passes",
                "PassID",
                2,
                "DateAdded",
                new DateTime(2023, 1, 20, 12, 48, 24, 129, DateTimeKind.Local).AddTicks(1971));

            migrationBuilder.UpdateData(
                "Passes",
                "PassID",
                3,
                "DateAdded",
                new DateTime(2023, 1, 20, 12, 48, 24, 129, DateTimeKind.Local).AddTicks(1977));

            migrationBuilder.UpdateData(
                "Passes",
                "PassID",
                4,
                "DateAdded",
                new DateTime(2023, 1, 20, 12, 48, 24, 129, DateTimeKind.Local).AddTicks(1979));

            migrationBuilder.UpdateData(
                "Passes",
                "PassID",
                5,
                "DateAdded",
                new DateTime(2023, 1, 20, 12, 48, 24, 129, DateTimeKind.Local).AddTicks(1982));

            migrationBuilder.UpdateData(
                "Passes",
                "PassID",
                6,
                "DateAdded",
                new DateTime(2023, 1, 20, 12, 48, 24, 129, DateTimeKind.Local).AddTicks(1983));

            migrationBuilder.UpdateData(
                "Taxes",
                "TaxID",
                1,
                "DateAdded",
                new DateTime(2023, 1, 20, 12, 48, 24, 129, DateTimeKind.Local).AddTicks(1933));

            migrationBuilder.UpdateData(
                "Taxes",
                "TaxID",
                2,
                "DateAdded",
                new DateTime(2023, 1, 20, 12, 48, 24, 129, DateTimeKind.Local).AddTicks(1936));

            migrationBuilder.UpdateData(
                "Taxes",
                "TaxID",
                3,
                "DateAdded",
                new DateTime(2023, 1, 20, 12, 48, 24, 129, DateTimeKind.Local).AddTicks(1937));

            migrationBuilder.UpdateData(
                "Taxes",
                "TaxID",
                4,
                "DateAdded",
                new DateTime(2023, 1, 20, 12, 48, 24, 129, DateTimeKind.Local).AddTicks(1938));

            migrationBuilder.UpdateData(
                "Users",
                "UserID",
                1,
                "DateAdded",
                new DateTime(2023, 1, 20, 12, 48, 24, 129, DateTimeKind.Local).AddTicks(1820));
        }
    }
}