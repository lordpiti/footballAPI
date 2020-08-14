using Microsoft.EntityFrameworkCore.Migrations;

namespace Football.DataAccessEFCore3.Migrations
{
    public partial class addPosition : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Position",
                table: "Jugador",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Position",
                table: "Jugador");
        }
    }
}
