using Microsoft.EntityFrameworkCore.Migrations;

namespace Flight.Services.ScheduleAPI.Migrations
{
    public partial class addmodelv2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Seat_ScheduleDetails_ScheduleDetailsId",
                table: "Seat");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Seat",
                table: "Seat");

            migrationBuilder.RenameTable(
                name: "Seat",
                newName: "seats");

            migrationBuilder.RenameIndex(
                name: "IX_Seat_ScheduleDetailsId",
                table: "seats",
                newName: "IX_seats_ScheduleDetailsId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_seats",
                table: "seats",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_seats_ScheduleDetails_ScheduleDetailsId",
                table: "seats",
                column: "ScheduleDetailsId",
                principalTable: "ScheduleDetails",
                principalColumn: "ScheduleDetailsId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_seats_ScheduleDetails_ScheduleDetailsId",
                table: "seats");

            migrationBuilder.DropPrimaryKey(
                name: "PK_seats",
                table: "seats");

            migrationBuilder.RenameTable(
                name: "seats",
                newName: "Seat");

            migrationBuilder.RenameIndex(
                name: "IX_seats_ScheduleDetailsId",
                table: "Seat",
                newName: "IX_Seat_ScheduleDetailsId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Seat",
                table: "Seat",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Seat_ScheduleDetails_ScheduleDetailsId",
                table: "Seat",
                column: "ScheduleDetailsId",
                principalTable: "ScheduleDetails",
                principalColumn: "ScheduleDetailsId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
