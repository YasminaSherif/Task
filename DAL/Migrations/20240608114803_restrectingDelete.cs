using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace DAL.Migrations
{
    public partial class restrectingDelete : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ClientProducts_Clients_ClientId",
                table: "ClientProducts");

            migrationBuilder.DropForeignKey(
                name: "FK_ClientProducts_Products_ProductId",
                table: "ClientProducts");

            migrationBuilder.AddForeignKey(
                name: "FK_ClientProducts_Clients_ClientId",
                table: "ClientProducts",
                column: "ClientId",
                principalTable: "Clients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_ClientProducts_Products_ProductId",
                table: "ClientProducts",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ClientProducts_Clients_ClientId",
                table: "ClientProducts");

            migrationBuilder.DropForeignKey(
                name: "FK_ClientProducts_Products_ProductId",
                table: "ClientProducts");

            migrationBuilder.AddForeignKey(
                name: "FK_ClientProducts_Clients_ClientId",
                table: "ClientProducts",
                column: "ClientId",
                principalTable: "Clients",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_ClientProducts_Products_ProductId",
                table: "ClientProducts",
                column: "ProductId",
                principalTable: "Products",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
