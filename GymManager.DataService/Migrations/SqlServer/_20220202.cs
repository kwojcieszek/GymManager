#nullable disable

using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GymManager.DataService.Migrations.SqlServer
{
    public partial class _20220202 : Migration
    {
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                "FK_EntriesRegistry_Passes_PassID",
                "EntriesRegistry");

            migrationBuilder.DropIndex(
                "IX_EntriesRegistry_PassID",
                "EntriesRegistry");

            migrationBuilder.DropColumn(
                "PassID",
                "EntriesRegistry");

            migrationBuilder.DropColumn(
                "LastUsedDate",
                "CabinetKeys");

            migrationBuilder.UpdateData(
                "Passes",
                "PassID",
                1,
                "DateAdded",
                new DateTime(2022, 1, 29, 12, 48, 14, 862, DateTimeKind.Local).AddTicks(2214));

            migrationBuilder.UpdateData(
                "Passes",
                "PassID",
                2,
                "DateAdded",
                new DateTime(2022, 1, 29, 12, 48, 14, 862, DateTimeKind.Local).AddTicks(2220));

            migrationBuilder.UpdateData(
                "Passes",
                "PassID",
                3,
                "DateAdded",
                new DateTime(2022, 1, 29, 12, 48, 14, 862, DateTimeKind.Local).AddTicks(2228));

            migrationBuilder.UpdateData(
                "Passes",
                "PassID",
                4,
                "DateAdded",
                new DateTime(2022, 1, 29, 12, 48, 14, 862, DateTimeKind.Local).AddTicks(2230));

            migrationBuilder.UpdateData(
                "Passes",
                "PassID",
                5,
                "DateAdded",
                new DateTime(2022, 1, 29, 12, 48, 14, 862, DateTimeKind.Local).AddTicks(2233));

            migrationBuilder.UpdateData(
                "Passes",
                "PassID",
                6,
                "DateAdded",
                new DateTime(2022, 1, 29, 12, 48, 14, 862, DateTimeKind.Local).AddTicks(2235));

            migrationBuilder.UpdateData(
                "Taxes",
                "TaxID",
                1,
                "DateAdded",
                new DateTime(2022, 1, 29, 12, 48, 14, 862, DateTimeKind.Local).AddTicks(2172));

            migrationBuilder.UpdateData(
                "Taxes",
                "TaxID",
                2,
                "DateAdded",
                new DateTime(2022, 1, 29, 12, 48, 14, 862, DateTimeKind.Local).AddTicks(2176));

            migrationBuilder.UpdateData(
                "Taxes",
                "TaxID",
                3,
                "DateAdded",
                new DateTime(2022, 1, 29, 12, 48, 14, 862, DateTimeKind.Local).AddTicks(2178));

            migrationBuilder.UpdateData(
                "Taxes",
                "TaxID",
                4,
                "DateAdded",
                new DateTime(2022, 1, 29, 12, 48, 14, 862, DateTimeKind.Local).AddTicks(2180));

            migrationBuilder.UpdateData(
                "Users",
                "UserID",
                1,
                "DateAdded",
                new DateTime(2022, 1, 29, 12, 48, 14, 862, DateTimeKind.Local).AddTicks(2031));
        }

        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                "PassID",
                "EntriesRegistry",
                "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                "LastUsedDate",
                "CabinetKeys",
                "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.UpdateData(
                "Passes",
                "PassID",
                1,
                "DateAdded",
                new DateTime(2022, 2, 2, 16, 20, 27, 927, DateTimeKind.Local).AddTicks(6919));

            migrationBuilder.UpdateData(
                "Passes",
                "PassID",
                2,
                "DateAdded",
                new DateTime(2022, 2, 2, 16, 20, 27, 927, DateTimeKind.Local).AddTicks(6924));

            migrationBuilder.UpdateData(
                "Passes",
                "PassID",
                3,
                "DateAdded",
                new DateTime(2022, 2, 2, 16, 20, 27, 927, DateTimeKind.Local).AddTicks(6932));

            migrationBuilder.UpdateData(
                "Passes",
                "PassID",
                4,
                "DateAdded",
                new DateTime(2022, 2, 2, 16, 20, 27, 927, DateTimeKind.Local).AddTicks(6935));

            migrationBuilder.UpdateData(
                "Passes",
                "PassID",
                5,
                "DateAdded",
                new DateTime(2022, 2, 2, 16, 20, 27, 927, DateTimeKind.Local).AddTicks(6938));

            migrationBuilder.UpdateData(
                "Passes",
                "PassID",
                6,
                "DateAdded",
                new DateTime(2022, 2, 2, 16, 20, 27, 927, DateTimeKind.Local).AddTicks(6941));

            migrationBuilder.UpdateData(
                "Taxes",
                "TaxID",
                1,
                "DateAdded",
                new DateTime(2022, 2, 2, 16, 20, 27, 927, DateTimeKind.Local).AddTicks(6878));

            migrationBuilder.UpdateData(
                "Taxes",
                "TaxID",
                2,
                "DateAdded",
                new DateTime(2022, 2, 2, 16, 20, 27, 927, DateTimeKind.Local).AddTicks(6882));

            migrationBuilder.UpdateData(
                "Taxes",
                "TaxID",
                3,
                "DateAdded",
                new DateTime(2022, 2, 2, 16, 20, 27, 927, DateTimeKind.Local).AddTicks(6884));

            migrationBuilder.UpdateData(
                "Taxes",
                "TaxID",
                4,
                "DateAdded",
                new DateTime(2022, 2, 2, 16, 20, 27, 927, DateTimeKind.Local).AddTicks(6886));

            migrationBuilder.UpdateData(
                "Users",
                "UserID",
                1,
                "DateAdded",
                new DateTime(2022, 2, 2, 16, 20, 27, 927, DateTimeKind.Local).AddTicks(6727));

            migrationBuilder.CreateIndex(
                "IX_EntriesRegistry_PassID",
                "EntriesRegistry",
                "PassID");

            migrationBuilder.AddForeignKey(
                "FK_EntriesRegistry_Passes_PassID",
                "EntriesRegistry",
                "PassID",
                "Passes",
                principalColumn: "PassID");
        }
    }
}