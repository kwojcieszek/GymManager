#nullable disable

using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GymManager.Migrations.SqlServer
{
    public partial class _20220220 : Migration
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
                "MessagesRegistry");

            migrationBuilder.DropIndex(
                "IX_Messages_AddedBy",
                "Messages");

            migrationBuilder.DropIndex(
                "IX_Messages_ModifiedBy",
                "Messages");

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
                "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<int>(
                "MemberID",
                "Messages",
                "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<bool>(
                "SmsSent",
                "Messages",
                "bit",
                nullable: false,
                defaultValue: false);

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
                "datetime2",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                "ModifiedBy",
                "Messages",
                "int",
                nullable: true);

            migrationBuilder.CreateTable(
                "MessagesRegistry",
                table => new
                {
                    MessageRegistryID = table.Column<int>("int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MemberID = table.Column<int>("int", nullable: false),
                    MessageID = table.Column<int>("int", nullable: false),
                    MessageContnet = table.Column<string>("nvarchar(max)", nullable: false),
                    IsEmail = table.Column<bool>("bit", nullable: false),
                    IsSms = table.Column<bool>("bit", nullable: false),
                    IsError = table.Column<bool>("bit", nullable: false),
                    ErrorMessage = table.Column<string>("nvarchar(max)", nullable: true),
                    EmailSentDate = table.Column<DateTime>("datetime2", nullable: true),
                    SmsSentDate = table.Column<DateTime>("datetime2", nullable: true),
                    DateAdded = table.Column<DateTime>("datetime2", nullable: false),
                    IsAcive = table.Column<bool>("bit", nullable: false)
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
                new object[] { new DateTime(2022, 2, 20, 9, 30, 13, 828, DateTimeKind.Local).AddTicks(5066), 1 });

            migrationBuilder.UpdateData(
                "Passes",
                "PassID",
                2,
                new[] { "DateAdded", "EentryNumberOfMonths" },
                new object[] { new DateTime(2022, 2, 20, 9, 30, 13, 828, DateTimeKind.Local).AddTicks(5072), 1 });

            migrationBuilder.UpdateData(
                "Passes",
                "PassID",
                3,
                new[] { "DateAdded", "EentryNumberOfMonths" },
                new object[] { new DateTime(2022, 2, 20, 9, 30, 13, 828, DateTimeKind.Local).AddTicks(5079), 1 });

            migrationBuilder.UpdateData(
                "Passes",
                "PassID",
                4,
                new[] { "DateAdded", "EentryNumberOfMonths" },
                new object[] { new DateTime(2022, 2, 20, 9, 30, 13, 828, DateTimeKind.Local).AddTicks(5082), 1 });

            migrationBuilder.UpdateData(
                "Passes",
                "PassID",
                5,
                new[] { "DateAdded", "EentryNumberOfMonths" },
                new object[] { new DateTime(2022, 2, 20, 9, 30, 13, 828, DateTimeKind.Local).AddTicks(5085), 1 });

            migrationBuilder.UpdateData(
                "Passes",
                "PassID",
                6,
                new[] { "DateAdded", "EentryNumberOfMonths" },
                new object[] { new DateTime(2022, 2, 20, 9, 30, 13, 828, DateTimeKind.Local).AddTicks(5088), 1 });

            migrationBuilder.UpdateData(
                "Taxes",
                "TaxID",
                1,
                "DateAdded",
                new DateTime(2022, 2, 20, 9, 30, 13, 828, DateTimeKind.Local).AddTicks(5029));

            migrationBuilder.UpdateData(
                "Taxes",
                "TaxID",
                2,
                "DateAdded",
                new DateTime(2022, 2, 20, 9, 30, 13, 828, DateTimeKind.Local).AddTicks(5033));

            migrationBuilder.UpdateData(
                "Taxes",
                "TaxID",
                3,
                "DateAdded",
                new DateTime(2022, 2, 20, 9, 30, 13, 828, DateTimeKind.Local).AddTicks(5034));

            migrationBuilder.UpdateData(
                "Taxes",
                "TaxID",
                4,
                "DateAdded",
                new DateTime(2022, 2, 20, 9, 30, 13, 828, DateTimeKind.Local).AddTicks(5036));

            migrationBuilder.UpdateData(
                "Users",
                "UserID",
                1,
                "DateAdded",
                new DateTime(2022, 2, 20, 9, 30, 13, 828, DateTimeKind.Local).AddTicks(4875));

            migrationBuilder.CreateIndex(
                "IX_Messages_AddedBy",
                "Messages",
                "AddedBy");

            migrationBuilder.CreateIndex(
                "IX_Messages_ModifiedBy",
                "Messages",
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