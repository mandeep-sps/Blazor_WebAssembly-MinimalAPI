using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlazorApp.MinimalAPI.Migrations
{
    public partial class MIG2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ApplicationUser_Blazor",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ContactNo = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicationUser_Blazor", x => x.Id);
                });

            migrationBuilder.InsertData(
                table: "ApplicationUser_Blazor",
                columns: new[] { "Id", "ContactNo", "Email", "Name", "Password" },
                values: new object[] { 1, "9009123456", "admin@sp.com", "Admin SP", "admin@12345" });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ApplicationUser_Blazor");
        }
    }
}
