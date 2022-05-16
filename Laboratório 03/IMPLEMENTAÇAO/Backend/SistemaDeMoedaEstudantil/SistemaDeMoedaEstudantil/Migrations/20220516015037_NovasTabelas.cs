using Microsoft.EntityFrameworkCore.Migrations;

namespace SistemaDeMoedaEstudantil.Migrations
{
    public partial class NovasTabelas : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Aluno");

            migrationBuilder.DropPrimaryKey(
                name: "PK_EmpresaPerceira",
                table: "EmpresaPerceira");

            migrationBuilder.RenameTable(
                name: "EmpresaPerceira",
                newName: "User");

            migrationBuilder.AddColumn<string>(
                name: "Cpf",
                table: "User",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Curso",
                table: "User",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Endereco",
                table: "User",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "InstituicaoEnsinoId",
                table: "User",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Rg",
                table: "User",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EmpresaParceira_Nome",
                table: "User",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Professor_Cpf",
                table: "User",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Departamento",
                table: "User",
                nullable: true);

            migrationBuilder.AddColumn<long>(
                name: "Professor_InstituicaoEnsinoId",
                table: "User",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Professor_Nome",
                table: "User",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Discriminator",
                table: "User",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AddColumn<string>(
                name: "Email",
                table: "User",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Senha",
                table: "User",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_User",
                table: "User",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Conta",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Saldo = table.Column<double>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Conta", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Extrato",
                columns: table => new
                {
                    Id = table.Column<long>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Valor = table.Column<double>(nullable: false),
                    ContaId = table.Column<long>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Extrato", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Extrato_Conta_ContaId",
                        column: x => x.ContaId,
                        principalTable: "Conta",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_User_InstituicaoEnsinoId",
                table: "User",
                column: "InstituicaoEnsinoId");

            migrationBuilder.CreateIndex(
                name: "IX_User_Professor_InstituicaoEnsinoId",
                table: "User",
                column: "Professor_InstituicaoEnsinoId");

            migrationBuilder.CreateIndex(
                name: "IX_Extrato_ContaId",
                table: "Extrato",
                column: "ContaId");

            migrationBuilder.AddForeignKey(
                name: "FK_User_InstituicaoEnsino_InstituicaoEnsinoId",
                table: "User",
                column: "InstituicaoEnsinoId",
                principalTable: "InstituicaoEnsino",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_User_InstituicaoEnsino_Professor_InstituicaoEnsinoId",
                table: "User",
                column: "Professor_InstituicaoEnsinoId",
                principalTable: "InstituicaoEnsino",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_User_InstituicaoEnsino_InstituicaoEnsinoId",
                table: "User");

            migrationBuilder.DropForeignKey(
                name: "FK_User_InstituicaoEnsino_Professor_InstituicaoEnsinoId",
                table: "User");

            migrationBuilder.DropTable(
                name: "Extrato");

            migrationBuilder.DropTable(
                name: "Conta");

            migrationBuilder.DropPrimaryKey(
                name: "PK_User",
                table: "User");

            migrationBuilder.DropIndex(
                name: "IX_User_InstituicaoEnsinoId",
                table: "User");

            migrationBuilder.DropIndex(
                name: "IX_User_Professor_InstituicaoEnsinoId",
                table: "User");

            migrationBuilder.DropColumn(
                name: "Cpf",
                table: "User");

            migrationBuilder.DropColumn(
                name: "Curso",
                table: "User");

            migrationBuilder.DropColumn(
                name: "Endereco",
                table: "User");

            migrationBuilder.DropColumn(
                name: "InstituicaoEnsinoId",
                table: "User");

            migrationBuilder.DropColumn(
                name: "Rg",
                table: "User");

            migrationBuilder.DropColumn(
                name: "EmpresaParceira_Nome",
                table: "User");

            migrationBuilder.DropColumn(
                name: "Professor_Cpf",
                table: "User");

            migrationBuilder.DropColumn(
                name: "Departamento",
                table: "User");

            migrationBuilder.DropColumn(
                name: "Professor_InstituicaoEnsinoId",
                table: "User");

            migrationBuilder.DropColumn(
                name: "Professor_Nome",
                table: "User");

            migrationBuilder.DropColumn(
                name: "Discriminator",
                table: "User");

            migrationBuilder.DropColumn(
                name: "Email",
                table: "User");

            migrationBuilder.DropColumn(
                name: "Senha",
                table: "User");

            migrationBuilder.RenameTable(
                name: "User",
                newName: "EmpresaPerceira");

            migrationBuilder.AddPrimaryKey(
                name: "PK_EmpresaPerceira",
                table: "EmpresaPerceira",
                column: "Id");

            migrationBuilder.CreateTable(
                name: "Aluno",
                columns: table => new
                {
                    Id = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Cpf = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Curso = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Endereco = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    InstituicaoEnsinoId = table.Column<long>(type: "bigint", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Rg = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Aluno", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Aluno_InstituicaoEnsino_InstituicaoEnsinoId",
                        column: x => x.InstituicaoEnsinoId,
                        principalTable: "InstituicaoEnsino",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Aluno_InstituicaoEnsinoId",
                table: "Aluno",
                column: "InstituicaoEnsinoId");
        }
    }
}
