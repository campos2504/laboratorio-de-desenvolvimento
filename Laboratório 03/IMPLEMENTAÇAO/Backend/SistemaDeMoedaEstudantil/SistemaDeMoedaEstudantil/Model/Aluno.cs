using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaDeMoedaEstudantil.Model
{
    [Table("Aluno")]
    public class Aluno : User
    {
        public string Cpf { get; set; }
        public string Rg { get; set; }
        public string Nome { get; set; }
        public string Endereco { get; set; }
        public string Curso { get; set; }
        public long InstituicaoEnsinoId { get; set; }
        public InstituicaoEnsino InstituicaoEnsino { get; set; }
        public Conta Conta { get; set; }
        public long ContaId { get; set; }

    }
}
