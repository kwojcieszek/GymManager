#nullable disable

using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GymManager.Migrations.Sqlite
{
    public partial class _20220210 : Migration
    {
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                "FK_Messages_MessageTypes_MessageTypeID",
                "Messages");

            migrationBuilder.DropTable(
                "MessageTypes");

            migrationBuilder.DropIndex(
                "IX_Messages_MessageTypeID",
                "Messages");

            migrationBuilder.DeleteData(
                "PermissionsList",
                "PermissionListID",
                26);

            migrationBuilder.DeleteData(
                "PermissionsList",
                "PermissionListID",
                27);

            migrationBuilder.DropColumn(
                "MessageTypeID",
                "Messages");

            migrationBuilder.DropColumn(
                "BirthDate",
                "Members");

            migrationBuilder.DropColumn(
                "Pesel",
                "Members");

            migrationBuilder.UpdateData(
                "Passes",
                "PassID",
                1,
                "DateAdded",
                new DateTime(2022, 2, 10, 18, 9, 8, 484, DateTimeKind.Local).AddTicks(5140));

            migrationBuilder.UpdateData(
                "Passes",
                "PassID",
                2,
                "DateAdded",
                new DateTime(2022, 2, 10, 18, 9, 8, 484, DateTimeKind.Local).AddTicks(5146));

            migrationBuilder.UpdateData(
                "Passes",
                "PassID",
                3,
                "DateAdded",
                new DateTime(2022, 2, 10, 18, 9, 8, 484, DateTimeKind.Local).AddTicks(5154));

            migrationBuilder.UpdateData(
                "Passes",
                "PassID",
                4,
                "DateAdded",
                new DateTime(2022, 2, 10, 18, 9, 8, 484, DateTimeKind.Local).AddTicks(5157));

            migrationBuilder.UpdateData(
                "Passes",
                "PassID",
                5,
                "DateAdded",
                new DateTime(2022, 2, 10, 18, 9, 8, 484, DateTimeKind.Local).AddTicks(5159));

            migrationBuilder.UpdateData(
                "Passes",
                "PassID",
                6,
                "DateAdded",
                new DateTime(2022, 2, 10, 18, 9, 8, 484, DateTimeKind.Local).AddTicks(5162));

            migrationBuilder.UpdateData(
                "Taxes",
                "TaxID",
                1,
                "DateAdded",
                new DateTime(2022, 2, 10, 18, 9, 8, 484, DateTimeKind.Local).AddTicks(5100));

            migrationBuilder.UpdateData(
                "Taxes",
                "TaxID",
                2,
                "DateAdded",
                new DateTime(2022, 2, 10, 18, 9, 8, 484, DateTimeKind.Local).AddTicks(5104));

            migrationBuilder.UpdateData(
                "Taxes",
                "TaxID",
                3,
                "DateAdded",
                new DateTime(2022, 2, 10, 18, 9, 8, 484, DateTimeKind.Local).AddTicks(5105));

            migrationBuilder.UpdateData(
                "Taxes",
                "TaxID",
                4,
                "DateAdded",
                new DateTime(2022, 2, 10, 18, 9, 8, 484, DateTimeKind.Local).AddTicks(5107));

            migrationBuilder.UpdateData(
                "Users",
                "UserID",
                1,
                "DateAdded",
                new DateTime(2022, 2, 10, 18, 9, 8, 484, DateTimeKind.Local).AddTicks(4951));
        }

        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                "MessageTypeID",
                "Messages",
                "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<DateTime>(
                "BirthDate",
                "Members",
                "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                "Pesel",
                "Members",
                "TEXT",
                maxLength: 50,
                nullable: true);

            migrationBuilder.CreateTable(
                "MessageTypes",
                table => new
                {
                    MessageTypeID = table.Column<int>("INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>("TEXT", nullable: false),
                    Message = table.Column<string>("TEXT", nullable: true),
                    IsEmail = table.Column<bool>("INTEGER", nullable: false),
                    IsSms = table.Column<bool>("INTEGER", nullable: false),
                    IsAcive = table.Column<bool>("INTEGER", nullable: false)
                },
                constraints: table => { table.PrimaryKey("PK_MessageTypes", x => x.MessageTypeID); });

            migrationBuilder.UpdateData(
                "Passes",
                "PassID",
                1,
                "DateAdded",
                new DateTime(2022, 2, 19, 15, 33, 29, 782, DateTimeKind.Local).AddTicks(6686));

            migrationBuilder.UpdateData(
                "Passes",
                "PassID",
                2,
                "DateAdded",
                new DateTime(2022, 2, 19, 15, 33, 29, 782, DateTimeKind.Local).AddTicks(6694));

            migrationBuilder.UpdateData(
                "Passes",
                "PassID",
                3,
                "DateAdded",
                new DateTime(2022, 2, 19, 15, 33, 29, 782, DateTimeKind.Local).AddTicks(6702));

            migrationBuilder.UpdateData(
                "Passes",
                "PassID",
                4,
                "DateAdded",
                new DateTime(2022, 2, 19, 15, 33, 29, 782, DateTimeKind.Local).AddTicks(6705));

            migrationBuilder.UpdateData(
                "Passes",
                "PassID",
                5,
                "DateAdded",
                new DateTime(2022, 2, 19, 15, 33, 29, 782, DateTimeKind.Local).AddTicks(6708));

            migrationBuilder.UpdateData(
                "Passes",
                "PassID",
                6,
                "DateAdded",
                new DateTime(2022, 2, 19, 15, 33, 29, 782, DateTimeKind.Local).AddTicks(6711));

            migrationBuilder.InsertData(
                "PermissionsList",
                new[] { "PermissionListID", "Name" },
                new object[] { 26, "ZAMYKANIE WEJŚCIA CZŁONKÓW W OBIEKCIE" });

            migrationBuilder.InsertData(
                "PermissionsList",
                new[] { "PermissionListID", "Name" },
                new object[] { 27, "DODAJ WEJŚCIE/WYJŚCIE BEZ IDENTYFIKATORA" });

            migrationBuilder.UpdateData(
                "Taxes",
                "TaxID",
                1,
                "DateAdded",
                new DateTime(2022, 2, 19, 15, 33, 29, 782, DateTimeKind.Local).AddTicks(6643));

            migrationBuilder.UpdateData(
                "Taxes",
                "TaxID",
                2,
                "DateAdded",
                new DateTime(2022, 2, 19, 15, 33, 29, 782, DateTimeKind.Local).AddTicks(6647));

            migrationBuilder.UpdateData(
                "Taxes",
                "TaxID",
                3,
                "DateAdded",
                new DateTime(2022, 2, 19, 15, 33, 29, 782, DateTimeKind.Local).AddTicks(6649));

            migrationBuilder.UpdateData(
                "Taxes",
                "TaxID",
                4,
                "DateAdded",
                new DateTime(2022, 2, 19, 15, 33, 29, 782, DateTimeKind.Local).AddTicks(6651));

            migrationBuilder.UpdateData(
                "Users",
                "UserID",
                1,
                "DateAdded",
                new DateTime(2022, 2, 19, 15, 33, 29, 782, DateTimeKind.Local).AddTicks(6458));

            migrationBuilder.CreateIndex(
                "IX_Messages_MessageTypeID",
                "Messages",
                "MessageTypeID");

            migrationBuilder.AddForeignKey(
                "FK_Messages_MessageTypes_MessageTypeID",
                "Messages",
                "MessageTypeID",
                "MessageTypes",
                principalColumn: "MessageTypeID",
                onDelete: ReferentialAction.Cascade);
        }
    }
}