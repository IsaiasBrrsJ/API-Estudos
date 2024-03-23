using Aluno.Core.Enums;

namespace Aluno.Core.DTOs
{
    public class GetAlunoDTO
    {
        public string Nome { get;  set; } = default!;
        public string Email { get;  set; } = default!;
        public DateTime DataCriacao { get;  set; } = default!;
        public StatusAluno Status { get;  set; } = default!;
    }
}
