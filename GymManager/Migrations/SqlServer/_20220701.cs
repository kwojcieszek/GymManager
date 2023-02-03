#nullable disable

using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GymManager.Migrations.SqlServer;

public partial class _20220701 : Migration
{
    protected override void Down(MigrationBuilder migrationBuilder)
    {
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

        migrationBuilder.UpdateData(
            "Passes",
            "PassID",
            1,
            "DateAdded",
            new DateTime(2022, 6, 13, 15, 11, 30, 253, DateTimeKind.Local).AddTicks(2471));

        migrationBuilder.UpdateData(
            "Passes",
            "PassID",
            2,
            "DateAdded",
            new DateTime(2022, 6, 13, 15, 11, 30, 253, DateTimeKind.Local).AddTicks(2476));

        migrationBuilder.UpdateData(
            "Passes",
            "PassID",
            3,
            "DateAdded",
            new DateTime(2022, 6, 13, 15, 11, 30, 253, DateTimeKind.Local).AddTicks(2483));

        migrationBuilder.UpdateData(
            "Passes",
            "PassID",
            4,
            "DateAdded",
            new DateTime(2022, 6, 13, 15, 11, 30, 253, DateTimeKind.Local).AddTicks(2488));

        migrationBuilder.UpdateData(
            "Passes",
            "PassID",
            5,
            "DateAdded",
            new DateTime(2022, 6, 13, 15, 11, 30, 253, DateTimeKind.Local).AddTicks(2490));

        migrationBuilder.UpdateData(
            "Passes",
            "PassID",
            6,
            "DateAdded",
            new DateTime(2022, 6, 13, 15, 11, 30, 253, DateTimeKind.Local).AddTicks(2493));

        migrationBuilder.InsertData(
            "Passes",
            new[]
            {
                "PassID", "AccessTimeFrom", "AccessTimeTo", "AddedBy", "Continuation", "DateAdded", "DateModified",
                "Description", "EentryNumberOfMonths", "EntryNetPrice", "EntryPrice", "IsAcive", "ModifiedBy", "Name",
                "NetPrice", "PassTimeID", "Price", "TaxID"
            },
            new object[]
            {
                99, null, null, 1, true, new DateTime(2022, 6, 13, 15, 11, 30, 253, DateTimeKind.Local).AddTicks(2495),
                null, "Zawieszenie karnetu", 1, 0m, 0m, true, null, "ZAWIESZENIE", 0m, 1, 0m, 4
            });

        migrationBuilder.UpdateData(
            "Taxes",
            "TaxID",
            1,
            "DateAdded",
            new DateTime(2022, 6, 13, 15, 11, 30, 253, DateTimeKind.Local).AddTicks(2433));

        migrationBuilder.UpdateData(
            "Taxes",
            "TaxID",
            2,
            "DateAdded",
            new DateTime(2022, 6, 13, 15, 11, 30, 253, DateTimeKind.Local).AddTicks(2437));

        migrationBuilder.UpdateData(
            "Taxes",
            "TaxID",
            3,
            "DateAdded",
            new DateTime(2022, 6, 13, 15, 11, 30, 253, DateTimeKind.Local).AddTicks(2439));

        migrationBuilder.UpdateData(
            "Taxes",
            "TaxID",
            4,
            "DateAdded",
            new DateTime(2022, 6, 13, 15, 11, 30, 253, DateTimeKind.Local).AddTicks(2441));

        migrationBuilder.UpdateData(
            "Users",
            "UserID",
            1,
            "DateAdded",
            new DateTime(2022, 6, 13, 15, 11, 30, 253, DateTimeKind.Local).AddTicks(2276));
    }

    protected override void Up(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DeleteData(
            "Passes",
            "PassID",
            99);

        migrationBuilder.AddColumn<DateTime>(
            "EndSuspensionDate",
            "PassesRegistry",
            "datetime2",
            nullable: true);

        migrationBuilder.AddColumn<DateTime>(
            "StartSuspensionDate",
            "PassesRegistry",
            "datetime2",
            nullable: true);

        migrationBuilder.AddColumn<bool>(
            "Suspension",
            "PassesRegistry",
            "bit",
            nullable: false,
            defaultValue: false);

        migrationBuilder.AddColumn<bool>(
            "AskAddEntry",
            "Passes",
            "bit",
            nullable: true);

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
}