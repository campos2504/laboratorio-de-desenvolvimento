using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaDeMoedaEstudantil.Model
{
    [Table("Professor")]
    public class Professor : User
    {
        public string Cpf { get; set; }
        public string Nome { get; set; }
        public string Departamento { get; set; }
        public long InstituicaoEnsinoId { get; set; }
        public InstituicaoEnsino InstituicaoEnsino { get; set; }
        public Conta Conta  { get; set; }
        public long ContaId { get; set; }
    }
}
