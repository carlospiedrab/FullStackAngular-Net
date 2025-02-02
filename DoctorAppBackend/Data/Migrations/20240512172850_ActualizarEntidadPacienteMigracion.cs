using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Data.Migrations
{
    /// <inheritdoc />
    public partial class ActualizarEntidadPacienteMigracion : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "ActualizadoPorId",
                table: "Pacientes",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "CreadoPorId",
                table: "Pacientes",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Pacientes_ActualizadoPorId",
                table: "Pacientes",
                column: "ActualizadoPorId");

            migrationBuilder.CreateIndex(
                name: "IX_Pacientes_CreadoPorId",
                table: "Pacientes",
                column: "CreadoPorId");

            migrationBuilder.AddForeignKey(
                name: "FK_Pacientes_AspNetUsers_ActualizadoPorId",
                table: "Pacientes",
                column: "ActualizadoPorId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Pacientes_AspNetUsers_CreadoPorId",
                table: "Pacientes",
                column: "CreadoPorId",
                principalTable: "AspNetUsers",
                principalColumn: "Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Pacientes_AspNetUsers_ActualizadoPorId",
                table: "Pacientes");

            migrationBuilder.DropForeignKey(
                name: "FK_Pacientes_AspNetUsers_CreadoPorId",
                table: "Pacientes");

            migrationBuilder.DropIndex(
                name: "IX_Pacientes_ActualizadoPorId",
                table: "Pacientes");

            migrationBuilder.DropIndex(
                name: "IX_Pacientes_CreadoPorId",
                table: "Pacientes");

            migrationBuilder.DropColumn(
                name: "ActualizadoPorId",
                table: "Pacientes");

            migrationBuilder.DropColumn(
                name: "CreadoPorId",
                table: "Pacientes");
        }
    }
}
