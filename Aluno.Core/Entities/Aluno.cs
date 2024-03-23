using Aluno.Core.Enums;
using Aluno.Core.Exceptions;

namespace Aluno.Core.Entities
{
    public class Aluno : EntityBase
    {
        public Aluno(string nome,  string email)
        {
            Nome = nome;
            Email = email;
            Status = StatusAluno.Ativo;
            DataCriacao = DateTime.Now;
        }
        public string Nome { get; private set; } = default!;
        public string Email { get; private set; } = default!;
        public DateTime DataCriacao { get; private set; } = default!;
        public StatusAluno Status { get; private set; } = default!;
        public virtual ICollection<Matricula> AlunoMateria { get; private set; } = default!;

        public void Inativar()
        {
            if(Status is StatusAluno.Inativo)
               throw new AlunoExceptions("Aluno já consta como inativo");

            Status = StatusAluno.Inativo;
        }

        public void Ativar()
        {
            if (Status is StatusAluno.Ativo)
                throw new AlunoExceptions("Aluno já consta como Ativo");


            Status = StatusAluno.Ativo;
        }
    }
}
