using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Flight.Services.ScheduleAPI.Migrations
{
    public partial class addmodel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Flight",
                columns: table => new
                {
                    FlightId = table.Column<int>(type: "int", nullable: false),
                    FlightName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ContactNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ContactAddress = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LogoURL = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<string>(type: "nvarchar(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Flight", x => x.FlightId);
                });

            migrationBuilder.CreateTable(
                name: "ScheduleDetails",
                columns: table => new
                {
                    ScheduleDetailsId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FlightId = table.Column<int>(type: "int", nullable: false),
                    flightnumber = table.Column<int>(type: "int", nullable: false),
                    FromPlace = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ToPlace = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ScheduledDays = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Instrumentused = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    TotalSeats = table.Column<int>(type: "int", nullable: false),
                    EconomyCost = table.Column<double>(type: "float", nullable: false),
                    BusinessClassCost = table.Column<double>(type: "float", nullable: false),
                    NoOfRows = table.Column<int>(type: "int", nullable: false),
                    Meal = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UpdatedDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsActive = table.Column<string>(type: "nvarchar(1)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ScheduleDetails", x => x.ScheduleDetailsId);
                    table.ForeignKey(
                        name: "FK_ScheduleDetails_Flight_FlightId",
                        column: x => x.FlightId,
                        principalTable: "Flight",
                        principalColumn: "FlightId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Seat",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BusinessClassSeats = table.Column<int>(type: "int", nullable: false),
                    EconomyClassSeats = table.Column<int>(type: "int", nullable: false),
                    FlightId = table.Column<int>(type: "int", nullable: false),
                    ScheduleDetailsId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Seat", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Seat_ScheduleDetails_ScheduleDetailsId",
                        column: x => x.ScheduleDetailsId,
                        principalTable: "ScheduleDetails",
                        principalColumn: "ScheduleDetailsId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.InsertData(
                table: "Flight",
                columns: new[] { "FlightId", "ContactAddress", "ContactNumber", "CreatedDate", "FlightName", "IsActive", "LogoURL", "UpdatedDate" },
                values: new object[,]
                {
                    { 1, "Mumbai", "1234567890", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Air India", " ", "Null", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 2, "Delhi", "1234657890", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Vistara", " ", "Null", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 3, "Bangalore", "1243657890", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Go Air", " ", "Null", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 4, "Mumbai", "1243658790", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Indigo", " ", "Null", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) },
                    { 5, "Chennai", "1253658790", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "Spice Jet", " ", "Null", new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified) }
                });

            migrationBuilder.CreateIndex(
                name: "IX_ScheduleDetails_FlightId",
                table: "ScheduleDetails",
                column: "FlightId");

            migrationBuilder.CreateIndex(
                name: "IX_Seat_ScheduleDetailsId",
                table: "Seat",
                column: "ScheduleDetailsId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Seat");

            migrationBuilder.DropTable(
                name: "ScheduleDetails");

            migrationBuilder.DropTable(
                name: "Flight");
        }
    }
}
