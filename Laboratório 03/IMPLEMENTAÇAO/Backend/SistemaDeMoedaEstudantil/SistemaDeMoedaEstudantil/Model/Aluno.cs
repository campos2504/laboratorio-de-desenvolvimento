namespace SistemaDeMoedaEstudantil.Model
{
    public class Aluno
    {
        public long Id { get; set; }
        public string Cpf { get; set; }
        public string Rg { get; set; }
        public string Nome { get; set; }
        public string Endereco { get; set; }
        public string Curso { get; set; }
        public long InstituicaoEnsinoId { get; set; }
        public virtual InstituicaoEnsino InstituicaoEnsino { get; set; }

    }
}
