using System.ComponentModel.DataAnnotations.Schema;

namespace SistemaDeMoedaEstudantil.Model
{
    [Table("User")]
    public class User
    {
        public long Id { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
        public UserType UserType { get; set; }

    }
}
