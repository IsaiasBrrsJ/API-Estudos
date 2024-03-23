using Aluno.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Aluno.Infrastructure.Persistence.Configurations
{
    public class MatriculaConfigurations : IEntityTypeConfiguration<Matricula>
    {
        public void Configure(EntityTypeBuilder<Matricula> builder)
        {

            builder
                .HasKey(x => new { x.Codigo, x.AlunoId, x.MateriaId});

            builder
                .HasOne(x => x.Aluno)
                .WithMany(x => x.AlunoMateria)
                .HasForeignKey(x => x.AlunoId);

            builder
                .HasOne( x=> x.Materia)
                .WithMany(x => x.AlunoMateria)
                .HasForeignKey( x=> x.MateriaId);


            builder
                 .ToTable("AlunoMateria");
        }
    }
}
