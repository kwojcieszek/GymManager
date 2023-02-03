#nullable disable

using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GymManager.Migrations.SqlServer;

public partial class _20220217 : Migration
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
    }

    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.AddColumn<int>(
            "MessageTypeID",
            "Messages",
            "int",
            nullable: false,
            defaultValue: 0);

        migrationBuilder.AddColumn<DateTime>(
            "BirthDate",
            "Members",
            "datetime2",
            nullable: true);

        migrationBuilder.AddColumn<string>(
            "Pesel",
            "Members",
            "nvarchar(50)",
            maxLength: 50,
            nullable: true);

        migrationBuilder.CreateTable(
            "MessageTypes",
            table => new
            {
                MessageTypeID = table.Column<int>("int", nullable: false)
                    .Annotation("SqlServer:Identity", "1, 1"),
                Name = table.Column<string>("nvarchar(max)", nullable: false),
                Message = table.Column<string>("nvarchar(max)", nullable: true),
                IsEmail = table.Column<bool>("bit", nullable: false),
                IsSms = table.Column<bool>("bit", nullable: false),
                IsAcive = table.Column<bool>("bit", nullable: false)
            },
            constraints: table => { table.PrimaryKey("PK_MessageTypes", x => x.MessageTypeID); });

        migrationBuilder.UpdateData(
            "Passes",
            "PassID",
            1,
            "DateAdded",
            new DateTime(2022, 2, 17, 10, 40, 50, 953, DateTimeKind.Local).AddTicks(2558));

        migrationBuilder.UpdateData(
            "Passes",
            "PassID",
            2,
            "DateAdded",
            new DateTime(2022, 2, 17, 10, 40, 50, 953, DateTimeKind.Local).AddTicks(2563));

        migrationBuilder.UpdateData(
            "Passes",
            "PassID",
            3,
            "DateAdded",
            new DateTime(2022, 2, 17, 10, 40, 50, 953, DateTimeKind.Local).AddTicks(2572));

        migrationBuilder.UpdateData(
            "Passes",
            "PassID",
            4,
            "DateAdded",
            new DateTime(2022, 2, 17, 10, 40, 50, 953, DateTimeKind.Local).AddTicks(2574));

        migrationBuilder.UpdateData(
            "Passes",
            "PassID",
            5,
            "DateAdded",
            new DateTime(2022, 2, 17, 10, 40, 50, 953, DateTimeKind.Local).AddTicks(2577));

        migrationBuilder.UpdateData(
            "Passes",
            "PassID",
            6,
            "DateAdded",
            new DateTime(2022, 2, 17, 10, 40, 50, 953, DateTimeKind.Local).AddTicks(2580));

        migrationBuilder.InsertData(
            "PermissionsList",
            new[] { "PermissionListID", "Name" },
            new object[,]
            {
                { 26, "ZAMYKANIE WEJŚCIA CZŁONKÓW W OBIEKCIE" },
                { 27, "DODAJ WEJŚCIE/WYJŚCIE BEZ IDENTYFIKATORA" }
            });

        migrationBuilder.UpdateData(
            "Taxes",
            "TaxID",
            1,
            "DateAdded",
            new DateTime(2022, 2, 17, 10, 40, 50, 953, DateTimeKind.Local).AddTicks(2515));

        migrationBuilder.UpdateData(
            "Taxes",
            "TaxID",
            2,
            "DateAdded",
            new DateTime(2022, 2, 17, 10, 40, 50, 953, DateTimeKind.Local).AddTicks(2519));

        migrationBuilder.UpdateData(
            "Taxes",
            "TaxID",
            3,
            "DateAdded",
            new DateTime(2022, 2, 17, 10, 40, 50, 953, DateTimeKind.Local).AddTicks(2520));

        migrationBuilder.UpdateData(
            "Taxes",
            "TaxID",
            4,
            "DateAdded",
            new DateTime(2022, 2, 17, 10, 40, 50, 953, DateTimeKind.Local).AddTicks(2522));

        migrationBuilder.UpdateData(
            "Users",
            "UserID",
            1,
            "DateAdded",
            new DateTime(2022, 2, 17, 10, 40, 50, 953, DateTimeKind.Local).AddTicks(2355));

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