using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace backend.Migrations
{
    /// <inheritdoc />
    public partial class AddTabelaPsiquiatra : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PsiquiatraId",
                table: "Pacientes",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Psiquiatras",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Nome = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Telefone = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Email = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    CRM = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Especialidade = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Psiquiatras", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Pacientes_PsiquiatraId",
                table: "Pacientes",
                column: "PsiquiatraId");

            migrationBuilder.AddForeignKey(
                name: "FK_Pacientes_Psiquiatras_PsiquiatraId",
                table: "Pacientes",
                column: "PsiquiatraId",
                principalTable: "Psiquiatras",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pacientes_Psiquiatras_PsiquiatraId",
                table: "Pacientes");

            migrationBuilder.DropTable(
                name: "Psiquiatras");

            migrationBuilder.DropIndex(
                name: "IX_Pacientes_PsiquiatraId",
                table: "Pacientes");

            migrationBuilder.DropColumn(
                name: "PsiquiatraId",
                table: "Pacientes");
        }
    }
}
