using MediatR;

namespace Aluno.Application.Command.CreateUserCommand
{
    public class CreateAlunoCommand : IRequest<int>
    {
        public string Nome { get; set; } = default!;
        public string Email { get; set; } = default!;
    }
}
