#nullable disable

using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GymManager.DataService.Migrations.SqlServer
{
    public partial class _20220129 : Migration
    {
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                "FK_CabinetKeys_Genders_GenderID",
                "CabinetKeys");

            migrationBuilder.DropForeignKey(
                "FK_Members_Genders_GenderID",
                "Members");

            migrationBuilder.DropTable(
                "Genders");

            migrationBuilder.DropIndex(
                "IX_Members_GenderID",
                "Members");

            migrationBuilder.DropIndex(
                "IX_CabinetKeys_GenderID",
                "CabinetKeys");

            migrationBuilder.DropColumn(
                "GenderID",
                "Members");

            migrationBuilder.DropColumn(
                "GenderID",
                "CabinetKeys");

            migrationBuilder.UpdateData(
                "Passes",
                "PassID",
                1,
                "DateAdded",
                new DateTime(2022, 1, 28, 14, 44, 46, 241, DateTimeKind.Local).AddTicks(4021));

            migrationBuilder.UpdateData(
                "Passes",
                "PassID",
                2,
                "DateAdded",
                new DateTime(2022, 1, 28, 14, 44, 46, 241, DateTimeKind.Local).AddTicks(4028));

            migrationBuilder.UpdateData(
                "Passes",
                "PassID",
                3,
                "DateAdded",
                new DateTime(2022, 1, 28, 14, 44, 46, 241, DateTimeKind.Local).AddTicks(4036));

            migrationBuilder.UpdateData(
                "Passes",
                "PassID",
                4,
                "DateAdded",
                new DateTime(2022, 1, 28, 14, 44, 46, 241, DateTimeKind.Local).AddTicks(4039));

            migrationBuilder.UpdateData(
                "Passes",
                "PassID",
                5,
                "DateAdded",
                new DateTime(2022, 1, 28, 14, 44, 46, 241, DateTimeKind.Local).AddTicks(4041));

            migrationBuilder.UpdateData(
                "Passes",
                "PassID",
                6,
                "DateAdded",
                new DateTime(2022, 1, 28, 14, 44, 46, 241, DateTimeKind.Local).AddTicks(4045));

            migrationBuilder.UpdateData(
                "Taxes",
                "TaxID",
                1,
                "DateAdded",
                new DateTime(2022, 1, 28, 14, 44, 46, 241, DateTimeKind.Local).AddTicks(3978));

            migrationBuilder.UpdateData(
                "Taxes",
                "TaxID",
                2,
                "DateAdded",
                new DateTime(2022, 1, 28, 14, 44, 46, 241, DateTimeKind.Local).AddTicks(3981));

            migrationBuilder.UpdateData(
                "Taxes",
                "TaxID",
                3,
                "DateAdded",
                new DateTime(2022, 1, 28, 14, 44, 46, 241, DateTimeKind.Local).AddTicks(3983));

            migrationBuilder.UpdateData(
                "Taxes",
                "TaxID",
                4,
                "DateAdded",
                new DateTime(2022, 1, 28, 14, 44, 46, 241, DateTimeKind.Local).AddTicks(3985));

            migrationBuilder.UpdateData(
                "Users",
                "UserID",
                1,
                "DateAdded",
                new DateTime(2022, 1, 28, 14, 44, 46, 241, DateTimeKind.Local).AddTicks(3811));
        }

        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                "GenderID",
                "Members",
                "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                "GenderID",
                "CabinetKeys",
                "int",
                nullable: true);

            migrationBuilder.CreateTable(
                "Genders",
                table => new
                {
                    GenderID = table.Column<int>("int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>("nvarchar(450)", nullable: false)
                },
                constraints: table => { table.PrimaryKey("PK_Genders", x => x.GenderID); });

            migrationBuilder.InsertData(
                "Genders",
                new[] { "GenderID", "Name" },
                new object[,]
                {
                    { 1, "NIE PODANO" },
                    { 2, "MĘŻCZYZNA" },
                    { 3, "KOBIETA" }
                });

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

            migrationBuilder.CreateIndex(
                "IX_Members_GenderID",
                "Members",
                "GenderID");

            migrationBuilder.CreateIndex(
                "IX_CabinetKeys_GenderID",
                "CabinetKeys",
                "GenderID");

            migrationBuilder.CreateIndex(
                "IX_Genders_Name",
                "Genders",
                "Name",
                unique: true);

            migrationBuilder.AddForeignKey(
                "FK_CabinetKeys_Genders_GenderID",
                "CabinetKeys",
                "GenderID",
                "Genders",
                principalColumn: "GenderID");

            migrationBuilder.AddForeignKey(
                "FK_Members_Genders_GenderID",
                "Members",
                "GenderID",
                "Genders",
                principalColumn: "GenderID");
        }
    }
}