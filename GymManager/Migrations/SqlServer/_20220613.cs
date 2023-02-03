#nullable disable

using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace GymManager.Migrations.SqlServer;

public partial class _20220613 : Migration
{
    protected override void Down(MigrationBuilder migrationBuilder)
    {
        migrationBuilder.DeleteData(
            "Passes",
            "PassID",
            99);

        migrationBuilder.UpdateData(
            "Passes",
            "PassID",
            1,
            "DateAdded",
            new DateTime(2022, 3, 1, 15, 38, 21, 135, DateTimeKind.Local).AddTicks(1543));

        migrationBuilder.UpdateData(
            "Passes",
            "PassID",
            2,
            "DateAdded",
            new DateTime(2022, 3, 1, 15, 38, 21, 135, DateTimeKind.Local).AddTicks(1549));

        migrationBuilder.UpdateData(
            "Passes",
            "PassID",
            3,
            "DateAdded",
            new DateTime(2022, 3, 1, 15, 38, 21, 135, DateTimeKind.Local).AddTicks(1558));

        migrationBuilder.UpdateData(
            "Passes",
            "PassID",
            4,
            "DateAdded",
            new DateTime(2022, 3, 1, 15, 38, 21, 135, DateTimeKind.Local).AddTicks(1561));

        migrationBuilder.UpdateData(
            "Passes",
            "PassID",
            5,
            "DateAdded",
            new DateTime(2022, 3, 1, 15, 38, 21, 135, DateTimeKind.Local).AddTicks(1563));

        migrationBuilder.UpdateData(
            "Passes",
            "PassID",
            6,
            "DateAdded",
            new DateTime(2022, 3, 1, 15, 38, 21, 135, DateTimeKind.Local).AddTicks(1566));

        migrationBuilder.UpdateData(
            "Taxes",
            "TaxID",
            1,
            "DateAdded",
            new DateTime(2022, 3, 1, 15, 38, 21, 135, DateTimeKind.Local).AddTicks(1503));

        migrationBuilder.UpdateData(
            "Taxes",
            "TaxID",
            2,
            "DateAdded",
            new DateTime(2022, 3, 1, 15, 38, 21, 135, DateTimeKind.Local).AddTicks(1507));

        migrationBuilder.UpdateData(
            "Taxes",
            "TaxID",
            3,
            "DateAdded",
            new DateTime(2022, 3, 1, 15, 38, 21, 135, DateTimeKind.Local).AddTicks(1509));

        migrationBuilder.UpdateData(
            "Taxes",
            "TaxID",
            4,
            "DateAdded",
            new DateTime(2022, 3, 1, 15, 38, 21, 135, DateTimeKind.Local).AddTicks(1510));

        migrationBuilder.UpdateData(
            "Users",
            "UserID",
            1,
            "DateAdded",
            new DateTime(2022, 3, 1, 15, 38, 21, 135, DateTimeKind.Local).AddTicks(1350));
    }

    protected override void Up(MigrationBuilder migrationBuilder)
    {
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
}