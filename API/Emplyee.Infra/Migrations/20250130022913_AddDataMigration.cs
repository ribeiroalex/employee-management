using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Emplyee.Infra.Migrations
{
    /// <inheritdoc />
    public partial class AddDataMigration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "People",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    DocumentNumber = table.Column<string>(type: "nvarchar(11)", maxLength: 11, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_People", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Role",
                columns: table => new
                {
                    RoleId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Role", x => x.RoleId);
                });

            migrationBuilder.CreateTable(
                name: "Addresses",
                columns: table => new
                {
                    PersonId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AddressLine = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    EmployeeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Addresses", x => new { x.PersonId, x.AddressLine });
                    table.ForeignKey(
                        name: "FK_Addresses_People_PersonId",
                        column: x => x.PersonId,
                        principalTable: "People",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Employee",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    ManagerId = table.Column<Guid>(type: "uniqueidentifier", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Employee", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Employee_Employee_ManagerId",
                        column: x => x.ManagerId,
                        principalTable: "Employee",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_Employee_People_Id",
                        column: x => x.Id,
                        principalTable: "People",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Phones",
                columns: table => new
                {
                    PersonId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(450)", nullable: false),
                    EmployeeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Phones", x => new { x.PersonId, x.PhoneNumber });
                    table.ForeignKey(
                        name: "FK_Phones_People_PersonId",
                        column: x => x.PersonId,
                        principalTable: "People",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RolePermissions",
                columns: table => new
                {
                    RoleId = table.Column<int>(type: "int", nullable: false),
                    CanCreateRoleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RolePermissions", x => new { x.RoleId, x.CanCreateRoleId });
                    table.ForeignKey(
                        name: "FK_RolePermissions_Role_CanCreateRoleId",
                        column: x => x.CanCreateRoleId,
                        principalTable: "Role",
                        principalColumn: "RoleId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_RolePermissions_Role_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Role",
                        principalColumn: "RoleId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "EmployeeRole",
                columns: table => new
                {
                    EmployeeId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RolesRoleId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EmployeeRole", x => new { x.EmployeeId, x.RolesRoleId });
                    table.ForeignKey(
                        name: "FK_EmployeeRole_Employee_EmployeeId",
                        column: x => x.EmployeeId,
                        principalTable: "Employee",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EmployeeRole_Role_RolesRoleId",
                        column: x => x.RolesRoleId,
                        principalTable: "Role",
                        principalColumn: "RoleId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Employee_ManagerId",
                table: "Employee",
                column: "ManagerId");

            migrationBuilder.CreateIndex(
                name: "IX_EmployeeRole_RolesRoleId",
                table: "EmployeeRole",
                column: "RolesRoleId");

            migrationBuilder.CreateIndex(
                name: "IX_People_DocumentNumber",
                table: "People",
                column: "DocumentNumber",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_RolePermissions_CanCreateRoleId",
                table: "RolePermissions",
                column: "CanCreateRoleId");

            migrationBuilder.Sql("INSERT INTO Role (RoleName) VALUES ('CEO')");
            migrationBuilder.Sql("INSERT INTO Role (RoleName) VALUES ('Admin')");
            migrationBuilder.Sql("INSERT INTO Role (RoleName) VALUES ('Manager')");
            migrationBuilder.Sql("INSERT INTO Role (RoleName) VALUES ('Employee')");
            

            migrationBuilder.Sql("INSERT INTO RolePermissions (RoleId, CanCreateRoleId) VALUES (1, 2)");
            migrationBuilder.Sql("INSERT INTO RolePermissions (RoleId, CanCreateRoleId) VALUES (1, 3)");
            migrationBuilder.Sql("INSERT INTO RolePermissions (RoleId, CanCreateRoleId) VALUES (1, 4)");
            migrationBuilder.Sql("INSERT INTO RolePermissions (RoleId, CanCreateRoleId) VALUES (2, 3)");
            migrationBuilder.Sql("INSERT INTO RolePermissions (RoleId, CanCreateRoleId) VALUES (2, 4)");
            migrationBuilder.Sql("INSERT INTO RolePermissions (RoleId, CanCreateRoleId) VALUES (3, 4)");
            

            var person1 = Guid.NewGuid();
            var person2 = Guid.NewGuid();
            var person3 = Guid.NewGuid();


            migrationBuilder.Sql($"INSERT INTO People (Id, FirstName, LastName, DocumentNumber, Password) VALUES ('{person1}', 'User-CEO', 'User', '12345678901', 'a@A123456user')");
            migrationBuilder.Sql($"INSERT INTO People (Id, FirstName, LastName, DocumentNumber, Password) VALUES ('{person2}', 'User-Admin', 'User', '12345678902', 'a@A123456user')");
            migrationBuilder.Sql($"INSERT INTO People (Id, FirstName, LastName, DocumentNumber, Password) VALUES ('{person3}', 'User-Manager', 'User', '12345678903', 'a@A123456user')");

            migrationBuilder.Sql($"INSERT INTO Employee (Id, ManagerId) VALUES ('{person1}', NULL)");
            migrationBuilder.Sql($"INSERT INTO Employee (Id, ManagerId) VALUES ('{person2}', NULL)");
            migrationBuilder.Sql($"INSERT INTO Employee (Id, ManagerId) VALUES ('{person3}', '{person2}')");

            migrationBuilder.Sql($"INSERT INTO EmployeeRole (EmployeeId, RolesRoleId) VALUES ('{person1}', 1)");
            migrationBuilder.Sql($"INSERT INTO EmployeeRole (EmployeeId, RolesRoleId) VALUES ('{person2}', 2)");
            migrationBuilder.Sql($"INSERT INTO EmployeeRole (EmployeeId, RolesRoleId) VALUES ('{person3}', 3)");

            migrationBuilder.Sql($"INSERT INTO Phones (PersonId, PhoneNumber, EmployeeId) VALUES ('{person1}', '12345678901', '{person1}')");
            migrationBuilder.Sql($"INSERT INTO Phones (PersonId, PhoneNumber, EmployeeId) VALUES ('{person2}', '12345678902', '{person2}')");
            migrationBuilder.Sql($"INSERT INTO Phones (PersonId, PhoneNumber, EmployeeId) VALUES ('{person3}', '12345678903', '{person3}')");
            migrationBuilder.Sql($"INSERT INTO Phones (PersonId, PhoneNumber, EmployeeId) VALUES ('{person3}', '12345678904', '{person3}')");

            migrationBuilder.Sql($"INSERT INTO Addresses (PersonId, AddressLine, EmployeeId) VALUES ('{person1}', 'Address 1', '{person1}')");
            migrationBuilder.Sql($"INSERT INTO Addresses (PersonId, AddressLine, EmployeeId) VALUES ('{person2}', 'Address 1', '{person2}')");


        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Addresses");

            migrationBuilder.DropTable(
                name: "EmployeeRole");

            migrationBuilder.DropTable(
                name: "Phones");

            migrationBuilder.DropTable(
                name: "RolePermissions");

            migrationBuilder.DropTable(
                name: "Employee");

            migrationBuilder.DropTable(
                name: "Role");

            migrationBuilder.DropTable(
                name: "People");
        }
    }
}
