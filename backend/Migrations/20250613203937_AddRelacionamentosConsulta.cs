using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace backend.Migrations
{
    /// <inheritdoc />
    public partial class AddRelacionamentosConsulta : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Consultas_Psicologos_PsicologoId",
                table: "Consultas");

            migrationBuilder.AlterColumn<int>(
                name: "PsicologoId",
                table: "Consultas",
                type: "int",
                nullable: false,
                defaultValue: 1,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LocalAtendimentoId",
                table: "Consultas",
                type: "int",
                nullable: false,
                defaultValue: 1);

            migrationBuilder.CreateIndex(
                name: "IX_Consultas_LocalAtendimentoId",
                table: "Consultas",
                column: "LocalAtendimentoId");

            migrationBuilder.AddForeignKey(
                name: "FK_Consultas_LocaisAtendimento_LocalAtendimentoId",
                table: "Consultas",
                column: "LocalAtendimentoId",
                principalTable: "LocaisAtendimento",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Consultas_Psicologos_PsicologoId",
                table: "Consultas",
                column: "PsicologoId",
                principalTable: "Psicologos",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Consultas_LocaisAtendimento_LocalAtendimentoId",
                table: "Consultas");

            migrationBuilder.DropForeignKey(
                name: "FK_Consultas_Psicologos_PsicologoId",
                table: "Consultas");

            migrationBuilder.DropIndex(
                name: "IX_Consultas_LocalAtendimentoId",
                table: "Consultas");

            migrationBuilder.DropColumn(
                name: "LocalAtendimentoId",
                table: "Consultas");

            migrationBuilder.AlterColumn<int>(
                name: "PsicologoId",
                table: "Consultas",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddForeignKey(
                name: "FK_Consultas_Psicologos_PsicologoId",
                table: "Consultas",
                column: "PsicologoId",
                principalTable: "Psicologos",
                principalColumn: "Id");
        }
    }
}
