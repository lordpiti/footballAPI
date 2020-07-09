using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Football.DataAccessEFCore3.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
           
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "abono");

            migrationBuilder.DropTable(
                name: "agenda");

            migrationBuilder.DropTable(
                name: "asiento");

            migrationBuilder.DropTable(
                name: "Calendario");

            migrationBuilder.DropTable(
                name: "Cambio");

            migrationBuilder.DropTable(
                name: "Clasificacion");

            migrationBuilder.DropTable(
                name: "Comentario");

            migrationBuilder.DropTable(
                name: "Countries");

            migrationBuilder.DropTable(
                name: "Directivo");

            migrationBuilder.DropTable(
                name: "Entrenador");

            migrationBuilder.DropTable(
                name: "EquiposParticipan");

            migrationBuilder.DropTable(
                name: "Gol");

            migrationBuilder.DropTable(
                name: "Hco_Integrante");

            migrationBuilder.DropTable(
                name: "LineaPedido");

            migrationBuilder.DropTable(
                name: "Noticia");

            migrationBuilder.DropTable(
                name: "Partido_Jugado");

            migrationBuilder.DropTable(
                name: "Producto");

            migrationBuilder.DropTable(
                name: "Tarjeta");

            migrationBuilder.DropTable(
                name: "Transpaso");

            migrationBuilder.DropTable(
                name: "Trata");

            migrationBuilder.DropTable(
                name: "UserProfile");

            migrationBuilder.DropTable(
                name: "zonaEstadio");

            migrationBuilder.DropTable(
                name: "Languages");

            migrationBuilder.DropTable(
                name: "pedidos");

            migrationBuilder.DropTable(
                name: "Partido");

            migrationBuilder.DropTable(
                name: "Jugador");

            migrationBuilder.DropTable(
                name: "Medico");

            migrationBuilder.DropTable(
                name: "Arbitro");

            migrationBuilder.DropTable(
                name: "Competicion");

            migrationBuilder.DropTable(
                name: "Integrante");

            migrationBuilder.DropTable(
                name: "Equipo");

            migrationBuilder.DropTable(
                name: "Estadio");

            migrationBuilder.DropTable(
                name: "GlobalMedia");
        }
    }
}
