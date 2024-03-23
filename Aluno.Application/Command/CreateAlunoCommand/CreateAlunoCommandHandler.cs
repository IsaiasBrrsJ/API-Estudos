using Aluno.Core.Repositories;
using MediatR;

namespace Aluno.Application.Command.CreateUserCommand
{
    public class CreateAlunoCommandHandler : IRequestHandler<CreateAlunoCommand, int>
    {
        private readonly IAlunoRepository _AlunoRepository;

        public CreateAlunoCommandHandler(IAlunoRepository alunoRepository)
        {
            _AlunoRepository = alunoRepository;
        }

        public async Task<int> Handle(CreateAlunoCommand request, CancellationToken cancellationToken)
        {
            var aluno = new Core.Entities.Aluno(request.Nome, request.Email);

            var result = await _AlunoRepository.AddAsync(aluno);

            return result;
        }
    }
}
