using Microsoft.EntityFrameworkCore.Migrations;

namespace SistemaDeMoedaEstudantil.Migrations
{
    public partial class AdicaoContaID : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_User_Conta_ContaId",
                table: "User");

            migrationBuilder.DropForeignKey(
                name: "FK_User_Conta_Professor_ContaId",
                table: "User");

            migrationBuilder.AddForeignKey(
                name: "FK_User_Conta_ContaId",
                table: "User",
                column: "ContaId",
                principalTable: "Conta",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_User_Conta_Professor_ContaId",
                table: "User",
                column: "Professor_ContaId",
                principalTable: "Conta",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_User_Conta_ContaId",
                table: "User");

            migrationBuilder.DropForeignKey(
                name: "FK_User_Conta_Professor_ContaId",
                table: "User");

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
    }
}
