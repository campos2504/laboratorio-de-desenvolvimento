using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaDeMoedaEstudantil.Model
{
    public class Vantagem
    {
        public long Id { get; set; }
        public string Descricao { get; set; }
        public double Valor { get; set; }
        public string Imagem { get; set; }
        [NotMapped]
        public string ImagemSrc { get; set; }
        public long EmpresaParceiraId { get; set; }
        public virtual EmpresaParceira EmpresaParceira { get; set; }
    }
}
