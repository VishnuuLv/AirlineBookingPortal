using Microsoft.EntityFrameworkCore.Migrations;

namespace Flight.Services.ScheduleAPI.Migrations
{
    public partial class addmodelv3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_seats_ScheduleDetails_ScheduleDetailsId",
                table: "seats");

            migrationBuilder.DropIndex(
                name: "IX_seats_ScheduleDetailsId",
                table: "seats");

            migrationBuilder.DropColumn(
                name: "ScheduleDetailsId",
                table: "seats");

            migrationBuilder.AddColumn<int>(
                name: "seatsId",
                table: "ScheduleDetails",
                type: "int",
                nullable: true);

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

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ScheduleDetails_seats_seatsId",
                table: "ScheduleDetails");

            migrationBuilder.DropIndex(
                name: "IX_ScheduleDetails_seatsId",
                table: "ScheduleDetails");

            migrationBuilder.DropColumn(
                name: "seatsId",
                table: "ScheduleDetails");

            migrationBuilder.AddColumn<int>(
                name: "ScheduleDetailsId",
                table: "seats",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_seats_ScheduleDetailsId",
                table: "seats",
                column: "ScheduleDetailsId");

            migrationBuilder.AddForeignKey(
                name: "FK_seats_ScheduleDetails_ScheduleDetailsId",
                table: "seats",
                column: "ScheduleDetailsId",
                principalTable: "ScheduleDetails",
                principalColumn: "ScheduleDetailsId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
