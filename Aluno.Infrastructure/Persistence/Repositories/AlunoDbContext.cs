using Aluno.Core.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Aluno.Infrastructure.Persistence.Repositories
{
    public class AlunoDbContext : DbContext
    {
        public AlunoDbContext(DbContextOptions<AlunoDbContext> options) : base(options)
        { }
        public DbSet<Core.Entities.Aluno> Alunos { get; set; }  
        public DbSet<Materia> Materias { get; set; }
        public DbSet<Matricula> AlunoMateria { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
           modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());
        }
    }
}
