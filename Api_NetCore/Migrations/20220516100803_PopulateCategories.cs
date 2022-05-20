using Microsoft.EntityFrameworkCore.Migrations;

namespace Api_NetCore.Migrations
{
    public partial class PopulateCategories : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("Insert into Categories(Name, ImgUrl) VALUES ('Bebidas', 'bebidas.jpg')");
            migrationBuilder.Sql("Insert into Categories(Name, ImgUrl) VALUES ('Lanches', 'lanches.jpg')");
            migrationBuilder.Sql("Insert into Categories(Name, ImgUrl) VALUES ('Sobremesas', 'sobremesas.jpg')");

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("Delete from Categories");
        }
    }
}
