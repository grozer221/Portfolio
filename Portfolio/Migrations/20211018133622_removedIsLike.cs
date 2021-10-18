using Microsoft.EntityFrameworkCore.Migrations;

namespace Portfolio.Migrations
{
    public partial class removedIsLike : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsLike",
                table: "Likes");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsLike",
                table: "Likes",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
