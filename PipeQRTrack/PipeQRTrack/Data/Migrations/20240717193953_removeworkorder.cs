using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PipeQRTrack.Migrations
{
    /// <inheritdoc />
    public partial class removeworkorder : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "WorkOrder",
                table: "PipeDetailP1TLC2");

            migrationBuilder.DropColumn(
                name: "WorkOrder",
                table: "PipeDetailP1TLC1");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "WorkOrder",
                table: "PipeDetailP1TLC2",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "WorkOrder",
                table: "PipeDetailP1TLC1",
                type: "nvarchar(max)",
                nullable: true);
        }
    }
}
