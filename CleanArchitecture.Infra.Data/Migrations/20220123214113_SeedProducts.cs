using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CleanArchitecture.Infra.Data.Migrations
{
    public partial class SeedProducts : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Name", "Description", "Price", "Stock", "Image", "CategoryId" },
                values: new object[] { "Agenda escolar", "Ano 2022", 20.13, 10, null, 1 });

            migrationBuilder.InsertData(
                table: "Products",
                columns: new[] { "Name", "Description", "Price", "Stock", "Image", "CategoryId" },
                values: new object[] { "Estojo", "Grande", 40, 10, null, 1 });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Products",
                keyColumns: new[] { "Name", "Description", "Price", "Stock", "Image", "CategoryId" },
                keyValues: Array.Empty<object>(),
                schema: null);
        }
    }
}
