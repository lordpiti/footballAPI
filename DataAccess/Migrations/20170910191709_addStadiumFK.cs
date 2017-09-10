using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Football.DataAccess.Migrations
{
    public partial class addStadiumFK : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Equipo_Cod_Estadio",
                table: "Equipo",
                column: "Cod_Estadio");

            migrationBuilder.AddForeignKey(
                name: "FK_Equipo_Estadio_Cod_Estadio",
                table: "Equipo",
                column: "Cod_Estadio",
                principalTable: "Estadio",
                principalColumn: "Cod_Estadio",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Equipo_Estadio_Cod_Estadio",
                table: "Equipo");

            migrationBuilder.DropIndex(
                name: "IX_Equipo_Cod_Estadio",
                table: "Equipo");
        }
    }
}
