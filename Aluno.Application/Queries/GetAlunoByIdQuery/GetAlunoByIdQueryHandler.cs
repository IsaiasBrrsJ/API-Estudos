using Aluno.Application.ViewModel;
using Aluno.Core.Repositories;
using MediatR;
using Microsoft.EntityFrameworkCore.ChangeTracking.Internal;

namespace Aluno.Application.Queries.GetAlunoByIdQuery
{
    public class GetAlunoByIdQueryHandler : IRequestHandler<GetAlunoByIdQuery, AlunoViewModel>
    {
        private readonly IAlunoRepository _AlunoRepository;
        public GetAlunoByIdQueryHandler(IAlunoRepository alunoRepository)
        {
            _AlunoRepository = alunoRepository;
        }

        public async Task<AlunoViewModel> Handle(GetAlunoByIdQuery request, CancellationToken cancellationToken)
        {
           var result =  await _AlunoRepository.GetByIdAsync(request.Id);

            if(result is null)
                return Enumerable.Empty<AlunoViewModel>() as AlunoViewModel;


            var alunoViewModel = new AlunoViewModel(result.Nome, result.Email, result.Status);
            
            return alunoViewModel;
        }
    }
}
