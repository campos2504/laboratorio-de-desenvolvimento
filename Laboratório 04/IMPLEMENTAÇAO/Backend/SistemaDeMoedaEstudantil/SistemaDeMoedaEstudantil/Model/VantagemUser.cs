using System;

namespace SistemaDeMoedaEstudantil.Model
{
    public class VantagemUser
    {
        public VantagemUser()
        {
            CodigoTroca = Guid.NewGuid();
        }

        public Guid CodigoTroca { get; set; }
        public long Id { get; set; }
        public long VantagemId { get; set; }
        public virtual Vantagem Vantagem { get; set; }
        public long AlunoId { get; set; }
        public virtual Aluno Aluno { get; set; }

    }
}
