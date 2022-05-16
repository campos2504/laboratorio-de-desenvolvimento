using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaDeMoedaEstudantil.Model
{
    [Table("EmpresaPerceira")]
    public class EmpresaParceira : User
    {
        public string Nome { get; set; }
        public string Cnpj { get; set; }
    }
}
