#nullable disable

using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace GymManager.Migrations.PostgreSql
{
    public partial class _20221130 : Migration
    {
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                "FK_Messages_MessageTypes_MessageTypeID",
                "Messages");

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

            migrationBuilder.DropTable(
                "MessageTypes");

            migrationBuilder.DropIndex(
                "IX_Messages_AddedBy",
                "Messages");

            migrationBuilder.DropIndex(
                "IX_Messages_ModifiedBy",
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

            migrationBuilder.DropColumn(
                "BirthDate",
                "Members");

            migrationBuilder.DropColumn(
                "Pesel",
                "Members");

            migrationBuilder.RenameColumn(
                "MessageTypeID",
                "Messages",
                "MemberID");

            migrationBuilder.RenameColumn(
                "MessageContent",
                "Messages",
                "TextMessage");

            migrationBuilder.RenameIndex(
                "IX_Messages_MessageTypeID",
                table: "Messages",
                newName: "IX_Messages_MemberID");

            migrationBuilder.AddColumn<bool>(
                "EmailSent",
                "Messages",
                "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                "SmsSent",
                "Messages",
                "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                "Passes",
                "PassID",
                1,
                "DateAdded",
                new DateTime(2022, 2, 11, 11, 15, 14, 212, DateTimeKind.Local).AddTicks(1706));

            migrationBuilder.UpdateData(
                "Passes",
                "PassID",
                2,
                "DateAdded",
                new DateTime(2022, 2, 11, 11, 15, 14, 212, DateTimeKind.Local).AddTicks(1715));

            migrationBuilder.UpdateData(
                "Passes",
                "PassID",
                3,
                "DateAdded",
                new DateTime(2022, 2, 11, 11, 15, 14, 212, DateTimeKind.Local).AddTicks(1723));

            migrationBuilder.UpdateData(
                "Passes",
                "PassID",
                4,
                "DateAdded",
                new DateTime(2022, 2, 11, 11, 15, 14, 212, DateTimeKind.Local).AddTicks(1726));

            migrationBuilder.UpdateData(
                "Passes",
                "PassID",
                5,
                "DateAdded",
                new DateTime(2022, 2, 11, 11, 15, 14, 212, DateTimeKind.Local).AddTicks(1729));

            migrationBuilder.UpdateData(
                "Passes",
                "PassID",
                6,
                "DateAdded",
                new DateTime(2022, 2, 11, 11, 15, 14, 212, DateTimeKind.Local).AddTicks(1732));

            migrationBuilder.UpdateData(
                "Taxes",
                "TaxID",
                1,
                "DateAdded",
                new DateTime(2022, 2, 11, 11, 15, 14, 212, DateTimeKind.Local).AddTicks(1656));

            migrationBuilder.UpdateData(
                "Taxes",
                "TaxID",
                2,
                "DateAdded",
                new DateTime(2022, 2, 11, 11, 15, 14, 212, DateTimeKind.Local).AddTicks(1661));

            migrationBuilder.UpdateData(
                "Taxes",
                "TaxID",
                3,
                "DateAdded",
                new DateTime(2022, 2, 11, 11, 15, 14, 212, DateTimeKind.Local).AddTicks(1664));

            migrationBuilder.UpdateData(
                "Taxes",
                "TaxID",
                4,
                "DateAdded",
                new DateTime(2022, 2, 11, 11, 15, 14, 212, DateTimeKind.Local).AddTicks(1666));

            migrationBuilder.UpdateData(
                "Users",
                "UserID",
                1,
                "DateAdded",
                new DateTime(2022, 2, 11, 11, 15, 14, 212, DateTimeKind.Local).AddTicks(1490));

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

            migrationBuilder.DropColumn(
                "EmailSent",
                "Messages");

            migrationBuilder.DropColumn(
                "SmsSent",
                "Messages");

            migrationBuilder.RenameColumn(
                "TextMessage",
                "Messages",
                "MessageContent");

            migrationBuilder.RenameColumn(
                "MemberID",
                "Messages",
                "MessageTypeID");

            migrationBuilder.RenameIndex(
                "IX_Messages_MemberID",
                table: "Messages",
                newName: "IX_Messages_MessageTypeID");

            migrationBuilder.AddColumn<DateTime>(
                "EndSuspensionDate",
                "PassesRegistry",
                "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                "StartSuspensionDate",
                "PassesRegistry",
                "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                "Suspension",
                "PassesRegistry",
                "boolean",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                "AskAddEntry",
                "Passes",
                "boolean",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                "EentryNumberOfMonths",
                "Passes",
                "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                "AddedBy",
                "Messages",
                "integer",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                "DateModified",
                "Messages",
                "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                "ModifiedBy",
                "Messages",
                "integer",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                "BirthDate",
                "Members",
                "timestamp with time zone",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                "Pesel",
                "Members",
                "character varying(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.CreateTable(
                "Companies",
                table => new
                {
                    CompanyID = table.Column<int>("integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy",
                            NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>("text", nullable: true),
                    Street1 = table.Column<string>("character varying(50)", maxLength: 50, nullable: false),
                    Street2 = table.Column<string>("character varying(50)", maxLength: 50, nullable: false),
                    City = table.Column<string>("character varying(50)", maxLength: 50, nullable: false),
                    PostCode = table.Column<string>("character varying(50)", maxLength: 50, nullable: false),
                    TaxIdNumber = table.Column<string>("text", nullable: true),
                    Phone = table.Column<string>("character varying(50)", maxLength: 50, nullable: true),
                    Email = table.Column<string>("character varying(50)", maxLength: 50, nullable: true),
                    DateAdded = table.Column<DateTime>("timestamp with time zone", nullable: false),
                    DateModified = table.Column<DateTime>("timestamp with time zone", nullable: true),
                    AddedBy = table.Column<int>("integer", nullable: true),
                    ModifiedBy = table.Column<int>("integer", nullable: true),
                    IsAcive = table.Column<bool>("boolean", nullable: false)
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
                    EmployeeID = table.Column<int>("integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy",
                            NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Id = table.Column<string>("character varying(50)", maxLength: 50, nullable: false),
                    FirstName = table.Column<string>("character varying(50)", maxLength: 50, nullable: false),
                    LastName = table.Column<string>("character varying(50)", maxLength: 50, nullable: false),
                    Street1 = table.Column<string>("character varying(50)", maxLength: 50, nullable: false),
                    Street2 = table.Column<string>("character varying(50)", maxLength: 50, nullable: false),
                    City = table.Column<string>("character varying(50)", maxLength: 50, nullable: false),
                    PostCode = table.Column<string>("character varying(50)", maxLength: 50, nullable: false),
                    Phone = table.Column<string>("character varying(50)", maxLength: 50, nullable: true),
                    Pesel = table.Column<string>("character varying(50)", maxLength: 50, nullable: true),
                    BirthDate = table.Column<DateTime>("timestamp with time zone", nullable: true),
                    Email = table.Column<string>("character varying(50)", maxLength: 50, nullable: true),
                    DateAdded = table.Column<DateTime>("timestamp with time zone", nullable: false),
                    DateModified = table.Column<DateTime>("timestamp with time zone", nullable: true),
                    AddedBy = table.Column<int>("integer", nullable: true),
                    ModifiedBy = table.Column<int>("integer", nullable: true),
                    IsAcive = table.Column<bool>("boolean", nullable: false),
                    GenderID = table.Column<int>("integer", nullable: true)
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
                    GymObjectID = table.Column<int>("integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy",
                            NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>("text", nullable: true),
                    Street1 = table.Column<string>("character varying(50)", maxLength: 50, nullable: false),
                    Street2 = table.Column<string>("character varying(50)", maxLength: 50, nullable: false),
                    City = table.Column<string>("character varying(50)", maxLength: 50, nullable: false),
                    PostCode = table.Column<string>("character varying(50)", maxLength: 50, nullable: false),
                    Phone = table.Column<string>("character varying(50)", maxLength: 50, nullable: true),
                    Email = table.Column<string>("character varying(50)", maxLength: 50, nullable: true),
                    DateAdded = table.Column<DateTime>("timestamp with time zone", nullable: false),
                    DateModified = table.Column<DateTime>("timestamp with time zone", nullable: true),
                    AddedBy = table.Column<int>("integer", nullable: true),
                    ModifiedBy = table.Column<int>("integer", nullable: true),
                    IsAcive = table.Column<bool>("boolean", nullable: false)
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
                    MessageRegistryID = table.Column<int>("integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy",
                            NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    MemberID = table.Column<int>("integer", nullable: false),
                    MessageID = table.Column<int>("integer", nullable: false),
                    MessageContnet = table.Column<string>("text", nullable: false),
                    IsEmail = table.Column<bool>("boolean", nullable: false),
                    IsSms = table.Column<bool>("boolean", nullable: false),
                    IsError = table.Column<bool>("boolean", nullable: false),
                    ErrorMessage = table.Column<string>("text", nullable: true),
                    EmailSentDate = table.Column<DateTime>("timestamp with time zone", nullable: true),
                    SmsSentDate = table.Column<DateTime>("timestamp with time zone", nullable: true),
                    DateAdded = table.Column<DateTime>("timestamp with time zone", nullable: false),
                    IsAcive = table.Column<bool>("boolean", nullable: false)
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

            migrationBuilder.CreateTable(
                "MessageTypes",
                table => new
                {
                    MessageTypeID = table.Column<int>("integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy",
                            NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>("text", nullable: false),
                    Message = table.Column<string>("text", nullable: true),
                    IsEmail = table.Column<bool>("boolean", nullable: false),
                    IsSms = table.Column<bool>("boolean", nullable: false),
                    IsAcive = table.Column<bool>("boolean", nullable: false)
                },
                constraints: table => { table.PrimaryKey("PK_MessageTypes", x => x.MessageTypeID); });

            migrationBuilder.UpdateData(
                "Passes",
                "PassID",
                1,
                new[] { "DateAdded", "EentryNumberOfMonths" },
                new object[] { new DateTime(2022, 11, 30, 10, 42, 11, 651, DateTimeKind.Local).AddTicks(728), 1 });

            migrationBuilder.UpdateData(
                "Passes",
                "PassID",
                2,
                new[] { "DateAdded", "EentryNumberOfMonths" },
                new object[] { new DateTime(2022, 11, 30, 10, 42, 11, 651, DateTimeKind.Local).AddTicks(732), 1 });

            migrationBuilder.UpdateData(
                "Passes",
                "PassID",
                3,
                new[] { "DateAdded", "EentryNumberOfMonths" },
                new object[] { new DateTime(2022, 11, 30, 10, 42, 11, 651, DateTimeKind.Local).AddTicks(738), 1 });

            migrationBuilder.UpdateData(
                "Passes",
                "PassID",
                4,
                new[] { "DateAdded", "EentryNumberOfMonths" },
                new object[] { new DateTime(2022, 11, 30, 10, 42, 11, 651, DateTimeKind.Local).AddTicks(741), 1 });

            migrationBuilder.UpdateData(
                "Passes",
                "PassID",
                5,
                new[] { "DateAdded", "EentryNumberOfMonths" },
                new object[] { new DateTime(2022, 11, 30, 10, 42, 11, 651, DateTimeKind.Local).AddTicks(742), 1 });

            migrationBuilder.UpdateData(
                "Passes",
                "PassID",
                6,
                new[] { "DateAdded", "EentryNumberOfMonths" },
                new object[] { new DateTime(2022, 11, 30, 10, 42, 11, 651, DateTimeKind.Local).AddTicks(744), 1 });

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
                new DateTime(2022, 11, 30, 10, 42, 11, 651, DateTimeKind.Local).AddTicks(696));

            migrationBuilder.UpdateData(
                "Taxes",
                "TaxID",
                2,
                "DateAdded",
                new DateTime(2022, 11, 30, 10, 42, 11, 651, DateTimeKind.Local).AddTicks(699));

            migrationBuilder.UpdateData(
                "Taxes",
                "TaxID",
                3,
                "DateAdded",
                new DateTime(2022, 11, 30, 10, 42, 11, 651, DateTimeKind.Local).AddTicks(700));

            migrationBuilder.UpdateData(
                "Taxes",
                "TaxID",
                4,
                "DateAdded",
                new DateTime(2022, 11, 30, 10, 42, 11, 651, DateTimeKind.Local).AddTicks(701));

            migrationBuilder.UpdateData(
                "Users",
                "UserID",
                1,
                "DateAdded",
                new DateTime(2022, 11, 30, 10, 42, 11, 651, DateTimeKind.Local).AddTicks(589));

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
                "FK_Messages_MessageTypes_MessageTypeID",
                "Messages",
                "MessageTypeID",
                "MessageTypes",
                principalColumn: "MessageTypeID",
                onDelete: ReferentialAction.Cascade);

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