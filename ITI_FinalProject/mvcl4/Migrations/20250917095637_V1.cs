using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace mvcl4.Migrations
{
    /// <inheritdoc />
    public partial class V1 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Departments",
                columns: table => new
                {
                    DeptId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DeptName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Departments", x => x.DeptId);
                });

            migrationBuilder.CreateTable(
                name: "Students",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Age = table.Column<int>(type: "int", nullable: false),
                    Address = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DeptId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Students", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Students_Departments_DeptId",
                        column: x => x.DeptId,
                        principalTable: "Departments",
                        principalColumn: "DeptId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Departments",
                columns: new[] { "DeptId", "DeptName" },
                values: new object[,]
                {
                    { 1, "SWE" },
                    { 2, "CS" },
                    { 3, "IS" },
                    { 4, "IT" },
                    { 5, "AI" },
                    { 6, "BIO" }
                });

            migrationBuilder.InsertData(
                table: "Students",
                columns: new[] { "Id", "Address", "Age", "DeptId", "Email", "Name", "Password" },
                values: new object[,]
                {
                    { 1, "Menoufia", 25, 1, "ahmed.ali@example.com", "Ahmed Ali", "pass1234" },
                    { 2, "Giza", 30, 2, "mona.said@example.com", "Mona Said", "mona456" },
                    { 3, "Alexandria", 2, 3, "youssef.g@example.com", "Youssef Gamal", "you12345" },
                    { 4, "Mansoura", 22, 1, "sara.fathy@example.com", "Sara Fathy", "sara987" },
                    { 5, "Tanta", 35, 2, "khaled.n@example.com", "Khaled Nour", "khaledpw" },
                    { 6, "Zagazig", 27, 3, "nour.hassan@example.com", "Nour Hassan", "nourpass" },
                    { 7, "Ismailia", 29, 1, "omar.adel@example.com", "Omar Adel", "omar123" },
                    { 8, "Aswan", 32, 2, "laila.samir@example.com", "Laila Samir", "laila321" },
                    { 9, "Menoufia", 26, 3, "hassan.omar@example.com", "Hassan Omar", "hassanpw" },
                    { 10, "Luxor", 24, 4, "dina.nabil@example.com", "Dina Nabil", "dina444" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Students_DeptId",
                table: "Students",
                column: "DeptId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Students");

            migrationBuilder.DropTable(
                name: "Departments");
        }
    }
}
