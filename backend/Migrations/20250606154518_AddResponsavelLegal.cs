using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace backend.Migrations
{
    /// <inheritdoc />
    public partial class AddResponsavelLegal : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "CPF",
                table: "Pacientes",
                type: "longtext",
                nullable: false)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "ContatoEmergencia",
                table: "Pacientes",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "Diario",
                table: "Pacientes",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<string>(
                name: "Endereco",
                table: "Pacientes",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<bool>(
                name: "MoraSozinho",
                table: "Pacientes",
                type: "tinyint(1)",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<string>(
                name: "PlanoSaude",
                table: "Pacientes",
                type: "longtext",
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<int>(
                name: "ResponsavelLegalId",
                table: "Pacientes",
                type: "int",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "ResponsaveisLegais",
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
                    CPF = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4"),
                    Parentesco = table.Column<string>(type: "longtext", nullable: false)
                        .Annotation("MySql:CharSet", "utf8mb4")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ResponsaveisLegais", x => x.Id);
                })
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_Pacientes_ResponsavelLegalId",
                table: "Pacientes",
                column: "ResponsavelLegalId");

            migrationBuilder.AddForeignKey(
                name: "FK_Pacientes_ResponsaveisLegais_ResponsavelLegalId",
                table: "Pacientes",
                column: "ResponsavelLegalId",
                principalTable: "ResponsaveisLegais",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pacientes_ResponsaveisLegais_ResponsavelLegalId",
                table: "Pacientes");

            migrationBuilder.DropTable(
                name: "ResponsaveisLegais");

            migrationBuilder.DropIndex(
                name: "IX_Pacientes_ResponsavelLegalId",
                table: "Pacientes");

            migrationBuilder.DropColumn(
                name: "CPF",
                table: "Pacientes");

            migrationBuilder.DropColumn(
                name: "ContatoEmergencia",
                table: "Pacientes");

            migrationBuilder.DropColumn(
                name: "Diario",
                table: "Pacientes");

            migrationBuilder.DropColumn(
                name: "Endereco",
                table: "Pacientes");

            migrationBuilder.DropColumn(
                name: "MoraSozinho",
                table: "Pacientes");

            migrationBuilder.DropColumn(
                name: "PlanoSaude",
                table: "Pacientes");

            migrationBuilder.DropColumn(
                name: "ResponsavelLegalId",
                table: "Pacientes");
        }
    }
}
