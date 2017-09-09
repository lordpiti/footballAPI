using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Football.DataAccess.Migrations
{
    public partial class addedForeignKeyEquiposParticipan_Competicion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddForeignKey(
                name: "FK_EquiposParticipan_Competicion_Cod_Competicion",
                table: "EquiposParticipan",
                column: "Cod_Competicion",
                principalTable: "Competicion",
                principalColumn: "Cod_Competicion",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_EquiposParticipan_Competicion_Cod_Competicion",
                table: "EquiposParticipan");
        }
    }
}
