using Aluno.Core.Repositories;
using MediatR;

namespace Aluno.Application.Command.AtivarAlunoCommand
{
    internal class AtivarAlunoCommandHandler : IRequestHandler<AtivarAlunoCommand, Unit>
    {
        private readonly IAlunoRepository _AlunoRepository;

        public AtivarAlunoCommandHandler(IAlunoRepository alunoRepository)
        {
            _AlunoRepository = alunoRepository;
        }

        public async Task<Unit> Handle(AtivarAlunoCommand request, CancellationToken cancellationToken)
        {
            await _AlunoRepository.AtivarAlunoAsync(request.Id);

            return Unit.Value;
        }
    }
}
