#nullable disable

using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GymManager.DataService.Migrations.SqlServer
{
    public partial class _20240607 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "NoPeselNumber",
                table: "Members",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                table: "Passes",
                keyColumn: "PassID",
                keyValue: 1,
                column: "DateAdded",
                value: new DateTime(2024, 6, 7, 18, 24, 55, 551, DateTimeKind.Local).AddTicks(5343));

            migrationBuilder.UpdateData(
                table: "Passes",
                keyColumn: "PassID",
                keyValue: 2,
                column: "DateAdded",
                value: new DateTime(2024, 6, 7, 18, 24, 55, 551, DateTimeKind.Local).AddTicks(5349));

            migrationBuilder.UpdateData(
                table: "Passes",
                keyColumn: "PassID",
                keyValue: 3,
                column: "DateAdded",
                value: new DateTime(2024, 6, 7, 18, 24, 55, 551, DateTimeKind.Local).AddTicks(5356));

            migrationBuilder.UpdateData(
                table: "Passes",
                keyColumn: "PassID",
                keyValue: 4,
                column: "DateAdded",
                value: new DateTime(2024, 6, 7, 18, 24, 55, 551, DateTimeKind.Local).AddTicks(5357));

            migrationBuilder.UpdateData(
                table: "Passes",
                keyColumn: "PassID",
                keyValue: 5,
                column: "DateAdded",
                value: new DateTime(2024, 6, 7, 18, 24, 55, 551, DateTimeKind.Local).AddTicks(5359));

            migrationBuilder.UpdateData(
                table: "Passes",
                keyColumn: "PassID",
                keyValue: 6,
                column: "DateAdded",
                value: new DateTime(2024, 6, 7, 18, 24, 55, 551, DateTimeKind.Local).AddTicks(5361));

            migrationBuilder.UpdateData(
                table: "Taxes",
                keyColumn: "TaxID",
                keyValue: 1,
                column: "DateAdded",
                value: new DateTime(2024, 6, 7, 18, 24, 55, 551, DateTimeKind.Local).AddTicks(5305));

            migrationBuilder.UpdateData(
                table: "Taxes",
                keyColumn: "TaxID",
                keyValue: 2,
                column: "DateAdded",
                value: new DateTime(2024, 6, 7, 18, 24, 55, 551, DateTimeKind.Local).AddTicks(5308));

            migrationBuilder.UpdateData(
                table: "Taxes",
                keyColumn: "TaxID",
                keyValue: 3,
                column: "DateAdded",
                value: new DateTime(2024, 6, 7, 18, 24, 55, 551, DateTimeKind.Local).AddTicks(5310));

            migrationBuilder.UpdateData(
                table: "Taxes",
                keyColumn: "TaxID",
                keyValue: 4,
                column: "DateAdded",
                value: new DateTime(2024, 6, 7, 18, 24, 55, 551, DateTimeKind.Local).AddTicks(5311));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserID",
                keyValue: 1,
                column: "DateAdded",
                value: new DateTime(2024, 6, 7, 18, 24, 55, 551, DateTimeKind.Local).AddTicks(5188));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NoPeselNumber",
                table: "Members");

            migrationBuilder.UpdateData(
                table: "Passes",
                keyColumn: "PassID",
                keyValue: 1,
                column: "DateAdded",
                value: new DateTime(2023, 2, 15, 15, 7, 41, 978, DateTimeKind.Local).AddTicks(8509));

            migrationBuilder.UpdateData(
                table: "Passes",
                keyColumn: "PassID",
                keyValue: 2,
                column: "DateAdded",
                value: new DateTime(2023, 2, 15, 15, 7, 41, 978, DateTimeKind.Local).AddTicks(8515));

            migrationBuilder.UpdateData(
                table: "Passes",
                keyColumn: "PassID",
                keyValue: 3,
                column: "DateAdded",
                value: new DateTime(2023, 2, 15, 15, 7, 41, 978, DateTimeKind.Local).AddTicks(8524));

            migrationBuilder.UpdateData(
                table: "Passes",
                keyColumn: "PassID",
                keyValue: 4,
                column: "DateAdded",
                value: new DateTime(2023, 2, 15, 15, 7, 41, 978, DateTimeKind.Local).AddTicks(8526));

            migrationBuilder.UpdateData(
                table: "Passes",
                keyColumn: "PassID",
                keyValue: 5,
                column: "DateAdded",
                value: new DateTime(2023, 2, 15, 15, 7, 41, 978, DateTimeKind.Local).AddTicks(8528));

            migrationBuilder.UpdateData(
                table: "Passes",
                keyColumn: "PassID",
                keyValue: 6,
                column: "DateAdded",
                value: new DateTime(2023, 2, 15, 15, 7, 41, 978, DateTimeKind.Local).AddTicks(8530));

            migrationBuilder.UpdateData(
                table: "Taxes",
                keyColumn: "TaxID",
                keyValue: 1,
                column: "DateAdded",
                value: new DateTime(2023, 2, 15, 15, 7, 41, 978, DateTimeKind.Local).AddTicks(8479));

            migrationBuilder.UpdateData(
                table: "Taxes",
                keyColumn: "TaxID",
                keyValue: 2,
                column: "DateAdded",
                value: new DateTime(2023, 2, 15, 15, 7, 41, 978, DateTimeKind.Local).AddTicks(8482));

            migrationBuilder.UpdateData(
                table: "Taxes",
                keyColumn: "TaxID",
                keyValue: 3,
                column: "DateAdded",
                value: new DateTime(2023, 2, 15, 15, 7, 41, 978, DateTimeKind.Local).AddTicks(8483));

            migrationBuilder.UpdateData(
                table: "Taxes",
                keyColumn: "TaxID",
                keyValue: 4,
                column: "DateAdded",
                value: new DateTime(2023, 2, 15, 15, 7, 41, 978, DateTimeKind.Local).AddTicks(8484));

            migrationBuilder.UpdateData(
                table: "Users",
                keyColumn: "UserID",
                keyValue: 1,
                column: "DateAdded",
                value: new DateTime(2023, 2, 15, 15, 7, 41, 978, DateTimeKind.Local).AddTicks(8357));
        }
    }
}
