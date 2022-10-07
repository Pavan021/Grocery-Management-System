using Microsoft.EntityFrameworkCore.Migrations;

namespace GroceryStoreManagement.Migrations
{
    public partial class Initialmigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CartModel",
                columns: table => new
                {
                    GroceryId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GroceryName = table.Column<string>(maxLength: 30, nullable: true),
                    GroceryType = table.Column<string>(nullable: true),
                    GroceryPrice = table.Column<int>(nullable: false),
                    GroceryRating = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CartModel", x => x.GroceryId);
                });

            migrationBuilder.CreateTable(
                name: "GroceryModel",
                columns: table => new
                {
                    GroceryId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GroceryName = table.Column<string>(maxLength: 30, nullable: true),
                    GroceryType = table.Column<string>(nullable: true),
                    GroceryPrice = table.Column<int>(nullable: false),
                    GroceryRating = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_GroceryModel", x => x.GroceryId);
                });

            migrationBuilder.CreateTable(
                name: "OrderModel",
                columns: table => new
                {
                    GroceryId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    GroceryName = table.Column<string>(maxLength: 30, nullable: true),
                    GroceryType = table.Column<string>(nullable: true),
                    GroceryPrice = table.Column<int>(nullable: false),
                    GroceryRating = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_OrderModel", x => x.GroceryId);
                });

            migrationBuilder.CreateTable(
                name: "UserModel",
                columns: table => new
                {
                    UserId = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserName = table.Column<string>(nullable: false),
                    Email = table.Column<string>(nullable: true),
                    Password = table.Column<string>(nullable: true),
                    Role = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserModel", x => x.UserId);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CartModel");

            migrationBuilder.DropTable(
                name: "GroceryModel");

            migrationBuilder.DropTable(
                name: "OrderModel");

            migrationBuilder.DropTable(
                name: "UserModel");
        }
    }
}
