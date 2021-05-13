using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace ToDoList.Infrastructure.Persistence.Migrations
{
    public partial class RenameColumns : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Created",
                table: "ToDoItemsList",
                newName: "CreatedDate");

            migrationBuilder.RenameColumn(
                name: "Date",
                table: "ToDoItem",
                newName: "CreatedDate");

            migrationBuilder.AddColumn<DateTime>(
                name: "LastModifiedDate",
                table: "ToDoItemsList",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "LastModifiedDate",
                table: "ToDoItem",
                type: "timestamp without time zone",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LastModifiedDate",
                table: "ToDoItemsList");

            migrationBuilder.DropColumn(
                name: "LastModifiedDate",
                table: "ToDoItem");

            migrationBuilder.RenameColumn(
                name: "CreatedDate",
                table: "ToDoItemsList",
                newName: "Created");

            migrationBuilder.RenameColumn(
                name: "CreatedDate",
                table: "ToDoItem",
                newName: "Date");
        }
    }
}
