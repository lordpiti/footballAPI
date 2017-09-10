using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Football.DataAccess.Migrations
{
    public partial class addStadiumPicture : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PictureGlobalMediaId",
                table: "Estadio",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Estadio_PictureGlobalMediaId",
                table: "Estadio",
                column: "PictureGlobalMediaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Estadio_GlobalMedia_PictureGlobalMediaId",
                table: "Estadio",
                column: "PictureGlobalMediaId",
                principalTable: "GlobalMedia",
                principalColumn: "GlobalMediaId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Estadio_GlobalMedia_PictureGlobalMediaId",
                table: "Estadio");

            migrationBuilder.DropIndex(
                name: "IX_Estadio_PictureGlobalMediaId",
                table: "Estadio");

            migrationBuilder.DropColumn(
                name: "PictureGlobalMediaId",
                table: "Estadio");
        }
    }
}
