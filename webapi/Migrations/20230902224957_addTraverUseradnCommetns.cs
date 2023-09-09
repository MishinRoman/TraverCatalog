using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace webapi.Migrations
{
    /// <inheritdoc />
    public partial class addTraverUseradnCommetns : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Comment_Traverls_TraverlModelId",
                table: "Comment");

            migrationBuilder.DropForeignKey(
                name: "FK_Media_Traverls_TraverlModelId",
                table: "Media");

            migrationBuilder.DropForeignKey(
                name: "FK_User_Traverls_TraverlModelId",
                table: "User");

            migrationBuilder.DropPrimaryKey(
                name: "PK_User",
                table: "User");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Media",
                table: "Media");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Comment",
                table: "Comment");

            migrationBuilder.RenameTable(
                name: "User",
                newName: "Users");

            migrationBuilder.RenameTable(
                name: "Media",
                newName: "Medias");

            migrationBuilder.RenameTable(
                name: "Comment",
                newName: "Comments");

            migrationBuilder.RenameIndex(
                name: "IX_User_TraverlModelId",
                table: "Users",
                newName: "IX_Users_TraverlModelId");

            migrationBuilder.RenameIndex(
                name: "IX_Media_TraverlModelId",
                table: "Medias",
                newName: "IX_Medias_TraverlModelId");

            migrationBuilder.RenameIndex(
                name: "IX_Comment_TraverlModelId",
                table: "Comments",
                newName: "IX_Comments_TraverlModelId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Users",
                table: "Users",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Medias",
                table: "Medias",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Comments",
                table: "Comments",
                column: "Id");

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

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
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

            migrationBuilder.DropPrimaryKey(
                name: "PK_Users",
                table: "Users");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Medias",
                table: "Medias");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Comments",
                table: "Comments");

            migrationBuilder.RenameTable(
                name: "Users",
                newName: "User");

            migrationBuilder.RenameTable(
                name: "Medias",
                newName: "Media");

            migrationBuilder.RenameTable(
                name: "Comments",
                newName: "Comment");

            migrationBuilder.RenameIndex(
                name: "IX_Users_TraverlModelId",
                table: "User",
                newName: "IX_User_TraverlModelId");

            migrationBuilder.RenameIndex(
                name: "IX_Medias_TraverlModelId",
                table: "Media",
                newName: "IX_Media_TraverlModelId");

            migrationBuilder.RenameIndex(
                name: "IX_Comments_TraverlModelId",
                table: "Comment",
                newName: "IX_Comment_TraverlModelId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_User",
                table: "User",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Media",
                table: "Media",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Comment",
                table: "Comment",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Comment_Traverls_TraverlModelId",
                table: "Comment",
                column: "TraverlModelId",
                principalTable: "Traverls",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Media_Traverls_TraverlModelId",
                table: "Media",
                column: "TraverlModelId",
                principalTable: "Traverls",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_User_Traverls_TraverlModelId",
                table: "User",
                column: "TraverlModelId",
                principalTable: "Traverls",
                principalColumn: "Id");
        }
    }
}
