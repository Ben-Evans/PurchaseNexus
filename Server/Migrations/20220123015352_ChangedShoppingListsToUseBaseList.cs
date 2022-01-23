using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PurchaseNexus.Server.Migrations
{
    public partial class ChangedShoppingListsToUseBaseList : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Products_GroceryDepartments_Food_GroceryDepartmentId",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_MeasurementTypes_Food_MeasurementTypeId",
                table: "Products");

            migrationBuilder.DropForeignKey(
                name: "FK_Products_ShoppingList_ShoppingListId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_Food_GroceryDepartmentId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_Food_MeasurementTypeId",
                table: "Products");

            migrationBuilder.DropIndex(
                name: "IX_Products_ShoppingListId",
                table: "Products");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ShoppingList",
                table: "ShoppingList");

            migrationBuilder.DropColumn(
                name: "AllowSubstitutions",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Food_ExpiryDate",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Food_GroceryDepartmentId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Food_IsRefrigerated",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Food_Measurement",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Food_MeasurementTypeId",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "IsPurchased",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "Notes",
                table: "Products");

            migrationBuilder.DropColumn(
                name: "ShoppingListId",
                table: "Products");

            migrationBuilder.RenameTable(
                name: "ShoppingList",
                newName: "ShoppingLists");

            migrationBuilder.AddPrimaryKey(
                name: "PK_ShoppingLists",
                table: "ShoppingLists",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "ShoppingItems",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Discriminator = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    ExpiryDate = table.Column<DateTime>(type: "datetime2(0)", precision: 0, nullable: true),
                    Measurement = table.Column<double>(type: "float", nullable: true),
                    MeasurementTypeId = table.Column<int>(type: "int", nullable: true),
                    GroceryDepartmentId = table.Column<int>(type: "int", nullable: true),
                    IsRefrigerated = table.Column<bool>(type: "bit", nullable: true),
                    ListId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Note = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Priority = table.Column<int>(type: "int", nullable: false),
                    State = table.Column<int>(type: "int", nullable: false),
                    Done = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShoppingItems", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ShoppingItems_GroceryDepartments_GroceryDepartmentId",
                        column: x => x.GroceryDepartmentId,
                        principalTable: "GroceryDepartments",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ShoppingItems_MeasurementTypes_MeasurementTypeId",
                        column: x => x.MeasurementTypeId,
                        principalTable: "MeasurementTypes",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_ShoppingItems_ShoppingLists_ListId",
                        column: x => x.ListId,
                        principalTable: "ShoppingLists",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingItems_GroceryDepartmentId",
                table: "ShoppingItems",
                column: "GroceryDepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingItems_ListId",
                table: "ShoppingItems",
                column: "ListId");

            migrationBuilder.CreateIndex(
                name: "IX_ShoppingItems_MeasurementTypeId",
                table: "ShoppingItems",
                column: "MeasurementTypeId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ShoppingItems");

            migrationBuilder.DropPrimaryKey(
                name: "PK_ShoppingLists",
                table: "ShoppingLists");

            migrationBuilder.RenameTable(
                name: "ShoppingLists",
                newName: "ShoppingList");

            migrationBuilder.AddColumn<bool>(
                name: "AllowSubstitutions",
                table: "Products",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Food_ExpiryDate",
                table: "Products",
                type: "datetime2(0)",
                precision: 0,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Food_GroceryDepartmentId",
                table: "Products",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "Food_IsRefrigerated",
                table: "Products",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<double>(
                name: "Food_Measurement",
                table: "Products",
                type: "float",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Food_MeasurementTypeId",
                table: "Products",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<bool>(
                name: "IsPurchased",
                table: "Products",
                type: "bit",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Notes",
                table: "Products",
                type: "nvarchar(50)",
                maxLength: 50,
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ShoppingListId",
                table: "Products",
                type: "int",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_ShoppingList",
                table: "ShoppingList",
                column: "Id");

            migrationBuilder.CreateIndex(
                name: "IX_Products_Food_GroceryDepartmentId",
                table: "Products",
                column: "Food_GroceryDepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_Food_MeasurementTypeId",
                table: "Products",
                column: "Food_MeasurementTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Products_ShoppingListId",
                table: "Products",
                column: "ShoppingListId");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_GroceryDepartments_Food_GroceryDepartmentId",
                table: "Products",
                column: "Food_GroceryDepartmentId",
                principalTable: "GroceryDepartments",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_MeasurementTypes_Food_MeasurementTypeId",
                table: "Products",
                column: "Food_MeasurementTypeId",
                principalTable: "MeasurementTypes",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Products_ShoppingList_ShoppingListId",
                table: "Products",
                column: "ShoppingListId",
                principalTable: "ShoppingList",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
