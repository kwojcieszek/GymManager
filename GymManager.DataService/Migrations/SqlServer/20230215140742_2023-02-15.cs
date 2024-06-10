#nullable disable

using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GymManager.DataService.Migrations.SqlServer
{
    public partial class _20230215 : Migration
    {
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                "PermissionsList",
                "PermissionListID",
                28);

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

        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                "Passes",
                "PassID",
                1,
                "DateAdded",
                new DateTime(2023, 2, 15, 15, 7, 41, 978, DateTimeKind.Local).AddTicks(8509));

            migrationBuilder.UpdateData(
                "Passes",
                "PassID",
                2,
                "DateAdded",
                new DateTime(2023, 2, 15, 15, 7, 41, 978, DateTimeKind.Local).AddTicks(8515));

            migrationBuilder.UpdateData(
                "Passes",
                "PassID",
                3,
                "DateAdded",
                new DateTime(2023, 2, 15, 15, 7, 41, 978, DateTimeKind.Local).AddTicks(8524));

            migrationBuilder.UpdateData(
                "Passes",
                "PassID",
                4,
                "DateAdded",
                new DateTime(2023, 2, 15, 15, 7, 41, 978, DateTimeKind.Local).AddTicks(8526));

            migrationBuilder.UpdateData(
                "Passes",
                "PassID",
                5,
                "DateAdded",
                new DateTime(2023, 2, 15, 15, 7, 41, 978, DateTimeKind.Local).AddTicks(8528));

            migrationBuilder.UpdateData(
                "Passes",
                "PassID",
                6,
                "DateAdded",
                new DateTime(2023, 2, 15, 15, 7, 41, 978, DateTimeKind.Local).AddTicks(8530));

            migrationBuilder.InsertData(
                "PermissionsList",
                new[] { "PermissionListID", "Name" },
                new object[] { 28, "PODGLĄD CZŁONKÓW" });

            migrationBuilder.UpdateData(
                "Taxes",
                "TaxID",
                1,
                "DateAdded",
                new DateTime(2023, 2, 15, 15, 7, 41, 978, DateTimeKind.Local).AddTicks(8479));

            migrationBuilder.UpdateData(
                "Taxes",
                "TaxID",
                2,
                "DateAdded",
                new DateTime(2023, 2, 15, 15, 7, 41, 978, DateTimeKind.Local).AddTicks(8482));

            migrationBuilder.UpdateData(
                "Taxes",
                "TaxID",
                3,
                "DateAdded",
                new DateTime(2023, 2, 15, 15, 7, 41, 978, DateTimeKind.Local).AddTicks(8483));

            migrationBuilder.UpdateData(
                "Taxes",
                "TaxID",
                4,
                "DateAdded",
                new DateTime(2023, 2, 15, 15, 7, 41, 978, DateTimeKind.Local).AddTicks(8484));

            migrationBuilder.UpdateData(
                "Users",
                "UserID",
                1,
                "DateAdded",
                new DateTime(2023, 2, 15, 15, 7, 41, 978, DateTimeKind.Local).AddTicks(8357));
        }
    }
}