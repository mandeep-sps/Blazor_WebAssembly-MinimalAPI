using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BlazorApp.Data.Migrations
{
    public partial class init : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Domain",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    About = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    ModifiedBy = table.Column<int>(type: "int", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Domain", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "TasksStatus",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    StatusName = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "datetime", nullable: false),
                    ModifiedBy = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_TasksStatus", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "ApplicationUser",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Hash = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Theme = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    ModifiedBy = table.Column<int>(type: "int", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "datetime", nullable: false),
                    DomainId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ApplicationUser", x => x.Id);
                    table.ForeignKey(
                        name: "FK__Applicati__Domai__440B1D61",
                        column: x => x.DomainId,
                        principalTable: "Domain",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Department",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    DomainId = table.Column<int>(type: "int", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    ModifiedBy = table.Column<int>(type: "int", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Department", x => x.Id);
                    table.ForeignKey(
                        name: "FK__Departmen__Domai__33D4B598",
                        column: x => x.DomainId,
                        principalTable: "Domain",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Role",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    DomainId = table.Column<int>(type: "int", nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    ModifiedBy = table.Column<int>(type: "int", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "datetime", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Role", x => x.Id);
                    table.ForeignKey(
                        name: "FK__Role__DomainId__38996AB5",
                        column: x => x.DomainId,
                        principalTable: "Domain",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Tasks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    StartDate = table.Column<DateTime>(type: "date", nullable: false),
                    EndDate = table.Column<DateTime>(type: "date", nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false),
                    Description = table.Column<string>(type: "varchar(1000)", unicode: false, maxLength: 1000, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    ModifiedBy = table.Column<int>(type: "int", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "datetime", nullable: false),
                    DomainId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tasks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Task_Domain",
                        column: x => x.DomainId,
                        principalTable: "Domain",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "Employee",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false),
                    DomainId = table.Column<int>(type: "int", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ContactNumber = table.Column<string>(type: "varchar(12)", unicode: false, maxLength: 12, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Username = table.Column<string>(type: "varchar(50)", unicode: false, maxLength: 50, nullable: false),
                    EmployeeCode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Location = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    DOJ = table.Column<DateTime>(type: "date", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "datetime", nullable: false),
                    ModifiedBy = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employee", x => x.Id);
                    table.ForeignKey(
                        name: "FK__Employee__Domain__4316F928",
                        column: x => x.DomainId,
                        principalTable: "Domain",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK__Employee__Id__4222D4EF",
                        column: x => x.Id,
                        principalTable: "ApplicationUser",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "DepartmentRole",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DepartmentId = table.Column<int>(type: "int", nullable: false),
                    RoleId = table.Column<int>(type: "int", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    ModifiedBy = table.Column<int>(type: "int", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "datetime", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_DepartmentRole", x => x.Id);
                    table.ForeignKey(
                        name: "FK__Departmen__Depar__3C69FB99",
                        column: x => x.DepartmentId,
                        principalTable: "Department",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK__Departmen__RoleI__3D5E1FD2",
                        column: x => x.RoleId,
                        principalTable: "Role",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "EmployeeTask",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EmployeeId = table.Column<int>(type: "int", nullable: false),
                    TaskId = table.Column<int>(type: "int", nullable: false),
                    CreatedBy = table.Column<int>(type: "int", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "datetime", nullable: false),
                    ModifiedBy = table.Column<int>(type: "int", nullable: false),
                    ModifiedOn = table.Column<DateTime>(type: "datetime", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeTask", x => x.Id);
                    table.ForeignKey(
                        name: "FK__EmployeeT__Emplo__52593CB8",
                        column: x => x.EmployeeId,
                        principalTable: "Employee",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK__EmployeeT__TaskI__534D60F1",
                        column: x => x.TaskId,
                        principalTable: "Tasks",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_ApplicationUser_DomainId",
                table: "ApplicationUser",
                column: "DomainId");

            migrationBuilder.CreateIndex(
                name: "IX_Department_DomainId",
                table: "Department",
                column: "DomainId");

            migrationBuilder.CreateIndex(
                name: "IX_DepartmentRole_DepartmentId",
                table: "DepartmentRole",
                column: "DepartmentId");

            migrationBuilder.CreateIndex(
                name: "IX_DepartmentRole_RoleId",
                table: "DepartmentRole",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_Employee_DomainId",
                table: "Employee",
                column: "DomainId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeTask_EmployeeId",
                table: "EmployeeTask",
                column: "EmployeeId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeTask_TaskId",
                table: "EmployeeTask",
                column: "TaskId");

            migrationBuilder.CreateIndex(
                name: "IX_Role_DomainId",
                table: "Role",
                column: "DomainId");

            migrationBuilder.CreateIndex(
                name: "IX_Tasks_DomainId",
                table: "Tasks",
                column: "DomainId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "DepartmentRole");

            migrationBuilder.DropTable(
                name: "EmployeeTask");

            migrationBuilder.DropTable(
                name: "TasksStatus");

            migrationBuilder.DropTable(
                name: "Department");

            migrationBuilder.DropTable(
                name: "Role");

            migrationBuilder.DropTable(
                name: "Employee");

            migrationBuilder.DropTable(
                name: "Tasks");

            migrationBuilder.DropTable(
                name: "ApplicationUser");

            migrationBuilder.DropTable(
                name: "Domain");
        }
    }
}
