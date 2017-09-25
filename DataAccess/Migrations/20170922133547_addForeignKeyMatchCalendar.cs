using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Football.DataAccess.Migrations
{
    public partial class addForeignKeyMatchCalendar : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MatchCodPartido",
                table: "Calendario",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Calendario_MatchCodPartido",
                table: "Calendario",
                column: "MatchCodPartido");

            migrationBuilder.AddForeignKey(
                name: "FK_Calendario_Partido_MatchCodPartido",
                table: "Calendario",
                column: "MatchCodPartido",
                principalTable: "Partido",
                principalColumn: "Cod_Partido",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Calendario_Partido_MatchCodPartido",
                table: "Calendario");

            migrationBuilder.DropIndex(
                name: "IX_Calendario_MatchCodPartido",
                table: "Calendario");

            migrationBuilder.DropColumn(
                name: "MatchCodPartido",
                table: "Calendario");
        }
    }
}
