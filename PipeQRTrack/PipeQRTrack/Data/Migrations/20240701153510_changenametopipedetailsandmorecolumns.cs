using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PipeQRTrack.Migrations
{
    /// <inheritdoc />
    public partial class changenametopipedetailsandmorecolumns : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "WorkOrderDetails");

            migrationBuilder.CreateTable(
                name: "PipeDetails",
                columns: table => new
                {
                    Guid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    WorkOrder = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LotNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    JointNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    JobNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    HeatNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    status = table.Column<bool>(type: "bit", nullable: false),
                    DateTime = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Millitm = table.Column<short>(type: "smallint", nullable: true),
                    Val = table.Column<double>(type: "float", nullable: true),
                    Marker = table.Column<string>(type: "nvarchar(1)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PipeDetails", x => x.Guid);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PipeDetails");

            migrationBuilder.CreateTable(
                name: "WorkOrderDetails",
                columns: table => new
                {
                    Guid = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    DateSubmitted = table.Column<DateTime>(type: "datetime2", nullable: false),
                    JointNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LotNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    WorkOrder = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_WorkOrderDetails", x => x.Guid);
                });
        }
    }
}
