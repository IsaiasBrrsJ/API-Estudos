using Aluno.Core.Enums;
using Aluno.Core.Exceptions;

namespace Aluno.Core.Entities
{
    public class Materia : EntityBase
    {
        public Materia(string nome, string codigo)
        {
            Nome = nome;
            Codigo = codigo;
            Status = StatusMateria.Ativa;
            DataCriacao = DateTime.Now;
        }

        public string Nome { get; private set; } = default!;
        public string Codigo { get; private set; } = default!;
        public StatusMateria Status { get; private set; } = default!;
        public DateTime DataCriacao { get; private set; } = default!;
        public virtual ICollection<Matricula> AlunoMateria { get; private set; } = default!;

        public void Inativar()
        {
            if (Status is StatusMateria.Ativa)
                Status = StatusMateria.Inativa;

            throw new MateriaExceptions("Matéria já consta como inativa");
        }

        public void Ativar()
        {
            if(Status is StatusMateria.Inativa)
                Status = StatusMateria.Ativa;

            throw new MateriaExceptions("Matéria já consta como ativa");
        }


    }
}
