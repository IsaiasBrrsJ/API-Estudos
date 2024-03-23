using MediatR;

namespace Aluno.Application.Command.InativarAlunoCommand
{
    public class InativarAlunoCommand : IRequest<Unit>
    {
        public int Id { get; set; }
    }
}
