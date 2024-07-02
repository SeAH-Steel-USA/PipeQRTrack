using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PipeQRTrack.Migrations
{
    /// <inheritdoc />
    public partial class columnstatuschange : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "status",
                table: "PipeDetails",
                newName: "Status");

            migrationBuilder.AlterColumn<string>(
                name: "Status",
                table: "PipeDetails",
                type: "nvarchar(1)",
                nullable: true,
                oldClrType: typeof(bool),
                oldType: "bit",
                oldNullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Status",
                table: "PipeDetails",
                newName: "status");

            migrationBuilder.AlterColumn<bool>(
                name: "status",
                table: "PipeDetails",
                type: "bit",
                nullable: true,
                oldClrType: typeof(string),
                oldType: "nvarchar(1)",
                oldNullable: true);
        }
    }
}
