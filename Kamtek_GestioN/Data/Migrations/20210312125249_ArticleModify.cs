using Microsoft.EntityFrameworkCore.Migrations;

namespace Kamtek_GestioN.Data.Migrations
{
    public partial class ArticleModify : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "memo",
                table: "Articles",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "memo",
                table: "Articles");
        }
    }
}
