using Microsoft.EntityFrameworkCore.Migrations;

namespace Flight.Services.ScheduleAPI.Migrations
{
    public partial class addmodelv5 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BusinessClassSeats",
                table: "ScheduleDetails",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "EconomySeats",
                table: "ScheduleDetails",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BusinessClassSeats",
                table: "ScheduleDetails");

            migrationBuilder.DropColumn(
                name: "EconomySeats",
                table: "ScheduleDetails");
        }
    }
}
