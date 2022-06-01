using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SistemaDeMoedaEstudantil.Migrations
{
    public partial class CriacaoTabelaVantagemUser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "VantagemUser",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CodigoTroca = table.Column<Guid>(nullable: false),
                    VantagemId = table.Column<long>(nullable: false),
                    AlunoId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_VantagemUser", x => x.Id);
                    table.ForeignKey(
                        name: "FK_VantagemUser_User_AlunoId",
                        column: x => x.AlunoId,
                        principalTable: "User",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_VantagemUser_Vantagem_VantagemId",
                        column: x => x.VantagemId,
                        principalTable: "Vantagem",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateIndex(
                name: "IX_VantagemUser_AlunoId",
                table: "VantagemUser",
                column: "AlunoId");

            migrationBuilder.CreateIndex(
                name: "IX_VantagemUser_VantagemId",
                table: "VantagemUser",
                column: "VantagemId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "VantagemUser");
        }
    }
}
