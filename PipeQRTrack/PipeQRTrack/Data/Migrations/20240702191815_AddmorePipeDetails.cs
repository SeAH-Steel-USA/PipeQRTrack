using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PipeQRTrack.Migrations
{
    /// <inheritdoc />
    public partial class AddmorePipeDetails : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PipeDetails");

            migrationBuilder.CreateTable(
                name: "PipeDetailComplete",
                columns: table => new
                {
                    Guid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    WorkOrder = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LotNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    JointNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    JobNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HeatNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(1)", nullable: true),
                    DateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Millitm = table.Column<short>(type: "smallint", nullable: true),
                    Val = table.Column<double>(type: "float", nullable: true),
                    Marker = table.Column<string>(type: "nvarchar(1)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PipeDetailComplete", x => x.Guid);
                });

            migrationBuilder.CreateTable(
                name: "PipeDetailP1TLC1",
                columns: table => new
                {
                    Guid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    WorkOrder = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LotNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    JointNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    JobNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HeatNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(1)", nullable: true),
                    DateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Millitm = table.Column<short>(type: "smallint", nullable: true),
                    Val = table.Column<double>(type: "float", nullable: true),
                    Marker = table.Column<string>(type: "nvarchar(1)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PipeDetailP1TLC1", x => x.Guid);
                });

            migrationBuilder.CreateTable(
                name: "PipeDetailP1TLC2",
                columns: table => new
                {
                    Guid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    WorkOrder = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LotNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    JointNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    JobNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    HeatNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(1)", nullable: true),
                    DateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Millitm = table.Column<short>(type: "smallint", nullable: true),
                    Val = table.Column<double>(type: "float", nullable: true),
                    Marker = table.Column<string>(type: "nvarchar(1)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PipeDetailP1TLC2", x => x.Guid);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PipeDetailComplete");

            migrationBuilder.DropTable(
                name: "PipeDetailP1TLC1");

            migrationBuilder.DropTable(
                name: "PipeDetailP1TLC2");

            migrationBuilder.CreateTable(
                name: "PipeDetails",
                columns: table => new
                {
                    Guid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    HeatNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    JobNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    JointNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LotNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Marker = table.Column<string>(type: "nvarchar(1)", nullable: true),
                    Millitm = table.Column<short>(type: "smallint", nullable: true),
                    Status = table.Column<string>(type: "nvarchar(1)", nullable: true),
                    Val = table.Column<double>(type: "float", nullable: true),
                    WorkOrder = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PipeDetails", x => x.Guid);
                });
        }
    }
}
