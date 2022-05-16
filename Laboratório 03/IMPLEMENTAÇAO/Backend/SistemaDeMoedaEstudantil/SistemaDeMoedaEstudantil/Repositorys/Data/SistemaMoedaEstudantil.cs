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
        public DbSet<User> User { get; set; }
        public DbSet<Professor> Professor { get; set; }
        public DbSet<Conta> Conta { get; set; }
        public DbSet<Extrato> Extrato { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .Property(p => p.UserType)
                  .HasConversion(typeof(string));
        }
    }
}
