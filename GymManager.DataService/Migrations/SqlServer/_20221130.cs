#nullable disable

using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GymManager.DataService.Migrations.SqlServer
{
    public partial class _20221130 : Migration
    {
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.UpdateData(
                "Passes",
                "PassID",
                1,
                "DateAdded",
                new DateTime(2022, 7, 1, 12, 17, 57, 270, DateTimeKind.Local).AddTicks(3142));

            migrationBuilder.UpdateData(
                "Passes",
                "PassID",
                2,
                "DateAdded",
                new DateTime(2022, 7, 1, 12, 17, 57, 270, DateTimeKind.Local).AddTicks(3148));

            migrationBuilder.UpdateData(
                "Passes",
                "PassID",
                3,
                "DateAdded",
                new DateTime(2022, 7, 1, 12, 17, 57, 270, DateTimeKind.Local).AddTicks(3156));

            migrationBuilder.UpdateData(
                "Passes",
                "PassID",
                4,
                "DateAdded",
                new DateTime(2022, 7, 1, 12, 17, 57, 270, DateTimeKind.Local).AddTicks(3159));

            migrationBuilder.UpdateData(
                "Passes",
                "PassID",
                5,
                "DateAdded",
                new DateTime(2022, 7, 1, 12, 17, 57, 270, DateTimeKind.Local).AddTicks(3162));

            migrationBuilder.UpdateData(
                "Passes",
                "PassID",
                6,
                "DateAdded",
                new DateTime(2022, 7, 1, 12, 17, 57, 270, DateTimeKind.Local).AddTicks(3164));

            migrationBuilder.UpdateData(
                "Taxes",
                "TaxID",
                1,
                "DateAdded",
                new DateTime(2022, 7, 1, 12, 17, 57, 270, DateTimeKind.Local).AddTicks(3102));

            migrationBuilder.UpdateData(
                "Taxes",
                "TaxID",
                2,
                "DateAdded",
                new DateTime(2022, 7, 1, 12, 17, 57, 270, DateTimeKind.Local).AddTicks(3106));

            migrationBuilder.UpdateData(
                "Taxes",
                "TaxID",
                3,
                "DateAdded",
                new DateTime(2022, 7, 1, 12, 17, 57, 270, DateTimeKind.Local).AddTicks(3109));

            migrationBuilder.UpdateData(
                "Taxes",
                "TaxID",
                4,
                "DateAdded",
                new DateTime(2022, 7, 1, 12, 17, 57, 270, DateTimeKind.Local).AddTicks(3110));

            migrationBuilder.UpdateData(
                "Users",
                "UserID",
                1,
                "DateAdded",
                new DateTime(2022, 7, 1, 12, 17, 57, 270, DateTimeKind.Local).AddTicks(2963));
        }

        protected override void Up(MigrationBuilder migrationBuilder)
        {
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
    }
}