using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlazorApp.MinimalAPI.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Employees_Blazor",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Designation = table.Column<int>(type: "int", nullable: false),
                    Department = table.Column<int>(type: "int", nullable: false),
                    EmployeeCode = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employees_Blazor", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "Employees_Blazor",
                columns: new[] { "Id", "Department", "Designation", "Email", "EmployeeCode", "Name" },
                values: new object[] { 1, 2, 6, "param@sp.com", "SP-1001", "Paramjeet Singh" });

            migrationBuilder.InsertData(
                table: "Employees_Blazor",
                columns: new[] { "Id", "Department", "Designation", "Email", "EmployeeCode", "Name" },
                values: new object[] { 2, 2, 5, "mandeep@sp.com", "SP-1002", "Mandeep Singh" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Employees_Blazor");
        }
    }
}
