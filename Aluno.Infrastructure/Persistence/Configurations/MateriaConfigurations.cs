using Aluno.Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Aluno.Infrastructure.Persistence.Configurations
{
    public class MateriaConfigurations : IEntityTypeConfiguration<Materia>
    {
        public void Configure(EntityTypeBuilder<Materia> builder)
        {
            builder
                 .HasKey(x => x.Id);

            builder.ToTable("Materias");
        }
    }
}
