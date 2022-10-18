using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ShopProject.Migrations
{
    public partial class aas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_OrderInfo_CustomerInfo_CustomerId",
                table: "OrderInfo");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderInfo_ItemInfo_ItemId",
                table: "OrderInfo");

            migrationBuilder.DropForeignKey(
                name: "FK_OrderInfo_UnitInfo_UnitId",
                table: "OrderInfo");

            migrationBuilder.DropPrimaryKey(
                name: "PK_UnitInfo",
                table: "UnitInfo");

            migrationBuilder.DropPrimaryKey(
                name: "PK_OrderInfo",
                table: "OrderInfo");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ItemInfo",
                table: "ItemInfo");

            migrationBuilder.DropPrimaryKey(
                name: "PK_CustomerInfo",
                table: "CustomerInfo");

            migrationBuilder.RenameTable(
                name: "UnitInfo",
                newName: "Units");

            migrationBuilder.RenameTable(
                name: "OrderInfo",
                newName: "orders");

            migrationBuilder.RenameTable(
                name: "ItemInfo",
                newName: "items");

            migrationBuilder.RenameTable(
                name: "CustomerInfo",
                newName: "customers");

            migrationBuilder.RenameIndex(
                name: "IX_OrderInfo_UnitId",
                table: "orders",
                newName: "IX_orders_UnitId");

            migrationBuilder.RenameIndex(
                name: "IX_OrderInfo_ItemId",
                table: "orders",
                newName: "IX_orders_ItemId");

            migrationBuilder.RenameIndex(
                name: "IX_OrderInfo_CustomerId",
                table: "orders",
                newName: "IX_orders_CustomerId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Units",
                table: "Units",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_orders",
                table: "orders",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_items",
                table: "items",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_customers",
                table: "customers",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_orders_customers_CustomerId",
                table: "orders",
                column: "CustomerId",
                principalTable: "customers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_orders_items_ItemId",
                table: "orders",
                column: "ItemId",
                principalTable: "items",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_orders_Units_UnitId",
                table: "orders",
                column: "UnitId",
                principalTable: "Units",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_orders_customers_CustomerId",
                table: "orders");

            migrationBuilder.DropForeignKey(
                name: "FK_orders_items_ItemId",
                table: "orders");

            migrationBuilder.DropForeignKey(
                name: "FK_orders_Units_UnitId",
                table: "orders");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Units",
                table: "Units");

            migrationBuilder.DropPrimaryKey(
                name: "PK_orders",
                table: "orders");

            migrationBuilder.DropPrimaryKey(
                name: "PK_items",
                table: "items");

            migrationBuilder.DropPrimaryKey(
                name: "PK_customers",
                table: "customers");

            migrationBuilder.RenameTable(
                name: "Units",
                newName: "UnitInfo");

            migrationBuilder.RenameTable(
                name: "orders",
                newName: "OrderInfo");

            migrationBuilder.RenameTable(
                name: "items",
                newName: "ItemInfo");

            migrationBuilder.RenameTable(
                name: "customers",
                newName: "CustomerInfo");

            migrationBuilder.RenameIndex(
                name: "IX_orders_UnitId",
                table: "OrderInfo",
                newName: "IX_OrderInfo_UnitId");

            migrationBuilder.RenameIndex(
                name: "IX_orders_ItemId",
                table: "OrderInfo",
                newName: "IX_OrderInfo_ItemId");

            migrationBuilder.RenameIndex(
                name: "IX_orders_CustomerId",
                table: "OrderInfo",
                newName: "IX_OrderInfo_CustomerId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_UnitInfo",
                table: "UnitInfo",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_OrderInfo",
                table: "OrderInfo",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ItemInfo",
                table: "ItemInfo",
                column: "Id");

            migrationBuilder.AddPrimaryKey(
                name: "PK_CustomerInfo",
                table: "CustomerInfo",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_OrderInfo_CustomerInfo_CustomerId",
                table: "OrderInfo",
                column: "CustomerId",
                principalTable: "CustomerInfo",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderInfo_ItemInfo_ItemId",
                table: "OrderInfo",
                column: "ItemId",
                principalTable: "ItemInfo",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_OrderInfo_UnitInfo_UnitId",
                table: "OrderInfo",
                column: "UnitId",
                principalTable: "UnitInfo",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
