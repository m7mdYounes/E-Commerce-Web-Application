using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace E_Commerce.Migrations
{
    /// <inheritdoc />
    public partial class v1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Carts_Customers_customerID",
                table: "Carts");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_Customers_customerID",
                table: "Orders");

            migrationBuilder.DropTable(
                name: "Admins");

            migrationBuilder.DropTable(
                name: "Customers");

            migrationBuilder.DropIndex(
                name: "IX_Orders_customerID",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Carts_customerID",
                table: "Carts");

            migrationBuilder.DropColumn(
                name: "customerID",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "customerID",
                table: "Carts");

            migrationBuilder.AddColumn<string>(
                name: "userid",
                table: "Orders",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "userid",
                table: "Carts",
                type: "nvarchar(450)",
                nullable: false,
                defaultValue: "");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_userid",
                table: "Orders",
                column: "userid");

            migrationBuilder.CreateIndex(
                name: "IX_Carts_userid",
                table: "Carts",
                column: "userid");

            migrationBuilder.AddForeignKey(
                name: "FK_Carts_AspNetUsers_userid",
                table: "Carts",
                column: "userid",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_AspNetUsers_userid",
                table: "Orders",
                column: "userid",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Carts_AspNetUsers_userid",
                table: "Carts");

            migrationBuilder.DropForeignKey(
                name: "FK_Orders_AspNetUsers_userid",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Orders_userid",
                table: "Orders");

            migrationBuilder.DropIndex(
                name: "IX_Carts_userid",
                table: "Carts");

            migrationBuilder.DropColumn(
                name: "userid",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "userid",
                table: "Carts");

            migrationBuilder.AddColumn<int>(
                name: "customerID",
                table: "Orders",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "customerID",
                table: "Carts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "Admins",
                columns: table => new
                {
                    id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    password = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Admins", x => x.id);
                });

            migrationBuilder.CreateTable(
                name: "Customers",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    phone = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Customers", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Orders_customerID",
                table: "Orders",
                column: "customerID");

            migrationBuilder.CreateIndex(
                name: "IX_Carts_customerID",
                table: "Carts",
                column: "customerID");

            migrationBuilder.AddForeignKey(
                name: "FK_Carts_Customers_customerID",
                table: "Carts",
                column: "customerID",
                principalTable: "Customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Orders_Customers_customerID",
                table: "Orders",
                column: "customerID",
                principalTable: "Customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
