#nullable disable

using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GymManager.DataService.Migrations.Sqlite
{
    public partial class _20221130 : Migration
    {
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                "FK_Messages_Users_AddedBy",
                "Messages");

            migrationBuilder.DropForeignKey(
                "FK_Messages_Users_ModifiedBy",
                "Messages");

            migrationBuilder.DropTable(
                "Companies");

            migrationBuilder.DropTable(
                "Employees");

            migrationBuilder.DropTable(
                "GymObjects");

            migrationBuilder.DropTable(
                "MessagesRegistry");

            migrationBuilder.DropIndex(
                "IX_Messages_AddedBy",
                "Messages");

            migrationBuilder.DropIndex(
                "IX_Messages_ModifiedBy",
                "Messages");

            migrationBuilder.DropColumn(
                "EndSuspensionDate",
                "PassesRegistry");

            migrationBuilder.DropColumn(
                "StartSuspensionDate",
                "PassesRegistry");

            migrationBuilder.DropColumn(
                "Suspension",
                "PassesRegistry");

            migrationBuilder.DropColumn(
                "AskAddEntry",
                "Passes");

            migrationBuilder.DropColumn(
                "EentryNumberOfMonths",
                "Passes");

            migrationBuilder.DropColumn(
                "AddedBy",
                "Messages");

            migrationBuilder.DropColumn(
                "DateModified",
                "Messages");

            migrationBuilder.DropColumn(
                "ModifiedBy",
                "Messages");

            migrationBuilder.RenameColumn(
                "MessageContent",
                "Messages",
                "TextMessage");

            migrationBuilder.AddColumn<bool>(
                "EmailSent",
                "Messages",
                "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                "MemberID",
                "Messages",
                "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                "SmsSent",
                "Messages",
                "INTEGER",
                nullable: false,
                defaultValue: false);

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
                "IX_Messages_MemberID",
                "Messages",
                "MemberID");

            migrationBuilder.AddForeignKey(
                "FK_Messages_Members_MemberID",
                "Messages",
                "MemberID",
                "Members",
                principalColumn: "MemberID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                "FK_Messages_Members_MemberID",
                "Messages");

            migrationBuilder.DropIndex(
                "IX_Messages_MemberID",
                "Messages");

            migrationBuilder.DropColumn(
                "EmailSent",
                "Messages");

            migrationBuilder.DropColumn(
                "MemberID",
                "Messages");

            migrationBuilder.DropColumn(
                "SmsSent",
                "Messages");

            migrationBuilder.RenameColumn(
                "TextMessage",
                "Messages",
                "MessageContent");

            migrationBuilder.AddColumn<DateTime>(
                "EndSuspensionDate",
                "PassesRegistry",
                "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                "StartSuspensionDate",
                "PassesRegistry",
                "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                "Suspension",
                "PassesRegistry",
                "INTEGER",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                "AskAddEntry",
                "Passes",
                "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                "EentryNumberOfMonths",
                "Passes",
                "INTEGER",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                "AddedBy",
                "Messages",
                "INTEGER",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                "DateModified",
                "Messages",
                "TEXT",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                "ModifiedBy",
                "Messages",
                "INTEGER",
                nullable: true);

            migrationBuilder.CreateTable(
                "Companies",
                table => new
                {
                    CompanyID = table.Column<int>("INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>("TEXT", nullable: true),
                    Street1 = table.Column<string>("TEXT", maxLength: 50, nullable: false),
                    Street2 = table.Column<string>("TEXT", maxLength: 50, nullable: false),
                    City = table.Column<string>("TEXT", maxLength: 50, nullable: false),
                    PostCode = table.Column<string>("TEXT", maxLength: 50, nullable: false),
                    TaxIdNumber = table.Column<string>("TEXT", nullable: true),
                    Phone = table.Column<string>("TEXT", maxLength: 50, nullable: true),
                    Email = table.Column<string>("TEXT", maxLength: 50, nullable: true),
                    DateAdded = table.Column<DateTime>("TEXT", nullable: false),
                    DateModified = table.Column<DateTime>("TEXT", nullable: true),
                    AddedBy = table.Column<int>("INTEGER", nullable: true),
                    ModifiedBy = table.Column<int>("INTEGER", nullable: true),
                    IsAcive = table.Column<bool>("INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Companies", x => x.CompanyID);

                    table.ForeignKey(
                        "FK_Companies_Users_AddedBy",
                        x => x.AddedBy,
                        "Users",
                        "UserID");

                    table.ForeignKey(
                        "FK_Companies_Users_ModifiedBy",
                        x => x.ModifiedBy,
                        "Users",
                        "UserID");
                });

            migrationBuilder.CreateTable(
                "Employees",
                table => new
                {
                    EmployeeID = table.Column<int>("INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Id = table.Column<string>("TEXT", maxLength: 50, nullable: false),
                    FirstName = table.Column<string>("TEXT", maxLength: 50, nullable: false),
                    LastName = table.Column<string>("TEXT", maxLength: 50, nullable: false),
                    Street1 = table.Column<string>("TEXT", maxLength: 50, nullable: false),
                    Street2 = table.Column<string>("TEXT", maxLength: 50, nullable: false),
                    City = table.Column<string>("TEXT", maxLength: 50, nullable: false),
                    PostCode = table.Column<string>("TEXT", maxLength: 50, nullable: false),
                    Phone = table.Column<string>("TEXT", maxLength: 50, nullable: true),
                    Pesel = table.Column<string>("TEXT", maxLength: 50, nullable: true),
                    BirthDate = table.Column<DateTime>("TEXT", nullable: true),
                    Email = table.Column<string>("TEXT", maxLength: 50, nullable: true),
                    DateAdded = table.Column<DateTime>("TEXT", nullable: false),
                    DateModified = table.Column<DateTime>("TEXT", nullable: true),
                    AddedBy = table.Column<int>("INTEGER", nullable: true),
                    ModifiedBy = table.Column<int>("INTEGER", nullable: true),
                    IsAcive = table.Column<bool>("INTEGER", nullable: false),
                    GenderID = table.Column<int>("INTEGER", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees", x => x.EmployeeID);

                    table.ForeignKey(
                        "FK_Employees_Genders_GenderID",
                        x => x.GenderID,
                        "Genders",
                        "GenderID");

                    table.ForeignKey(
                        "FK_Employees_Users_AddedBy",
                        x => x.AddedBy,
                        "Users",
                        "UserID");

                    table.ForeignKey(
                        "FK_Employees_Users_ModifiedBy",
                        x => x.ModifiedBy,
                        "Users",
                        "UserID");
                });

            migrationBuilder.CreateTable(
                "GymObjects",
                table => new
                {
                    GymObjectID = table.Column<int>("INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    Name = table.Column<string>("TEXT", nullable: true),
                    Street1 = table.Column<string>("TEXT", maxLength: 50, nullable: false),
                    Street2 = table.Column<string>("TEXT", maxLength: 50, nullable: false),
                    City = table.Column<string>("TEXT", maxLength: 50, nullable: false),
                    PostCode = table.Column<string>("TEXT", maxLength: 50, nullable: false),
                    Phone = table.Column<string>("TEXT", maxLength: 50, nullable: true),
                    Email = table.Column<string>("TEXT", maxLength: 50, nullable: true),
                    DateAdded = table.Column<DateTime>("TEXT", nullable: false),
                    DateModified = table.Column<DateTime>("TEXT", nullable: true),
                    AddedBy = table.Column<int>("INTEGER", nullable: true),
                    ModifiedBy = table.Column<int>("INTEGER", nullable: true),
                    IsAcive = table.Column<bool>("INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GymObjects", x => x.GymObjectID);

                    table.ForeignKey(
                        "FK_GymObjects_Users_AddedBy",
                        x => x.AddedBy,
                        "Users",
                        "UserID");

                    table.ForeignKey(
                        "FK_GymObjects_Users_ModifiedBy",
                        x => x.ModifiedBy,
                        "Users",
                        "UserID");
                });

            migrationBuilder.CreateTable(
                "MessagesRegistry",
                table => new
                {
                    MessageRegistryID = table.Column<int>("INTEGER", nullable: false)
                        .Annotation("Sqlite:Autoincrement", true),
                    MemberID = table.Column<int>("INTEGER", nullable: false),
                    MessageID = table.Column<int>("INTEGER", nullable: false),
                    MessageContnet = table.Column<string>("TEXT", nullable: false),
                    IsEmail = table.Column<bool>("INTEGER", nullable: false),
                    IsSms = table.Column<bool>("INTEGER", nullable: false),
                    IsError = table.Column<bool>("INTEGER", nullable: false),
                    ErrorMessage = table.Column<string>("TEXT", nullable: true),
                    EmailSentDate = table.Column<DateTime>("TEXT", nullable: true),
                    SmsSentDate = table.Column<DateTime>("TEXT", nullable: true),
                    DateAdded = table.Column<DateTime>("TEXT", nullable: false),
                    IsAcive = table.Column<bool>("INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MessagesRegistry", x => x.MessageRegistryID);

                    table.ForeignKey(
                        "FK_MessagesRegistry_Members_MemberID",
                        x => x.MemberID,
                        "Members",
                        "MemberID",
                        onDelete: ReferentialAction.Cascade);

                    table.ForeignKey(
                        "FK_MessagesRegistry_Messages_MessageID",
                        x => x.MessageID,
                        "Messages",
                        "MessageID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.UpdateData(
                "Passes",
                "PassID",
                1,
                new[] { "DateAdded", "EentryNumberOfMonths" },
                new object[] { new DateTime(2022, 11, 30, 10, 41, 45, 545, DateTimeKind.Local).AddTicks(9578), 1 });

            migrationBuilder.UpdateData(
                "Passes",
                "PassID",
                2,
                new[] { "DateAdded", "EentryNumberOfMonths" },
                new object[] { new DateTime(2022, 11, 30, 10, 41, 45, 545, DateTimeKind.Local).AddTicks(9582), 1 });

            migrationBuilder.UpdateData(
                "Passes",
                "PassID",
                3,
                new[] { "DateAdded", "EentryNumberOfMonths" },
                new object[] { new DateTime(2022, 11, 30, 10, 41, 45, 545, DateTimeKind.Local).AddTicks(9589), 1 });

            migrationBuilder.UpdateData(
                "Passes",
                "PassID",
                4,
                new[] { "DateAdded", "EentryNumberOfMonths" },
                new object[] { new DateTime(2022, 11, 30, 10, 41, 45, 545, DateTimeKind.Local).AddTicks(9590), 1 });

            migrationBuilder.UpdateData(
                "Passes",
                "PassID",
                5,
                new[] { "DateAdded", "EentryNumberOfMonths" },
                new object[] { new DateTime(2022, 11, 30, 10, 41, 45, 545, DateTimeKind.Local).AddTicks(9592), 1 });

            migrationBuilder.UpdateData(
                "Passes",
                "PassID",
                6,
                new[] { "DateAdded", "EentryNumberOfMonths" },
                new object[] { new DateTime(2022, 11, 30, 10, 41, 45, 545, DateTimeKind.Local).AddTicks(9594), 1 });

            migrationBuilder.UpdateData(
                "Taxes",
                "TaxID",
                1,
                "DateAdded",
                new DateTime(2022, 11, 30, 10, 41, 45, 545, DateTimeKind.Local).AddTicks(9548));

            migrationBuilder.UpdateData(
                "Taxes",
                "TaxID",
                2,
                "DateAdded",
                new DateTime(2022, 11, 30, 10, 41, 45, 545, DateTimeKind.Local).AddTicks(9551));

            migrationBuilder.UpdateData(
                "Taxes",
                "TaxID",
                3,
                "DateAdded",
                new DateTime(2022, 11, 30, 10, 41, 45, 545, DateTimeKind.Local).AddTicks(9552));

            migrationBuilder.UpdateData(
                "Taxes",
                "TaxID",
                4,
                "DateAdded",
                new DateTime(2022, 11, 30, 10, 41, 45, 545, DateTimeKind.Local).AddTicks(9553));

            migrationBuilder.UpdateData(
                "Users",
                "UserID",
                1,
                "DateAdded",
                new DateTime(2022, 11, 30, 10, 41, 45, 545, DateTimeKind.Local).AddTicks(9435));

            migrationBuilder.CreateIndex(
                "IX_Messages_AddedBy",
                "Messages",
                "AddedBy");

            migrationBuilder.CreateIndex(
                "IX_Messages_ModifiedBy",
                "Messages",
                "ModifiedBy");

            migrationBuilder.CreateIndex(
                "IX_Companies_AddedBy",
                "Companies",
                "AddedBy");

            migrationBuilder.CreateIndex(
                "IX_Companies_ModifiedBy",
                "Companies",
                "ModifiedBy");

            migrationBuilder.CreateIndex(
                "IX_Employees_AddedBy",
                "Employees",
                "AddedBy");

            migrationBuilder.CreateIndex(
                "IX_Employees_GenderID",
                "Employees",
                "GenderID");

            migrationBuilder.CreateIndex(
                "IX_Employees_Id",
                "Employees",
                "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                "IX_Employees_ModifiedBy",
                "Employees",
                "ModifiedBy");

            migrationBuilder.CreateIndex(
                "IX_GymObjects_AddedBy",
                "GymObjects",
                "AddedBy");

            migrationBuilder.CreateIndex(
                "IX_GymObjects_ModifiedBy",
                "GymObjects",
                "ModifiedBy");

            migrationBuilder.CreateIndex(
                "IX_MessagesRegistry_MemberID",
                "MessagesRegistry",
                "MemberID");

            migrationBuilder.CreateIndex(
                "IX_MessagesRegistry_MessageID",
                "MessagesRegistry",
                "MessageID");

            migrationBuilder.AddForeignKey(
                "FK_Messages_Users_AddedBy",
                "Messages",
                "AddedBy",
                "Users",
                principalColumn: "UserID");

            migrationBuilder.AddForeignKey(
                "FK_Messages_Users_ModifiedBy",
                "Messages",
                "ModifiedBy",
                "Users",
                principalColumn: "UserID");
        }
    }
}