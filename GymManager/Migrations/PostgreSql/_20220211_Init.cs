#nullable disable

using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace GymManager.Migrations.PostgreSql
{
    public partial class _20220211_Init : Migration
    {
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                "DataTrackingDefinitions");

            migrationBuilder.DropTable(
                "EntriesRegistry");

            migrationBuilder.DropTable(
                "Identifiers");

            migrationBuilder.DropTable(
                "Messages");

            migrationBuilder.DropTable(
                "PassesRegistry");

            migrationBuilder.DropTable(
                "PermissionsUsers");

            migrationBuilder.DropTable(
                "Photos");

            migrationBuilder.DropTable(
                "DataTrackings");

            migrationBuilder.DropTable(
                "CabinetKeys");

            migrationBuilder.DropTable(
                "MediaCarriers");

            migrationBuilder.DropTable(
                "PermissionsList");

            migrationBuilder.DropTable(
                "Members");

            migrationBuilder.DropTable(
                "DataTrackingOperations");

            migrationBuilder.DropTable(
                "Genders");

            migrationBuilder.DropTable(
                "Passes");

            migrationBuilder.DropTable(
                "PassTimes");

            migrationBuilder.DropTable(
                "Taxes");

            migrationBuilder.DropTable(
                "Users");
        }

        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                "DataTrackingOperations",
                table => new
                {
                    DataTrackingOperationID = table.Column<int>("integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy",
                            NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>("character varying(50)", maxLength: 50, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DataTrackingOperations", x => x.DataTrackingOperationID);
                });

            migrationBuilder.CreateTable(
                "Genders",
                table => new
                {
                    GenderID = table.Column<int>("integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy",
                            NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>("text", nullable: false)
                },
                constraints: table => { table.PrimaryKey("PK_Genders", x => x.GenderID); });

            migrationBuilder.CreateTable(
                "MediaCarriers",
                table => new
                {
                    MediaCarrierID = table.Column<int>("integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy",
                            NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>("character varying(50)", maxLength: 50, nullable: false),
                    IsAcive = table.Column<bool>("boolean", nullable: false)
                },
                constraints: table => { table.PrimaryKey("PK_MediaCarriers", x => x.MediaCarrierID); });

            migrationBuilder.CreateTable(
                "PassTimes",
                table => new
                {
                    PassTimeID = table.Column<int>("integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy",
                            NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>("character varying(50)", maxLength: 50, nullable: false)
                },
                constraints: table => { table.PrimaryKey("PK_PassTimes", x => x.PassTimeID); });

            migrationBuilder.CreateTable(
                "PermissionsList",
                table => new
                {
                    PermissionListID = table.Column<int>("integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy",
                            NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>("text", nullable: false)
                },
                constraints: table => { table.PrimaryKey("PK_PermissionsList", x => x.PermissionListID); });

            migrationBuilder.CreateTable(
                "Taxes",
                table => new
                {
                    TaxID = table.Column<int>("integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy",
                            NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>("character varying(50)", maxLength: 50, nullable: false),
                    Rate = table.Column<int>("integer", nullable: false),
                    DateAdded = table.Column<DateTime>("timestamp with time zone", nullable: false),
                    IsAcive = table.Column<bool>("boolean", nullable: false)
                },
                constraints: table => { table.PrimaryKey("PK_Taxes", x => x.TaxID); });

            migrationBuilder.CreateTable(
                "Users",
                table => new
                {
                    UserID = table.Column<int>("integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy",
                            NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    UserName = table.Column<string>("character varying(50)", maxLength: 50, nullable: false),
                    Password = table.Column<string>("character varying(50)", maxLength: 50, nullable: false),
                    FirstName = table.Column<string>("character varying(50)", maxLength: 50, nullable: false),
                    LastName = table.Column<string>("character varying(50)", maxLength: 50, nullable: false),
                    Email = table.Column<string>("character varying(50)", maxLength: 50, nullable: true),
                    Phone = table.Column<string>("character varying(50)", maxLength: 50, nullable: true),
                    DateAdded = table.Column<DateTime>("timestamp with time zone", nullable: false),
                    DateModified = table.Column<DateTime>("timestamp with time zone", nullable: true),
                    IsAdmin = table.Column<bool>("boolean", nullable: false),
                    IsAcive = table.Column<bool>("boolean", nullable: false),
                    AddedBy = table.Column<int>("integer", nullable: true),
                    ModifiedBy = table.Column<int>("integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserID);
                    table.ForeignKey(
                        "FK_Users_Users_AddedBy",
                        x => x.AddedBy,
                        "Users",
                        "UserID");
                    table.ForeignKey(
                        "FK_Users_Users_ModifiedBy",
                        x => x.ModifiedBy,
                        "Users",
                        "UserID");
                });

            migrationBuilder.CreateTable(
                "CabinetKeys",
                table => new
                {
                    CabinetKeyID = table.Column<int>("integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy",
                            NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>("character varying(50)", maxLength: 50, nullable: false),
                    DateAdded = table.Column<DateTime>("timestamp with time zone", nullable: false),
                    DateModified = table.Column<DateTime>("timestamp with time zone", nullable: true),
                    AddedBy = table.Column<int>("integer", nullable: true),
                    ModifiedBy = table.Column<int>("integer", nullable: true),
                    IsAcive = table.Column<bool>("boolean", nullable: false),
                    GenderID = table.Column<int>("integer", nullable: true),
                    LastUsedDate = table.Column<DateTime>("timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CabinetKeys", x => x.CabinetKeyID);
                    table.ForeignKey(
                        "FK_CabinetKeys_Genders_GenderID",
                        x => x.GenderID,
                        "Genders",
                        "GenderID");
                    table.ForeignKey(
                        "FK_CabinetKeys_Users_AddedBy",
                        x => x.AddedBy,
                        "Users",
                        "UserID");
                    table.ForeignKey(
                        "FK_CabinetKeys_Users_ModifiedBy",
                        x => x.ModifiedBy,
                        "Users",
                        "UserID");
                });

            migrationBuilder.CreateTable(
                "DataTrackings",
                table => new
                {
                    DataTrackingID = table.Column<int>("integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy",
                            NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    DataTrackingOperationID = table.Column<int>("integer", nullable: false),
                    TableName = table.Column<string>("character varying(50)", maxLength: 50, nullable: false),
                    PrimaryKey = table.Column<string>("character varying(50)", maxLength: 50, nullable: true),
                    DateAdded = table.Column<DateTime>("timestamp with time zone", nullable: false),
                    AddedBy = table.Column<int>("integer", nullable: true),
                    ModifiedBy = table.Column<int>("integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DataTrackings", x => x.DataTrackingID);
                    table.ForeignKey(
                        "FK_DataTrackings_DataTrackingOperations_DataTrackingOperationID",
                        x => x.DataTrackingOperationID,
                        "DataTrackingOperations",
                        "DataTrackingOperationID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        "FK_DataTrackings_Users_AddedBy",
                        x => x.AddedBy,
                        "Users",
                        "UserID");
                    table.ForeignKey(
                        "FK_DataTrackings_Users_ModifiedBy",
                        x => x.ModifiedBy,
                        "Users",
                        "UserID");
                });

            migrationBuilder.CreateTable(
                "Passes",
                table => new
                {
                    PassID = table.Column<int>("integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy",
                            NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    Name = table.Column<string>("text", nullable: false),
                    Description = table.Column<string>("text", nullable: false),
                    EntryNetPrice = table.Column<decimal>("numeric(9,2)", nullable: false),
                    EntryPrice = table.Column<decimal>("numeric(9,2)", nullable: false),
                    NetPrice = table.Column<decimal>("numeric(9,2)", nullable: false),
                    Price = table.Column<decimal>("numeric(9,2)", nullable: false),
                    TaxID = table.Column<int>("integer", nullable: false),
                    PassTimeID = table.Column<int>("integer", nullable: false),
                    AccessTimeFrom = table.Column<DateTime>("timestamp with time zone", nullable: true),
                    AccessTimeTo = table.Column<DateTime>("timestamp with time zone", nullable: true),
                    Continuation = table.Column<bool>("boolean", nullable: false),
                    DateAdded = table.Column<DateTime>("timestamp with time zone", nullable: false),
                    DateModified = table.Column<DateTime>("timestamp with time zone", nullable: true),
                    AddedBy = table.Column<int>("integer", nullable: true),
                    ModifiedBy = table.Column<int>("integer", nullable: true),
                    IsAcive = table.Column<bool>("boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Passes", x => x.PassID);
                    table.ForeignKey(
                        "FK_Passes_PassTimes_PassTimeID",
                        x => x.PassTimeID,
                        "PassTimes",
                        "PassTimeID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        "FK_Passes_Taxes_TaxID",
                        x => x.TaxID,
                        "Taxes",
                        "TaxID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        "FK_Passes_Users_AddedBy",
                        x => x.AddedBy,
                        "Users",
                        "UserID");
                    table.ForeignKey(
                        "FK_Passes_Users_ModifiedBy",
                        x => x.ModifiedBy,
                        "Users",
                        "UserID");
                });

            migrationBuilder.CreateTable(
                "PermissionsUsers",
                table => new
                {
                    PermissionUserID = table.Column<int>("integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy",
                            NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    PermissionListID = table.Column<int>("integer", nullable: false),
                    UserID = table.Column<int>("integer", nullable: false),
                    DateAdded = table.Column<DateTime>("timestamp with time zone", nullable: false),
                    AddedBy = table.Column<int>("integer", nullable: true)
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

            migrationBuilder.CreateTable(
                "DataTrackingDefinitions",
                table => new
                {
                    DataTrackingDefinitionID = table.Column<int>("integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy",
                            NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    DataTrackingID = table.Column<int>("integer", nullable: false),
                    ColumnName = table.Column<string>("text", nullable: true),
                    OldData = table.Column<string>("text", nullable: false),
                    NewData = table.Column<string>("text", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DataTrackingDefinitions", x => x.DataTrackingDefinitionID);
                    table.ForeignKey(
                        "FK_DataTrackingDefinitions_DataTrackings_DataTrackingID",
                        x => x.DataTrackingID,
                        "DataTrackings",
                        "DataTrackingID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                "Members",
                table => new
                {
                    MemberID = table.Column<int>("integer", nullable: false)
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
                    Email = table.Column<string>("character varying(50)", maxLength: 50, nullable: true),
                    PassID = table.Column<int>("integer", nullable: true),
                    DateAdded = table.Column<DateTime>("timestamp with time zone", nullable: false),
                    DateModified = table.Column<DateTime>("timestamp with time zone", nullable: true),
                    AddedBy = table.Column<int>("integer", nullable: true),
                    ModifiedBy = table.Column<int>("integer", nullable: true),
                    IsAcive = table.Column<bool>("boolean", nullable: false),
                    GenderID = table.Column<int>("integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Members", x => x.MemberID);
                    table.ForeignKey(
                        "FK_Members_Genders_GenderID",
                        x => x.GenderID,
                        "Genders",
                        "GenderID");
                    table.ForeignKey(
                        "FK_Members_Passes_PassID",
                        x => x.PassID,
                        "Passes",
                        "PassID");
                    table.ForeignKey(
                        "FK_Members_Users_AddedBy",
                        x => x.AddedBy,
                        "Users",
                        "UserID");
                    table.ForeignKey(
                        "FK_Members_Users_ModifiedBy",
                        x => x.ModifiedBy,
                        "Users",
                        "UserID");
                });

            migrationBuilder.CreateTable(
                "EntriesRegistry",
                table => new
                {
                    EntryRegistryID = table.Column<int>("integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy",
                            NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    MemberID = table.Column<int>("integer", nullable: false),
                    CabinetKeyID = table.Column<int>("integer", nullable: true),
                    EntryDate = table.Column<DateTime>("timestamp with time zone", nullable: false),
                    ExitDate = table.Column<DateTime>("timestamp with time zone", nullable: true),
                    VisitTime = table.Column<int>("integer", nullable: true),
                    IsAcive = table.Column<bool>("boolean", nullable: false),
                    ModifiedBy = table.Column<int>("integer", nullable: true),
                    PassID = table.Column<int>("integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EntriesRegistry", x => x.EntryRegistryID);
                    table.ForeignKey(
                        "FK_EntriesRegistry_CabinetKeys_CabinetKeyID",
                        x => x.CabinetKeyID,
                        "CabinetKeys",
                        "CabinetKeyID");
                    table.ForeignKey(
                        "FK_EntriesRegistry_Members_MemberID",
                        x => x.MemberID,
                        "Members",
                        "MemberID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        "FK_EntriesRegistry_Passes_PassID",
                        x => x.PassID,
                        "Passes",
                        "PassID");
                    table.ForeignKey(
                        "FK_EntriesRegistry_Users_ModifiedBy",
                        x => x.ModifiedBy,
                        "Users",
                        "UserID");
                });

            migrationBuilder.CreateTable(
                "Identifiers",
                table => new
                {
                    IdentifierID = table.Column<int>("integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy",
                            NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    MemberID = table.Column<int>("integer", nullable: false),
                    MediaCarrierID = table.Column<int>("integer", nullable: false),
                    Key = table.Column<string>("character varying(50)", maxLength: 50, nullable: false),
                    DateAdded = table.Column<DateTime>("timestamp with time zone", nullable: false),
                    DateModified = table.Column<DateTime>("timestamp with time zone", nullable: true),
                    AddedBy = table.Column<int>("integer", nullable: true),
                    ModifiedBy = table.Column<int>("integer", nullable: true),
                    IsAcive = table.Column<bool>("boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Identifiers", x => x.IdentifierID);
                    table.ForeignKey(
                        "FK_Identifiers_MediaCarriers_MediaCarrierID",
                        x => x.MediaCarrierID,
                        "MediaCarriers",
                        "MediaCarrierID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        "FK_Identifiers_Members_MemberID",
                        x => x.MemberID,
                        "Members",
                        "MemberID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        "FK_Identifiers_Users_AddedBy",
                        x => x.AddedBy,
                        "Users",
                        "UserID");
                    table.ForeignKey(
                        "FK_Identifiers_Users_ModifiedBy",
                        x => x.ModifiedBy,
                        "Users",
                        "UserID");
                });

            migrationBuilder.CreateTable(
                "Messages",
                table => new
                {
                    MessageID = table.Column<int>("integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy",
                            NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    MemberID = table.Column<int>("integer", nullable: false),
                    TextMessage = table.Column<string>("text", nullable: false),
                    IsEmail = table.Column<bool>("boolean", nullable: false),
                    IsSms = table.Column<bool>("boolean", nullable: false),
                    EmailSent = table.Column<bool>("boolean", nullable: false),
                    SmsSent = table.Column<bool>("boolean", nullable: false),
                    DateAdded = table.Column<DateTime>("timestamp with time zone", nullable: false),
                    IsAcive = table.Column<bool>("boolean", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Messages", x => x.MessageID);
                    table.ForeignKey(
                        "FK_Messages_Members_MemberID",
                        x => x.MemberID,
                        "Members",
                        "MemberID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                "PassesRegistry",
                table => new
                {
                    PassRegistryID = table.Column<int>("integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy",
                            NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    MemberID = table.Column<int>("integer", nullable: false),
                    PassID = table.Column<int>("integer", nullable: false),
                    StartDate = table.Column<DateTime>("timestamp with time zone", nullable: false),
                    EndDate = table.Column<DateTime>("timestamp with time zone", nullable: true),
                    PaymentDate = table.Column<DateTime>("timestamp with time zone", nullable: true),
                    Comment = table.Column<string>("text", nullable: true),
                    DateAdded = table.Column<DateTime>("timestamp with time zone", nullable: false),
                    DateModified = table.Column<DateTime>("timestamp with time zone", nullable: true),
                    Continuation = table.Column<bool>("boolean", nullable: false),
                    AddedBy = table.Column<int>("integer", nullable: true),
                    ModifiedBy = table.Column<int>("integer", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PassesRegistry", x => x.PassRegistryID);
                    table.ForeignKey(
                        "FK_PassesRegistry_Members_MemberID",
                        x => x.MemberID,
                        "Members",
                        "MemberID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        "FK_PassesRegistry_Passes_PassID",
                        x => x.PassID,
                        "Passes",
                        "PassID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        "FK_PassesRegistry_Users_AddedBy",
                        x => x.AddedBy,
                        "Users",
                        "UserID");
                    table.ForeignKey(
                        "FK_PassesRegistry_Users_ModifiedBy",
                        x => x.ModifiedBy,
                        "Users",
                        "UserID");
                });

            migrationBuilder.CreateTable(
                "Photos",
                table => new
                {
                    PhotoID = table.Column<int>("integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy",
                            NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    MemberID = table.Column<int>("integer", nullable: false),
                    Data = table.Column<byte[]>("bytea", nullable: true),
                    DateAdded = table.Column<DateTime>("timestamp with time zone", nullable: false),
                    DateModified = table.Column<DateTime>("timestamp with time zone", nullable: true),
                    AddedBy = table.Column<int>("integer", nullable: true),
                    ModifiedBy = table.Column<int>("integer", nullable: true)
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

            migrationBuilder.InsertData(
                "DataTrackingOperations",
                new[] { "DataTrackingOperationID", "Name" },
                new object[,]
                {
                    { 1, "DODAWANIE" },
                    { 2, "EDYTOWANIE" },
                    { 3, "USUWANIE" }
                });

            migrationBuilder.InsertData(
                "Genders",
                new[] { "GenderID", "Name" },
                new object[,]
                {
                    { 1, "NIE PODANO" },
                    { 2, "MĘŻCZYZNA" },
                    { 3, "KOBIETA" }
                });

            migrationBuilder.InsertData(
                "MediaCarriers",
                new[] { "MediaCarrierID", "IsAcive", "Name" },
                new object[] { 1, true, "KARTA RFID" });

            migrationBuilder.InsertData(
                "PassTimes",
                new[] { "PassTimeID", "Name" },
                new object[,]
                {
                    { 1, "Dzień" },
                    { 2, "Tydzień" },
                    { 3, "Miesiąć" },
                    { 4, "Rok" },
                    { 5, "Nieskonczony" }
                });

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

            migrationBuilder.InsertData(
                "Taxes",
                new[] { "TaxID", "DateAdded", "IsAcive", "Name", "Rate" },
                new object[,]
                {
                    { 1, new DateTime(2022, 2, 11, 11, 15, 14, 212, DateTimeKind.Local).AddTicks(1656), true, "A", 23 },
                    { 2, new DateTime(2022, 2, 11, 11, 15, 14, 212, DateTimeKind.Local).AddTicks(1661), true, "B", 8 },
                    { 3, new DateTime(2022, 2, 11, 11, 15, 14, 212, DateTimeKind.Local).AddTicks(1664), true, "C", 5 },
                    { 4, new DateTime(2022, 2, 11, 11, 15, 14, 212, DateTimeKind.Local).AddTicks(1666), true, "D", 0 }
                });

            migrationBuilder.InsertData(
                "Users",
                new[]
                {
                    "UserID", "AddedBy", "DateAdded", "DateModified", "Email", "FirstName", "IsAcive", "IsAdmin",
                    "LastName", "ModifiedBy", "Password", "Phone", "UserName"
                },
                new object[]
                {
                    1, null, new DateTime(2022, 2, 11, 11, 15, 14, 212, DateTimeKind.Local).AddTicks(1490), null, null,
                    "Administrator", true, true, "systemu", null, "21232f297a57a5a743894a0e4a801fc3", null, "admin"
                });

            migrationBuilder.InsertData(
                "Passes",
                new[]
                {
                    "PassID", "AccessTimeFrom", "AccessTimeTo", "AddedBy", "Continuation", "DateAdded", "DateModified",
                    "Description", "EntryNetPrice", "EntryPrice", "IsAcive", "ModifiedBy", "Name", "NetPrice",
                    "PassTimeID",
                    "Price", "TaxID"
                },
                new object[,]
                {
                    {
                        1, null, null, 1, true,
                        new DateTime(2022, 2, 11, 11, 15, 14, 212, DateTimeKind.Local).AddTicks(1706), null, "", 0m, 0m,
                        true, null, "BRAK", 0m, 5, 0m, 4
                    },
                    {
                        2, null, null, 1, true,
                        new DateTime(2022, 2, 11, 11, 15, 14, 212, DateTimeKind.Local).AddTicks(1715), null,
                        "Wstpęp wolny na miesiąc", 20.00m, 18.52m, true, null, "OPEN", 100.93m, 3, 109.00m, 2
                    },
                    {
                        3, new DateTime(2000, 1, 1, 9, 0, 0, 0, DateTimeKind.Unspecified),
                        new DateTime(2000, 1, 1, 14, 0, 0, 0, DateTimeKind.Unspecified), 1, true,
                        new DateTime(2022, 2, 11, 11, 15, 14, 212, DateTimeKind.Local).AddTicks(1723), null,
                        "Wstpęp wolny w godz. 9-14 na miesiąc", 20.00m, 18.52m, true, null, "OPEN PORANNY", 73.15m, 3,
                        79.00m, 2
                    },
                    {
                        4, null, null, 1, true,
                        new DateTime(2022, 2, 11, 11, 15, 14, 212, DateTimeKind.Local).AddTicks(1726), null,
                        "Wstpęp wolny dla studentów", 0m, 0m, true, null, "STUDENT", 91.67m, 3, 99.00m, 2
                    },
                    {
                        5, null, null, 1, true,
                        new DateTime(2022, 2, 11, 11, 15, 14, 212, DateTimeKind.Local).AddTicks(1729), null,
                        "Wstpęp wolny na miesiąc", 0m, 0m, true, null, "PROMOCJA LUTY2022", 91.67m, 3, 99.00m, 2
                    },
                    {
                        6, null, null, 1, true,
                        new DateTime(2022, 2, 11, 11, 15, 14, 212, DateTimeKind.Local).AddTicks(1732), null,
                        "Wstpęp jednorazowy", 0m, 0m, true, null, "JEDNORAZOWY", 18.52m, 3, 20.00m, 2
                    }
                });

            migrationBuilder.CreateIndex(
                "IX_CabinetKeys_AddedBy",
                "CabinetKeys",
                "AddedBy");

            migrationBuilder.CreateIndex(
                "IX_CabinetKeys_GenderID",
                "CabinetKeys",
                "GenderID");

            migrationBuilder.CreateIndex(
                "IX_CabinetKeys_ModifiedBy",
                "CabinetKeys",
                "ModifiedBy");

            migrationBuilder.CreateIndex(
                "IX_CabinetKeys_Name",
                "CabinetKeys",
                "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                "IX_DataTrackingDefinitions_DataTrackingID",
                "DataTrackingDefinitions",
                "DataTrackingID");

            migrationBuilder.CreateIndex(
                "IX_DataTrackingOperations_Name",
                "DataTrackingOperations",
                "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                "IX_DataTrackings_AddedBy",
                "DataTrackings",
                "AddedBy");

            migrationBuilder.CreateIndex(
                "IX_DataTrackings_DataTrackingOperationID",
                "DataTrackings",
                "DataTrackingOperationID");

            migrationBuilder.CreateIndex(
                "IX_DataTrackings_ModifiedBy",
                "DataTrackings",
                "ModifiedBy");

            migrationBuilder.CreateIndex(
                "IX_EntriesRegistry_CabinetKeyID",
                "EntriesRegistry",
                "CabinetKeyID");

            migrationBuilder.CreateIndex(
                "IX_EntriesRegistry_MemberID",
                "EntriesRegistry",
                "MemberID");

            migrationBuilder.CreateIndex(
                "IX_EntriesRegistry_ModifiedBy",
                "EntriesRegistry",
                "ModifiedBy");

            migrationBuilder.CreateIndex(
                "IX_EntriesRegistry_PassID",
                "EntriesRegistry",
                "PassID");

            migrationBuilder.CreateIndex(
                "IX_Genders_Name",
                "Genders",
                "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                "IX_Identifiers_AddedBy",
                "Identifiers",
                "AddedBy");

            migrationBuilder.CreateIndex(
                "IX_Identifiers_Key",
                "Identifiers",
                "Key",
                unique: true);

            migrationBuilder.CreateIndex(
                "IX_Identifiers_MediaCarrierID",
                "Identifiers",
                "MediaCarrierID");

            migrationBuilder.CreateIndex(
                "IX_Identifiers_MemberID",
                "Identifiers",
                "MemberID");

            migrationBuilder.CreateIndex(
                "IX_Identifiers_ModifiedBy",
                "Identifiers",
                "ModifiedBy");

            migrationBuilder.CreateIndex(
                "IX_MediaCarriers_Name",
                "MediaCarriers",
                "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                "IX_Members_AddedBy",
                "Members",
                "AddedBy");

            migrationBuilder.CreateIndex(
                "IX_Members_GenderID",
                "Members",
                "GenderID");

            migrationBuilder.CreateIndex(
                "IX_Members_Id",
                "Members",
                "Id",
                unique: true);

            migrationBuilder.CreateIndex(
                "IX_Members_ModifiedBy",
                "Members",
                "ModifiedBy");

            migrationBuilder.CreateIndex(
                "IX_Members_PassID",
                "Members",
                "PassID");

            migrationBuilder.CreateIndex(
                "IX_Messages_MemberID",
                "Messages",
                "MemberID");

            migrationBuilder.CreateIndex(
                "IX_Passes_AddedBy",
                "Passes",
                "AddedBy");

            migrationBuilder.CreateIndex(
                "IX_Passes_ModifiedBy",
                "Passes",
                "ModifiedBy");

            migrationBuilder.CreateIndex(
                "IX_Passes_Name",
                "Passes",
                "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                "IX_Passes_PassTimeID",
                "Passes",
                "PassTimeID");

            migrationBuilder.CreateIndex(
                "IX_Passes_TaxID",
                "Passes",
                "TaxID");

            migrationBuilder.CreateIndex(
                "IX_PassesRegistry_AddedBy",
                "PassesRegistry",
                "AddedBy");

            migrationBuilder.CreateIndex(
                "IX_PassesRegistry_MemberID",
                "PassesRegistry",
                "MemberID");

            migrationBuilder.CreateIndex(
                "IX_PassesRegistry_ModifiedBy",
                "PassesRegistry",
                "ModifiedBy");

            migrationBuilder.CreateIndex(
                "IX_PassesRegistry_PassID",
                "PassesRegistry",
                "PassID");

            migrationBuilder.CreateIndex(
                "IX_PassTimes_Name",
                "PassTimes",
                "Name",
                unique: true);

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

            migrationBuilder.CreateIndex(
                "IX_Taxes_Name",
                "Taxes",
                "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                "IX_Users_AddedBy",
                "Users",
                "AddedBy");

            migrationBuilder.CreateIndex(
                "IX_Users_ModifiedBy",
                "Users",
                "ModifiedBy");

            migrationBuilder.CreateIndex(
                "IX_Users_UserName",
                "Users",
                "UserName",
                unique: true);
        }
    }
}