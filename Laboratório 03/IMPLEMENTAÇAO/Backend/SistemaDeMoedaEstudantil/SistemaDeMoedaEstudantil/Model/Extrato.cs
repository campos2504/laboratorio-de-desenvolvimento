namespace SistemaDeMoedaEstudantil.Model
{
    public class Extrato
    {
        public long Id { get; set; }
        public double Valor { get; set; }

        public long ContaId { get; set; }
        public virtual Conta Conta { get; set; }
    }
}
