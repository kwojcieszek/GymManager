#nullable disable

using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GymManager.Migrations.MySql
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
                "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                "SmsSent",
                "Messages",
                "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.UpdateData(
                "Passes",
                "PassID",
                1,
                "DateAdded",
                new DateTime(2022, 2, 11, 11, 30, 9, 631, DateTimeKind.Local).AddTicks(4704));

            migrationBuilder.UpdateData(
                "Passes",
                "PassID",
                2,
                "DateAdded",
                new DateTime(2022, 2, 11, 11, 30, 9, 631, DateTimeKind.Local).AddTicks(4710));

            migrationBuilder.UpdateData(
                "Passes",
                "PassID",
                3,
                "DateAdded",
                new DateTime(2022, 2, 11, 11, 30, 9, 631, DateTimeKind.Local).AddTicks(4718));

            migrationBuilder.UpdateData(
                "Passes",
                "PassID",
                4,
                "DateAdded",
                new DateTime(2022, 2, 11, 11, 30, 9, 631, DateTimeKind.Local).AddTicks(4721));

            migrationBuilder.UpdateData(
                "Passes",
                "PassID",
                5,
                "DateAdded",
                new DateTime(2022, 2, 11, 11, 30, 9, 631, DateTimeKind.Local).AddTicks(4724));

            migrationBuilder.UpdateData(
                "Passes",
                "PassID",
                6,
                "DateAdded",
                new DateTime(2022, 2, 11, 11, 30, 9, 631, DateTimeKind.Local).AddTicks(4727));

            migrationBuilder.UpdateData(
                "Taxes",
                "TaxID",
                1,
                "DateAdded",
                new DateTime(2022, 2, 11, 11, 30, 9, 631, DateTimeKind.Local).AddTicks(4664));

            migrationBuilder.UpdateData(
                "Taxes",
                "TaxID",
                2,
                "DateAdded",
                new DateTime(2022, 2, 11, 11, 30, 9, 631, DateTimeKind.Local).AddTicks(4667));

            migrationBuilder.UpdateData(
                "Taxes",
                "TaxID",
                3,
                "DateAdded",
                new DateTime(2022, 2, 11, 11, 30, 9, 631, DateTimeKind.Local).AddTicks(4670));

            migrationBuilder.UpdateData(
                "Taxes",
                "TaxID",
                4,
                "DateAdded",
                new DateTime(2022, 2, 11, 11, 30, 9, 631, DateTimeKind.Local).AddTicks(4672));

            migrationBuilder.UpdateData(
                "Users",
                "UserID",
                1,
                "DateAdded",
                new DateTime(2022, 2, 11, 11, 30, 9, 631, DateTimeKind.Local).AddTicks(4516));

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
                "datetime(6)",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                "StartSuspensionDate",
                "PassesRegistry",
                "datetime(6)",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                "Suspension",
                "PassesRegistry",
                "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                "AskAddEntry",
                "Passes",
                "tinyint(1)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                "EentryNumberOfMonths",
                "Passes",
                "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                "AddedBy",
                "Messages",
                "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                "DateModified",
                "Messages",
                "datetime(6)",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                "ModifiedBy",
                "Messages",
                "int",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                "BirthDate",
                "Members",
                "datetime(6)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                    "Pesel",
                    "Members",
                    "varchar(50)",
                    maxLength: 50,
                    nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                    "Companies",
                    table => new
                    {
                        CompanyID = table.Column<int>("int", nullable: false)
                            .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                        Name = table.Column<string>("longtext", nullable: true)
                            .Annotation("MySql:CharSet", "utf8mb4"),
                        Street1 = table.Column<string>("varchar(50)", maxLength: 50, nullable: false)
                            .Annotation("MySql:CharSet", "utf8mb4"),
                        Street2 = table.Column<string>("varchar(50)", maxLength: 50, nullable: false)
                            .Annotation("MySql:CharSet", "utf8mb4"),
                        City = table.Column<string>("varchar(50)", maxLength: 50, nullable: false)
                            .Annotation("MySql:CharSet", "utf8mb4"),
                        PostCode = table.Column<string>("varchar(50)", maxLength: 50, nullable: false)
                            .Annotation("MySql:CharSet", "utf8mb4"),
                        TaxIdNumber = table.Column<string>("longtext", nullable: true)
                            .Annotation("MySql:CharSet", "utf8mb4"),
                        Phone = table.Column<string>("varchar(50)", maxLength: 50, nullable: true)
                            .Annotation("MySql:CharSet", "utf8mb4"),
                        Email = table.Column<string>("varchar(50)", maxLength: 50, nullable: true)
                            .Annotation("MySql:CharSet", "utf8mb4"),
                        DateAdded = table.Column<DateTime>("datetime(6)", nullable: false),
                        DateModified = table.Column<DateTime>("datetime(6)", nullable: true),
                        AddedBy = table.Column<int>("int", nullable: true),
                        ModifiedBy = table.Column<int>("int", nullable: true),
                        IsAcive = table.Column<bool>("tinyint(1)", nullable: false)
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
                    })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                    "Employees",
                    table => new
                    {
                        EmployeeID = table.Column<int>("int", nullable: false)
                            .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                        Id = table.Column<string>("varchar(50)", maxLength: 50, nullable: false)
                            .Annotation("MySql:CharSet", "utf8mb4"),
                        FirstName = table.Column<string>("varchar(50)", maxLength: 50, nullable: false)
                            .Annotation("MySql:CharSet", "utf8mb4"),
                        LastName = table.Column<string>("varchar(50)", maxLength: 50, nullable: false)
                            .Annotation("MySql:CharSet", "utf8mb4"),
                        Street1 = table.Column<string>("varchar(50)", maxLength: 50, nullable: false)
                            .Annotation("MySql:CharSet", "utf8mb4"),
                        Street2 = table.Column<string>("varchar(50)", maxLength: 50, nullable: false)
                            .Annotation("MySql:CharSet", "utf8mb4"),
                        City = table.Column<string>("varchar(50)", maxLength: 50, nullable: false)
                            .Annotation("MySql:CharSet", "utf8mb4"),
                        PostCode = table.Column<string>("varchar(50)", maxLength: 50, nullable: false)
                            .Annotation("MySql:CharSet", "utf8mb4"),
                        Phone = table.Column<string>("varchar(50)", maxLength: 50, nullable: true)
                            .Annotation("MySql:CharSet", "utf8mb4"),
                        Pesel = table.Column<string>("varchar(50)", maxLength: 50, nullable: true)
                            .Annotation("MySql:CharSet", "utf8mb4"),
                        BirthDate = table.Column<DateTime>("datetime(6)", nullable: true),
                        Email = table.Column<string>("varchar(50)", maxLength: 50, nullable: true)
                            .Annotation("MySql:CharSet", "utf8mb4"),
                        DateAdded = table.Column<DateTime>("datetime(6)", nullable: false),
                        DateModified = table.Column<DateTime>("datetime(6)", nullable: true),
                        AddedBy = table.Column<int>("int", nullable: true),
                        ModifiedBy = table.Column<int>("int", nullable: true),
                        IsAcive = table.Column<bool>("tinyint(1)", nullable: false),
                        GenderID = table.Column<int>("int", nullable: true)
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
                    })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                    "GymObjects",
                    table => new
                    {
                        GymObjectID = table.Column<int>("int", nullable: false)
                            .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                        Name = table.Column<string>("longtext", nullable: true)
                            .Annotation("MySql:CharSet", "utf8mb4"),
                        Street1 = table.Column<string>("varchar(50)", maxLength: 50, nullable: false)
                            .Annotation("MySql:CharSet", "utf8mb4"),
                        Street2 = table.Column<string>("varchar(50)", maxLength: 50, nullable: false)
                            .Annotation("MySql:CharSet", "utf8mb4"),
                        City = table.Column<string>("varchar(50)", maxLength: 50, nullable: false)
                            .Annotation("MySql:CharSet", "utf8mb4"),
                        PostCode = table.Column<string>("varchar(50)", maxLength: 50, nullable: false)
                            .Annotation("MySql:CharSet", "utf8mb4"),
                        Phone = table.Column<string>("varchar(50)", maxLength: 50, nullable: true)
                            .Annotation("MySql:CharSet", "utf8mb4"),
                        Email = table.Column<string>("varchar(50)", maxLength: 50, nullable: true)
                            .Annotation("MySql:CharSet", "utf8mb4"),
                        DateAdded = table.Column<DateTime>("datetime(6)", nullable: false),
                        DateModified = table.Column<DateTime>("datetime(6)", nullable: true),
                        AddedBy = table.Column<int>("int", nullable: true),
                        ModifiedBy = table.Column<int>("int", nullable: true),
                        IsAcive = table.Column<bool>("tinyint(1)", nullable: false)
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
                    })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                    "MessagesRegistry",
                    table => new
                    {
                        MessageRegistryID = table.Column<int>("int", nullable: false)
                            .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                        MemberID = table.Column<int>("int", nullable: false),
                        MessageID = table.Column<int>("int", nullable: false),
                        MessageContnet = table.Column<string>("longtext", nullable: false)
                            .Annotation("MySql:CharSet", "utf8mb4"),
                        IsEmail = table.Column<bool>("tinyint(1)", nullable: false),
                        IsSms = table.Column<bool>("tinyint(1)", nullable: false),
                        IsError = table.Column<bool>("tinyint(1)", nullable: false),
                        ErrorMessage = table.Column<string>("longtext", nullable: true)
                            .Annotation("MySql:CharSet", "utf8mb4"),
                        EmailSentDate = table.Column<DateTime>("datetime(6)", nullable: true),
                        SmsSentDate = table.Column<DateTime>("datetime(6)", nullable: true),
                        DateAdded = table.Column<DateTime>("datetime(6)", nullable: false),
                        IsAcive = table.Column<bool>("tinyint(1)", nullable: false)
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
                    })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateTable(
                    "MessageTypes",
                    table => new
                    {
                        MessageTypeID = table.Column<int>("int", nullable: false)
                            .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                        Name = table.Column<string>("longtext", nullable: false)
                            .Annotation("MySql:CharSet", "utf8mb4"),
                        Message = table.Column<string>("longtext", nullable: true)
                            .Annotation("MySql:CharSet", "utf8mb4"),
                        IsEmail = table.Column<bool>("tinyint(1)", nullable: false),
                        IsSms = table.Column<bool>("tinyint(1)", nullable: false),
                        IsAcive = table.Column<bool>("tinyint(1)", nullable: false)
                    },
                    constraints: table => { table.PrimaryKey("PK_MessageTypes", x => x.MessageTypeID); })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                "Passes",
                "PassID",
                1,
                new[] { "DateAdded", "EentryNumberOfMonths" },
                new object[] { new DateTime(2022, 11, 30, 10, 42, 25, 899, DateTimeKind.Local).AddTicks(3761), 1 });

            migrationBuilder.UpdateData(
                "Passes",
                "PassID",
                2,
                new[] { "DateAdded", "EentryNumberOfMonths" },
                new object[] { new DateTime(2022, 11, 30, 10, 42, 25, 899, DateTimeKind.Local).AddTicks(3766), 1 });

            migrationBuilder.UpdateData(
                "Passes",
                "PassID",
                3,
                new[] { "DateAdded", "EentryNumberOfMonths" },
                new object[] { new DateTime(2022, 11, 30, 10, 42, 25, 899, DateTimeKind.Local).AddTicks(3772), 1 });

            migrationBuilder.UpdateData(
                "Passes",
                "PassID",
                4,
                new[] { "DateAdded", "EentryNumberOfMonths" },
                new object[] { new DateTime(2022, 11, 30, 10, 42, 25, 899, DateTimeKind.Local).AddTicks(3774), 1 });

            migrationBuilder.UpdateData(
                "Passes",
                "PassID",
                5,
                new[] { "DateAdded", "EentryNumberOfMonths" },
                new object[] { new DateTime(2022, 11, 30, 10, 42, 25, 899, DateTimeKind.Local).AddTicks(3776), 1 });

            migrationBuilder.UpdateData(
                "Passes",
                "PassID",
                6,
                new[] { "DateAdded", "EentryNumberOfMonths" },
                new object[] { new DateTime(2022, 11, 30, 10, 42, 25, 899, DateTimeKind.Local).AddTicks(3782), 1 });

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
                new DateTime(2022, 11, 30, 10, 42, 25, 899, DateTimeKind.Local).AddTicks(3736));

            migrationBuilder.UpdateData(
                "Taxes",
                "TaxID",
                2,
                "DateAdded",
                new DateTime(2022, 11, 30, 10, 42, 25, 899, DateTimeKind.Local).AddTicks(3738));

            migrationBuilder.UpdateData(
                "Taxes",
                "TaxID",
                3,
                "DateAdded",
                new DateTime(2022, 11, 30, 10, 42, 25, 899, DateTimeKind.Local).AddTicks(3740));

            migrationBuilder.UpdateData(
                "Taxes",
                "TaxID",
                4,
                "DateAdded",
                new DateTime(2022, 11, 30, 10, 42, 25, 899, DateTimeKind.Local).AddTicks(3741));

            migrationBuilder.UpdateData(
                "Users",
                "UserID",
                1,
                "DateAdded",
                new DateTime(2022, 11, 30, 10, 42, 25, 899, DateTimeKind.Local).AddTicks(3623));

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