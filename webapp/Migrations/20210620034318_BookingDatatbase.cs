using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace webapp.Migrations
{
    public partial class BookingDatatbase : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "BookingDetails",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", nullable: false),
                    EventName = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    NoOfTickets = table.Column<int>(type: "int", nullable: false),
                    EventLocation = table.Column<string>(type: "nvarchar(100)", nullable: false),
                    BookingDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BookingDetails", x => x.UserId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BookingDetails");
        }
    }
}
