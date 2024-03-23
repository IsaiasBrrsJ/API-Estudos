namespace Aluno.Core.Entities
{
    public class Matricula
    {
        public Matricula()
        {
            DataMatricula = DateTime.Now;
            Codigo = Guid.NewGuid();    
        }

        public Guid Codigo { get; private set; }
        public int AlunoId { get; private set; }
        public Aluno Aluno { get; private set; }
        public int MateriaId { get; private set; }
        public Materia Materia { get; private set; }
        public DateTime DataMatricula { get; private set; }

    }
}
