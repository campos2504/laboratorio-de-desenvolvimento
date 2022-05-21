using Microsoft.EntityFrameworkCore.Migrations;

namespace SistemaDeMoedaEstudantil.Migrations
{
    public partial class CriacaoTabelaVantagem : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Vantagem",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Descricao = table.Column<string>(nullable: true),
                    Valor = table.Column<double>(nullable: false),
                    Imagem = table.Column<string>(nullable: true),
                    EmpresaParceiraId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vantagem", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Vantagem_User_EmpresaParceiraId",
                        column: x => x.EmpresaParceiraId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Vantagem_EmpresaParceiraId",
                table: "Vantagem",
                column: "EmpresaParceiraId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Vantagem");
        }
    }
}
