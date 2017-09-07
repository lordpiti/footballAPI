using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace Football.DataAccess.Migrations
{
    public partial class addedGlobalMedia : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TeamPictureGlobalMediaId",
                table: "Equipo",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "GlobalMedia",
                columns: table => new
                {
                    GlobalMediaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:ValueGenerationStrategy", SqlServerValueGenerationStrategy.IdentityColumn),
                    BlobStorageContainer = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    BlobStorageReference = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FileName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GlobalMedia", x => x.GlobalMediaId);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Equipo_TeamPictureGlobalMediaId",
                table: "Equipo",
                column: "TeamPictureGlobalMediaId");

            migrationBuilder.AddForeignKey(
                name: "FK_Equipo_GlobalMedia_TeamPictureGlobalMediaId",
                table: "Equipo",
                column: "TeamPictureGlobalMediaId",
                principalTable: "GlobalMedia",
                principalColumn: "GlobalMediaId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Equipo_GlobalMedia_TeamPictureGlobalMediaId",
                table: "Equipo");

            migrationBuilder.DropTable(
                name: "GlobalMedia");

            migrationBuilder.DropIndex(
                name: "IX_Equipo_TeamPictureGlobalMediaId",
                table: "Equipo");

            migrationBuilder.DropColumn(
                name: "TeamPictureGlobalMediaId",
                table: "Equipo");
        }
    }
}
