using Microsoft.EntityFrameworkCore.Migrations;

namespace Portfolio.Migrations
{
    public partial class addedLikes1 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_LikeModel_Projects_ProjectId",
                table: "LikeModel");

            migrationBuilder.DropForeignKey(
                name: "FK_LikeModel_Users_UserId",
                table: "LikeModel");

            migrationBuilder.DropPrimaryKey(
                name: "PK_LikeModel",
                table: "LikeModel");

            migrationBuilder.RenameTable(
                name: "LikeModel",
                newName: "Likes");

            migrationBuilder.RenameIndex(
                name: "IX_LikeModel_UserId",
                table: "Likes",
                newName: "IX_Likes_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_LikeModel_ProjectId",
                table: "Likes",
                newName: "IX_Likes_ProjectId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Likes",
                table: "Likes",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Likes_Projects_ProjectId",
                table: "Likes",
                column: "ProjectId",
                principalTable: "Projects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Likes_Users_UserId",
                table: "Likes",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Likes_Projects_ProjectId",
                table: "Likes");

            migrationBuilder.DropForeignKey(
                name: "FK_Likes_Users_UserId",
                table: "Likes");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Likes",
                table: "Likes");

            migrationBuilder.RenameTable(
                name: "Likes",
                newName: "LikeModel");

            migrationBuilder.RenameIndex(
                name: "IX_Likes_UserId",
                table: "LikeModel",
                newName: "IX_LikeModel_UserId");

            migrationBuilder.RenameIndex(
                name: "IX_Likes_ProjectId",
                table: "LikeModel",
                newName: "IX_LikeModel_ProjectId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_LikeModel",
                table: "LikeModel",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_LikeModel_Projects_ProjectId",
                table: "LikeModel",
                column: "ProjectId",
                principalTable: "Projects",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_LikeModel_Users_UserId",
                table: "LikeModel",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
