using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace PurchaseNexus.Server.Migrations
{
    public partial class RenamedTodoListTitleToName : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TodoItems_TodoLists_TodoListId",
                table: "TodoItems");

            migrationBuilder.RenameColumn(
                name: "Title",
                table: "TodoLists",
                newName: "Name");

            migrationBuilder.RenameColumn(
                name: "TodoListId",
                table: "TodoItems",
                newName: "ListId");

            migrationBuilder.RenameColumn(
                name: "Title",
                table: "TodoItems",
                newName: "Name");

            migrationBuilder.RenameIndex(
                name: "IX_TodoItems_TodoListId",
                table: "TodoItems",
                newName: "IX_TodoItems_ListId");

            migrationBuilder.AddForeignKey(
                name: "FK_TodoItems_TodoLists_ListId",
                table: "TodoItems",
                column: "ListId",
                principalTable: "TodoLists",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TodoItems_TodoLists_ListId",
                table: "TodoItems");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "TodoLists",
                newName: "Title");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "TodoItems",
                newName: "Title");

            migrationBuilder.RenameColumn(
                name: "ListId",
                table: "TodoItems",
                newName: "TodoListId");

            migrationBuilder.RenameIndex(
                name: "IX_TodoItems_ListId",
                table: "TodoItems",
                newName: "IX_TodoItems_TodoListId");

            migrationBuilder.AddForeignKey(
                name: "FK_TodoItems_TodoLists_TodoListId",
                table: "TodoItems",
                column: "TodoListId",
                principalTable: "TodoLists",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
