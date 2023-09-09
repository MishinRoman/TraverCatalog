using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace webapi.Migrations
{
    /// <inheritdoc />
    public partial class relation : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Traverls_TraverlModelId",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_Medias_Traverls_TraverlModelId",
                table: "Medias");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Traverls_TraverlModelId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Medias_TraverlModelId",
                table: "Medias");

            migrationBuilder.DropColumn(
                name: "TraverlId",
                table: "Medias");

            migrationBuilder.DropColumn(
                name: "TraverlModelId",
                table: "Medias");

            migrationBuilder.RenameColumn(
                name: "TraverlModelId",
                table: "Users",
                newName: "TravelModelId");

            migrationBuilder.RenameIndex(
                name: "IX_Users_TraverlModelId",
                table: "Users",
                newName: "IX_Users_TravelModelId");

            migrationBuilder.RenameColumn(
                name: "TraverlModelId",
                table: "Comments",
                newName: "TravelModelId");

            migrationBuilder.RenameIndex(
                name: "IX_Comments_TraverlModelId",
                table: "Comments",
                newName: "IX_Comments_TravelModelId");

            migrationBuilder.AddColumn<Guid>(
                name: "TravelId",
                table: "Medias",
                type: "uuid",
                nullable: false,
                defaultValue: new Guid("00000000-0000-0000-0000-000000000000"));

            migrationBuilder.CreateIndex(
                name: "IX_Medias_TravelId",
                table: "Medias",
                column: "TravelId");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Traverls_TravelModelId",
                table: "Comments",
                column: "TravelModelId",
                principalTable: "Traverls",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Medias_Traverls_TravelId",
                table: "Medias",
                column: "TravelId",
                principalTable: "Traverls",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Traverls_TravelModelId",
                table: "Users",
                column: "TravelModelId",
                principalTable: "Traverls",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comments_Traverls_TravelModelId",
                table: "Comments");

            migrationBuilder.DropForeignKey(
                name: "FK_Medias_Traverls_TravelId",
                table: "Medias");

            migrationBuilder.DropForeignKey(
                name: "FK_Users_Traverls_TravelModelId",
                table: "Users");

            migrationBuilder.DropIndex(
                name: "IX_Medias_TravelId",
                table: "Medias");

            migrationBuilder.DropColumn(
                name: "TravelId",
                table: "Medias");

            migrationBuilder.RenameColumn(
                name: "TravelModelId",
                table: "Users",
                newName: "TraverlModelId");

            migrationBuilder.RenameIndex(
                name: "IX_Users_TravelModelId",
                table: "Users",
                newName: "IX_Users_TraverlModelId");

            migrationBuilder.RenameColumn(
                name: "TravelModelId",
                table: "Comments",
                newName: "TraverlModelId");

            migrationBuilder.RenameIndex(
                name: "IX_Comments_TravelModelId",
                table: "Comments",
                newName: "IX_Comments_TraverlModelId");

            migrationBuilder.AddColumn<int>(
                name: "TraverlId",
                table: "Medias",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<Guid>(
                name: "TraverlModelId",
                table: "Medias",
                type: "uuid",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Medias_TraverlModelId",
                table: "Medias",
                column: "TraverlModelId");

            migrationBuilder.AddForeignKey(
                name: "FK_Comments_Traverls_TraverlModelId",
                table: "Comments",
                column: "TraverlModelId",
                principalTable: "Traverls",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Medias_Traverls_TraverlModelId",
                table: "Medias",
                column: "TraverlModelId",
                principalTable: "Traverls",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Users_Traverls_TraverlModelId",
                table: "Users",
                column: "TraverlModelId",
                principalTable: "Traverls",
                principalColumn: "Id");
        }
    }
}
