using Aluno.Core.Repositories;
using MediatR;

namespace Aluno.Application.Command.InativarAlunoCommand
{
    public class InativarAlunoCommandHandler : IRequestHandler<InativarAlunoCommand, Unit>
    {
        private readonly IAlunoRepository _AlunoRepostitory;
        public InativarAlunoCommandHandler(IAlunoRepository alunoRepostitory)
        {
            _AlunoRepostitory = alunoRepostitory;
        }
        public async Task<Unit> Handle(InativarAlunoCommand request, CancellationToken cancellationToken)
        {
            await _AlunoRepostitory.DesativarAlunoAsync(request.Id);

            return Unit.Value;
        }
    }

}