using Microsoft.EntityFrameworkCore.Migrations;

namespace SistemaDeMoedaEstudantil.Migrations
{
    public partial class AdicaoConta : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<long>(
                name: "ContaId",
                table: "User",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "Professor_ContaId",
                table: "User",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_User_ContaId",
                table: "User",
                column: "ContaId");

            migrationBuilder.CreateIndex(
                name: "IX_User_Professor_ContaId",
                table: "User",
                column: "Professor_ContaId");

            migrationBuilder.AddForeignKey(
                name: "FK_User_Conta_ContaId",
                table: "User",
                column: "ContaId",
                principalTable: "Conta",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_User_Conta_Professor_ContaId",
                table: "User",
                column: "Professor_ContaId",
                principalTable: "Conta",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_User_Conta_ContaId",
                table: "User");

            migrationBuilder.DropForeignKey(
                name: "FK_User_Conta_Professor_ContaId",
                table: "User");

            migrationBuilder.DropIndex(
                name: "IX_User_ContaId",
                table: "User");

            migrationBuilder.DropIndex(
                name: "IX_User_Professor_ContaId",
                table: "User");

            migrationBuilder.DropColumn(
                name: "ContaId",
                table: "User");

            migrationBuilder.DropColumn(
                name: "Professor_ContaId",
                table: "User");
        }
    }
}
