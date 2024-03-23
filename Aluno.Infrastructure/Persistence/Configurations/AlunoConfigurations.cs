using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Aluno.Infrastructure.Persistence.Configurations
{
    public class AlunoConfigurations : IEntityTypeConfiguration<Core.Entities.Aluno>
    {
        public void Configure(EntityTypeBuilder<Core.Entities.Aluno> builder)
        {
            builder
                .HasKey(x => x.Id);

            builder.ToTable("Alunos");
        }
    }
}
