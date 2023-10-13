#nullable disable

using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GymManager.Migrations
{
    public partial class _20220207 : Migration
    {
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                "FK_DataTrackings_Users_AddedBy",
                "DataTrackings");

            migrationBuilder.DropForeignKey(
                "FK_Users_Users_AddedBy",
                "Users");

            migrationBuilder.DropTable(
                "Photos");

            migrationBuilder.DropIndex(
                "IX_Users_AddedBy",
                "Users");

            migrationBuilder.DropIndex(
                "IX_Users_ModifiedBy",
                "Users");

            migrationBuilder.DropIndex(
                "IX_DataTrackings_AddedBy",
                "DataTrackings");

            migrationBuilder.DropColumn(
                "AddedBy",
                "DataTrackings");

            migrationBuilder.DropColumn(
                "PrimaryKey",
                "DataTrackings");

            migrationBuilder.DropColumn(
                "ColumnName",
                "DataTrackingDefinitions");

            migrationBuilder.RenameColumn(
                "EntryRegistryID",
                "EntriesRegistry",
                "EntryRegisterID");

            migrationBuilder.AddColumn<byte[]>(
                "Photo",
                "Members",
                "varbinary(max)",
                nullable: true);

            migrationBuilder.UpdateData(
                "DataTrackingOperations",
                "DataTrackingOperationID",
                1,
                "Name",
                "Dodanie");

            migrationBuilder.UpdateData(
                "DataTrackingOperations",
                "DataTrackingOperationID",
                2,
                "Name",
                "Edyja");

            migrationBuilder.UpdateData(
                "DataTrackingOperations",
                "DataTrackingOperationID",
                3,
                "Name",
                "Usuwanie");

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
                "IX_Users_ModifiedBy",
                "Users",
                "ModifiedBy",
                unique: true,
                filter: "[ModifiedBy] IS NOT NULL");
        }

        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                "IX_Users_ModifiedBy",
                "Users");

            migrationBuilder.DropColumn(
                "Photo",
                "Members");

            migrationBuilder.RenameColumn(
                "EntryRegisterID",
                "EntriesRegistry",
                "EntryRegistryID");

            migrationBuilder.AddColumn<int>(
                "AddedBy",
                "DataTrackings",
                "int",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                "PrimaryKey",
                "DataTrackings",
                "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                "ColumnName",
                "DataTrackingDefinitions",
                "nvarchar(max)",
                nullable: true);

            migrationBuilder.CreateTable(
                "Photos",
                table => new
                {
                    PhotoID = table.Column<int>("int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MemberID = table.Column<int>("int", nullable: false),
                    Data = table.Column<byte[]>("varbinary(max)", nullable: true),
                    DateAdded = table.Column<DateTime>("datetime2", nullable: false),
                    DateModified = table.Column<DateTime>("datetime2", nullable: true),
                    AddedBy = table.Column<int>("int", nullable: true),
                    ModifiedBy = table.Column<int>("int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Photos", x => x.PhotoID);

                    table.ForeignKey(
                        "FK_Photos_Members_MemberID",
                        x => x.MemberID,
                        "Members",
                        "MemberID",
                        onDelete: ReferentialAction.Cascade);

                    table.ForeignKey(
                        "FK_Photos_Users_AddedBy",
                        x => x.AddedBy,
                        "Users",
                        "UserID");

                    table.ForeignKey(
                        "FK_Photos_Users_ModifiedBy",
                        x => x.ModifiedBy,
                        "Users",
                        "UserID");
                });

            migrationBuilder.UpdateData(
                "DataTrackingOperations",
                "DataTrackingOperationID",
                1,
                "Name",
                "DODAWANIE");

            migrationBuilder.UpdateData(
                "DataTrackingOperations",
                "DataTrackingOperationID",
                2,
                "Name",
                "EDYTOWANIE");

            migrationBuilder.UpdateData(
                "DataTrackingOperations",
                "DataTrackingOperationID",
                3,
                "Name",
                "USUWANIE");

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

            migrationBuilder.CreateIndex(
                "IX_Users_AddedBy",
                "Users",
                "AddedBy");

            migrationBuilder.CreateIndex(
                "IX_Users_ModifiedBy",
                "Users",
                "ModifiedBy");

            migrationBuilder.CreateIndex(
                "IX_DataTrackings_AddedBy",
                "DataTrackings",
                "AddedBy");

            migrationBuilder.CreateIndex(
                "IX_Photos_AddedBy",
                "Photos",
                "AddedBy");

            migrationBuilder.CreateIndex(
                "IX_Photos_MemberID",
                "Photos",
                "MemberID");

            migrationBuilder.CreateIndex(
                "IX_Photos_ModifiedBy",
                "Photos",
                "ModifiedBy");

            migrationBuilder.AddForeignKey(
                "FK_DataTrackings_Users_AddedBy",
                "DataTrackings",
                "AddedBy",
                "Users",
                principalColumn: "UserID");

            migrationBuilder.AddForeignKey(
                "FK_Users_Users_AddedBy",
                "Users",
                "AddedBy",
                "Users",
                principalColumn: "UserID");
        }
    }
}