using Microsoft.EntityFrameworkCore.Migrations;

namespace Api_NetCore.Migrations
{
    public partial class PopulateProducts : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("Insert into Products(Name, Description, Price, ImgUrl, Storage, Date, CategoryId)" + 
                                 "VALUES ('Coca-Cola Diet','Refrigerante de Cola 350 ml', 5.45,'cocacola.jpg',50,now(),1)");
            
            migrationBuilder.Sql("Insert into Products(Name, Description, Price, ImgUrl, Storage, Date, CategoryId)" + 
                                 "VALUES ('Lanche de Atum','Lanche de Atum com maionese', 8.50,'atum.jpg',10,now(),2)");
            
            migrationBuilder.Sql("Insert into Products(Name, Description, Price, ImgUrl, Storage, Date, CategoryId)" + 
                                 "VALUES ('Pudim 100 g','Pudim de leite condensado', 5.45,'pudim.jpg',20,now(),3)");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("Delete from Products");
        }
    }
}
