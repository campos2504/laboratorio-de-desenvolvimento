using Microsoft.EntityFrameworkCore.Migrations;

namespace SistemaDeMoedaEstudantil.Migrations
{
    public partial class AdicionarTrasacaoType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TransacaoType",
                table: "Extrato",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TransacaoType",
                table: "Extrato");
        }
    }
}
