using Microsoft.EntityFrameworkCore.Migrations;

namespace Flight.Services.ScheduleAPI.Migrations
{
    public partial class addmodelv4 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ScheduleDetails_seats_seatsId",
                table: "ScheduleDetails");

            migrationBuilder.DropTable(
                name: "seats");

            migrationBuilder.DropIndex(
                name: "IX_ScheduleDetails_seatsId",
                table: "ScheduleDetails");

            migrationBuilder.DropColumn(
                name: "seatsId",
                table: "ScheduleDetails");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "seatsId",
                table: "ScheduleDetails",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "seats",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BusinessClassSeats = table.Column<int>(type: "int", nullable: false),
                    EconomyClassSeats = table.Column<int>(type: "int", nullable: false),
                    FlightId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_seats", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ScheduleDetails_seatsId",
                table: "ScheduleDetails",
                column: "seatsId");

            migrationBuilder.AddForeignKey(
                name: "FK_ScheduleDetails_seats_seatsId",
                table: "ScheduleDetails",
                column: "seatsId",
                principalTable: "seats",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
