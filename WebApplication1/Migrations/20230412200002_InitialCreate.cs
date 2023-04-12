using System;
using Microsoft.EntityFrameworkCore.Migrations;
using Npgsql.EntityFrameworkCore.PostgreSQL.Metadata;

namespace BPR.API.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Administrators",
                columns: table => new
                {
                    AdministratorId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    AdministratorFirstName = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    AdministratorSurname = table.Column<string>(type: "text", nullable: true),
                    AdministratorEmail = table.Column<string>(type: "text", nullable: false),
                    AdministratorPhoneNumber = table.Column<string>(type: "character varying(16)", maxLength: 16, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Administrators", x => x.AdministratorId);
                });

            migrationBuilder.CreateTable(
                name: "AppointmentCategories",
                columns: table => new
                {
                    AppointmentCategoryId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    AppointmentCategoryName = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    AppointmentCategoryDuration = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AppointmentCategories", x => x.AppointmentCategoryId);
                });

            migrationBuilder.CreateTable(
                name: "Appointments",
                columns: table => new
                {
                    AppointmentId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    AppointmentDateCreated = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    AppointmentStartTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    AppointmentEndTimeExpected = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    AppointmentEndTime = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    AppointmentCancelled = table.Column<bool>(type: "boolean", nullable: false),
                    CustomerId = table.Column<int>(type: "integer", nullable: false),
                    AdministratorId = table.Column<int>(type: "integer", nullable: false),
                    AppointmentCategoryId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Appointments", x => x.AppointmentId);
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    CustomerId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    CustomerFirstName = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    CustomerSurname = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    Nationality = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    CustomerPhoneNumber = table.Column<string>(type: "character varying(16)", maxLength: 16, nullable: false),
                    CustomerEmail = table.Column<string>(type: "text", nullable: false),
                    CustomerStreetName = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    CustomerStreetNumber = table.Column<string>(type: "text", nullable: true),
                    CustomerPostalCode = table.Column<string>(type: "character varying(14)", maxLength: 14, nullable: false),
                    CustomerCity = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    CustomerCountry = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    CustomerRegistered = table.Column<bool>(type: "boolean", nullable: false),
                    CustomerPassportNumber = table.Column<string>(type: "text", nullable: true),
                    CustomerIdNumber = table.Column<string>(type: "text", nullable: false),
                    CustomerAccountCreation = table.Column<DateTime>(type: "timestamp without time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.CustomerId);
                });

            migrationBuilder.CreateTable(
                name: "Facilities",
                columns: table => new
                {
                    FacilityId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    FacilityName = table.Column<string>(type: "text", nullable: false),
                    FacilityDescription = table.Column<string>(type: "text", nullable: true),
                    KamtjatkaInfoId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Facilities", x => x.FacilityId);
                });

            migrationBuilder.CreateTable(
                name: "FinanceCategories",
                columns: table => new
                {
                    FinanceCategoryId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    FinanceCategoryName = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FinanceCategories", x => x.FinanceCategoryId);
                });

            migrationBuilder.CreateTable(
                name: "Finances",
                columns: table => new
                {
                    FinanceId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    FinanceName = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    FinanceAmountOfMoney = table.Column<string>(type: "text", nullable: false),
                    FinanceDescription = table.Column<string>(type: "text", nullable: true),
                    CustomerId = table.Column<int>(type: "integer", nullable: false),
                    FinanceCategoryId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Finances", x => x.FinanceId);
                });

            migrationBuilder.CreateTable(
                name: "KamtjatkaInfos",
                columns: table => new
                {
                    KamtjatkaInfoId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    KamtjatkaInfoStreetName = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    KamtjatkaInfoStreetNumber = table.Column<string>(type: "character varying(10)", maxLength: 10, nullable: false),
                    KamtjatkaInfoPostalCode = table.Column<string>(type: "character varying(20)", maxLength: 20, nullable: false),
                    KamtjatkaInfoCity = table.Column<string>(type: "character varying(30)", maxLength: 30, nullable: false),
                    KamtjatkaInfoCountry = table.Column<string>(type: "character varying(50)", maxLength: 50, nullable: false),
                    KamtjatkaInforPhoneNumber = table.Column<string>(type: "character varying(16)", maxLength: 16, nullable: false),
                    AdministratorId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_KamtjatkaInfos", x => x.KamtjatkaInfoId);
                });

            migrationBuilder.CreateTable(
                name: "RoomBookings",
                columns: table => new
                {
                    RoomBookingId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    RoomId = table.Column<int>(type: "integer", nullable: false),
                    CustomerId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoomBookings", x => x.RoomBookingId);
                });

            migrationBuilder.CreateTable(
                name: "RoomCategories",
                columns: table => new
                {
                    RoomCategoryId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    RoomCategoryName = table.Column<string>(type: "text", nullable: false),
                    RoomCategoryDescription = table.Column<string>(type: "text", nullable: true),
                    RoomCategoryNumberOfRooms = table.Column<int>(type: "integer", nullable: false),
                    RoomCategoryUtilities = table.Column<string>(type: "text", nullable: false),
                    RoomCategoryRentPrice = table.Column<string>(type: "text", nullable: false),
                    RoomCategoryDeposit = table.Column<string>(type: "text", nullable: false),
                    RoomCategoryPictureLink = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RoomCategories", x => x.RoomCategoryId);
                });

            migrationBuilder.CreateTable(
                name: "Rooms",
                columns: table => new
                {
                    RoomId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    RoomNumber = table.Column<string>(type: "text", nullable: false),
                    RoomCategoryId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Rooms", x => x.RoomId);
                });

            migrationBuilder.CreateTable(
                name: "Schedules",
                columns: table => new
                {
                    ScheduleId = table.Column<int>(type: "integer", nullable: false)
                        .Annotation("Npgsql:ValueGenerationStrategy", NpgsqlValueGenerationStrategy.IdentityByDefaultColumn),
                    ScheduleFrom = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    ScheduleTo = table.Column<DateTime>(type: "timestamp without time zone", nullable: false),
                    AdministratorId = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Schedules", x => x.ScheduleId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Administrators");

            migrationBuilder.DropTable(
                name: "AppointmentCategories");

            migrationBuilder.DropTable(
                name: "Appointments");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropTable(
                name: "Facilities");

            migrationBuilder.DropTable(
                name: "FinanceCategories");

            migrationBuilder.DropTable(
                name: "Finances");

            migrationBuilder.DropTable(
                name: "KamtjatkaInfos");

            migrationBuilder.DropTable(
                name: "RoomBookings");

            migrationBuilder.DropTable(
                name: "RoomCategories");

            migrationBuilder.DropTable(
                name: "Rooms");

            migrationBuilder.DropTable(
                name: "Schedules");
        }
    }
}
