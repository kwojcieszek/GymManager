#nullable disable

using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GymManager.Migrations
{
    public partial class _20220209 : Migration
    {
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                "PermissionsUsers");

            migrationBuilder.DropTable(
                "PermissionsList");

            migrationBuilder.UpdateData(
                "Passes",
                "PassID",
                1,
                "DateAdded",
                new DateTime(2022, 2, 7, 21, 21, 6, 253, DateTimeKind.Local).AddTicks(2075));

            migrationBuilder.UpdateData(
                "Passes",
                "PassID",
                2,
                "DateAdded",
                new DateTime(2022, 2, 7, 21, 21, 6, 253, DateTimeKind.Local).AddTicks(2080));

            migrationBuilder.UpdateData(
                "Passes",
                "PassID",
                3,
                "DateAdded",
                new DateTime(2022, 2, 7, 21, 21, 6, 253, DateTimeKind.Local).AddTicks(2088));

            migrationBuilder.UpdateData(
                "Passes",
                "PassID",
                4,
                "DateAdded",
                new DateTime(2022, 2, 7, 21, 21, 6, 253, DateTimeKind.Local).AddTicks(2091));

            migrationBuilder.UpdateData(
                "Passes",
                "PassID",
                5,
                "DateAdded",
                new DateTime(2022, 2, 7, 21, 21, 6, 253, DateTimeKind.Local).AddTicks(2093));

            migrationBuilder.UpdateData(
                "Passes",
                "PassID",
                6,
                "DateAdded",
                new DateTime(2022, 2, 7, 21, 21, 6, 253, DateTimeKind.Local).AddTicks(2096));

            migrationBuilder.UpdateData(
                "Taxes",
                "TaxID",
                1,
                "DateAdded",
                new DateTime(2022, 2, 7, 21, 21, 6, 253, DateTimeKind.Local).AddTicks(2038));

            migrationBuilder.UpdateData(
                "Taxes",
                "TaxID",
                2,
                "DateAdded",
                new DateTime(2022, 2, 7, 21, 21, 6, 253, DateTimeKind.Local).AddTicks(2042));

            migrationBuilder.UpdateData(
                "Taxes",
                "TaxID",
                3,
                "DateAdded",
                new DateTime(2022, 2, 7, 21, 21, 6, 253, DateTimeKind.Local).AddTicks(2044));

            migrationBuilder.UpdateData(
                "Taxes",
                "TaxID",
                4,
                "DateAdded",
                new DateTime(2022, 2, 7, 21, 21, 6, 253, DateTimeKind.Local).AddTicks(2046));

            migrationBuilder.UpdateData(
                "Users",
                "UserID",
                1,
                "DateAdded",
                new DateTime(2022, 2, 7, 21, 21, 6, 253, DateTimeKind.Local).AddTicks(1888));
        }

        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                "PermissionsList",
                table => new
                {
                    PermissionListID = table.Column<int>("int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>("nvarchar(450)", nullable: false)
                },
                constraints: table => { table.PrimaryKey("PK_PermissionsList", x => x.PermissionListID); });

            migrationBuilder.CreateTable(
                "PermissionsUsers",
                table => new
                {
                    PermissionUserID = table.Column<int>("int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PermissionListID = table.Column<int>("int", nullable: false),
                    UserID = table.Column<int>("int", nullable: false),
                    DateAdded = table.Column<DateTime>("datetime2", nullable: false),
                    AddedBy = table.Column<int>("int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PermissionsUsers", x => x.PermissionUserID);

                    table.ForeignKey(
                        "FK_PermissionsUsers_PermissionsList_PermissionListID",
                        x => x.PermissionListID,
                        "PermissionsList",
                        "PermissionListID",
                        onDelete: ReferentialAction.Cascade);

                    table.ForeignKey(
                        "FK_PermissionsUsers_Users_AddedBy",
                        x => x.AddedBy,
                        "Users",
                        "UserID");

                    table.ForeignKey(
                        "FK_PermissionsUsers_Users_UserID",
                        x => x.UserID,
                        "Users",
                        "UserID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                "Passes",
                "PassID",
                1,
                "DateAdded",
                new DateTime(2022, 2, 9, 11, 12, 11, 733, DateTimeKind.Local).AddTicks(207));

            migrationBuilder.UpdateData(
                "Passes",
                "PassID",
                2,
                "DateAdded",
                new DateTime(2022, 2, 9, 11, 12, 11, 733, DateTimeKind.Local).AddTicks(212));

            migrationBuilder.UpdateData(
                "Passes",
                "PassID",
                3,
                "DateAdded",
                new DateTime(2022, 2, 9, 11, 12, 11, 733, DateTimeKind.Local).AddTicks(222));

            migrationBuilder.UpdateData(
                "Passes",
                "PassID",
                4,
                "DateAdded",
                new DateTime(2022, 2, 9, 11, 12, 11, 733, DateTimeKind.Local).AddTicks(224));

            migrationBuilder.UpdateData(
                "Passes",
                "PassID",
                5,
                "DateAdded",
                new DateTime(2022, 2, 9, 11, 12, 11, 733, DateTimeKind.Local).AddTicks(227));

            migrationBuilder.UpdateData(
                "Passes",
                "PassID",
                6,
                "DateAdded",
                new DateTime(2022, 2, 9, 11, 12, 11, 733, DateTimeKind.Local).AddTicks(229));

            migrationBuilder.InsertData(
                "PermissionsList",
                new[] { "PermissionListID", "Name" },
                new object[,]
                {
                    { 1, "DOSTĘP CZŁONKOWIE" },
                    { 2, "DODAWANIE CZŁONKÓW" },
                    { 3, "EDYCJA CZŁONKÓW" },
                    { 4, "USWANIE CZŁONKÓW" },
                    { 5, "DOSTĘP KARNETY CZŁONKOW" },
                    { 6, "DODAWANIE KARNETÓW CZŁONKÓW" },
                    { 7, "EDYCJA KARNETÓW CZŁONKÓW" },
                    { 8, "USWANIE KARNETÓW CZŁONKÓW" },
                    { 9, "DOSTĘP KLCUZE" },
                    { 10, "DODAWANIE KLUCZY" },
                    { 11, "EDYCJA KLUCZY" },
                    { 12, "USWANIE KLUCZY" },
                    { 13, "DOSTĘP KARNETY" },
                    { 14, "DODAWANIE KARNETÓW" },
                    { 15, "EDYCJA KARNETÓW" },
                    { 16, "USWANIE KARNETÓW" },
                    { 17, "DOSTĘP UŻYTKOWNICY" },
                    { 18, "DODAWANIE UŻYTKOWNKÓW" },
                    { 19, "EDYCJA UŻYTKOWNKÓW" },
                    { 20, "USWANIE UŻYTKOWNKÓW" },
                    { 21, "DOSTĘP OSOBY W OBIEKCIE" },
                    { 22, "DOSTĘP WIADOMOŚCI" },
                    { 23, "DOSTĘP REJESTR WEJŚĆ" },
                    { 24, "DOSTĘP REJESTR OPERACJI" },
                    { 25, "DOSTĘP USTAWIENIA" }
                });

            migrationBuilder.UpdateData(
                "Taxes",
                "TaxID",
                1,
                "DateAdded",
                new DateTime(2022, 2, 9, 11, 12, 11, 733, DateTimeKind.Local).AddTicks(171));

            migrationBuilder.UpdateData(
                "Taxes",
                "TaxID",
                2,
                "DateAdded",
                new DateTime(2022, 2, 9, 11, 12, 11, 733, DateTimeKind.Local).AddTicks(174));

            migrationBuilder.UpdateData(
                "Taxes",
                "TaxID",
                3,
                "DateAdded",
                new DateTime(2022, 2, 9, 11, 12, 11, 733, DateTimeKind.Local).AddTicks(176));

            migrationBuilder.UpdateData(
                "Taxes",
                "TaxID",
                4,
                "DateAdded",
                new DateTime(2022, 2, 9, 11, 12, 11, 733, DateTimeKind.Local).AddTicks(178));

            migrationBuilder.UpdateData(
                "Users",
                "UserID",
                1,
                "DateAdded",
                new DateTime(2022, 2, 9, 11, 12, 11, 733, DateTimeKind.Local).AddTicks(28));

            migrationBuilder.CreateIndex(
                "IX_PermissionsList_Name",
                "PermissionsList",
                "Name");

            migrationBuilder.CreateIndex(
                "IX_PermissionsUsers_AddedBy",
                "PermissionsUsers",
                "AddedBy");

            migrationBuilder.CreateIndex(
                "IX_PermissionsUsers_PermissionListID",
                "PermissionsUsers",
                "PermissionListID");

            migrationBuilder.CreateIndex(
                "IX_PermissionsUsers_UserID",
                "PermissionsUsers",
                "UserID");
        }
    }
}