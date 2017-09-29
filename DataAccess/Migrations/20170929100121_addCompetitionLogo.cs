using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Football.DataAccess.Migrations
{
    public partial class addCompetitionLogo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "CompetitionLogoGlobalMediaId",
                table: "Competicion",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Competicion_CompetitionLogoGlobalMediaId",
                table: "Competicion",
                column: "CompetitionLogoGlobalMediaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Competicion_GlobalMedia_CompetitionLogoGlobalMediaId",
                table: "Competicion",
                column: "CompetitionLogoGlobalMediaId",
                principalTable: "GlobalMedia",
                principalColumn: "GlobalMediaId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Competicion_GlobalMedia_CompetitionLogoGlobalMediaId",
                table: "Competicion");

            migrationBuilder.DropIndex(
                name: "IX_Competicion_CompetitionLogoGlobalMediaId",
                table: "Competicion");

            migrationBuilder.DropColumn(
                name: "CompetitionLogoGlobalMediaId",
                table: "Competicion");
        }
    }
}
