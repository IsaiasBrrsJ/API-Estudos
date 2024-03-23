using MediatR;

namespace Aluno.Application.Command.AtivarAlunoCommand
{
    public class AtivarAlunoCommand : IRequest<Unit>
    {
        public int Id { get; set; } 
    }
}
