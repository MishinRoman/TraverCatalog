using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace webapi.Migrations
{
    /// <inheritdoc />
    public partial class addTravelID : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Medias_Traverls_TravelId",
                table: "Medias");

            migrationBuilder.DropIndex(
                name: "IX_Medias_TravelId",
                table: "Medias");

            migrationBuilder.AddColumn<Guid>(
                name: "TravelModelId",
                table: "Medias",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Medias_TravelModelId",
                table: "Medias",
                column: "TravelModelId");

            migrationBuilder.AddForeignKey(
                name: "FK_Medias_Traverls_TravelModelId",
                table: "Medias",
                column: "TravelModelId",
                principalTable: "Traverls",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Medias_Traverls_TravelModelId",
                table: "Medias");

            migrationBuilder.DropIndex(
                name: "IX_Medias_TravelModelId",
                table: "Medias");

            migrationBuilder.DropColumn(
                name: "TravelModelId",
                table: "Medias");

            migrationBuilder.CreateIndex(
                name: "IX_Medias_TravelId",
                table: "Medias",
                column: "TravelId");

            migrationBuilder.AddForeignKey(
                name: "FK_Medias_Traverls_TravelId",
                table: "Medias",
                column: "TravelId",
                principalTable: "Traverls",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
