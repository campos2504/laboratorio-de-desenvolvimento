using Microsoft.EntityFrameworkCore;
using SistemaDeMoedaEstudantil.Model;

namespace SistemaDeMoedaEstudantil.Repositorys
{
    public class SistemaMoedaEstudantilContext : DbContext
    {
        public SistemaMoedaEstudantilContext()
        {

        }

        public SistemaMoedaEstudantilContext(DbContextOptions<SistemaMoedaEstudantilContext> options) : base(options)
        {
            {

            }
        }

        public DbSet<Aluno> Aluno { get; set; }
        public DbSet<EmpresaParceira> EmpresaPerceira { get; set; }
        public DbSet<InstituicaoEnsino> InstituicaoEnsino { get; set; }
    }
}
