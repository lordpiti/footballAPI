using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Football.DataAccess.Migrations
{
    public partial class addPlayerPicture : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PictureGlobalMediaId",
                table: "Integrante",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Integrante_PictureGlobalMediaId",
                table: "Integrante",
                column: "PictureGlobalMediaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Integrante_GlobalMedia_PictureGlobalMediaId",
                table: "Integrante",
                column: "PictureGlobalMediaId",
                principalTable: "GlobalMedia",
                principalColumn: "GlobalMediaId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Integrante_GlobalMedia_PictureGlobalMediaId",
                table: "Integrante");

            migrationBuilder.DropIndex(
                name: "IX_Integrante_PictureGlobalMediaId",
                table: "Integrante");

            migrationBuilder.DropColumn(
                name: "PictureGlobalMediaId",
                table: "Integrante");
        }
    }
}
