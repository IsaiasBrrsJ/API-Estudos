using Aluno.Application.ViewModel;
using MediatR;

namespace Aluno.Application.Queries.GetAlunoByIdQuery
{
    public class GetAlunoByIdQuery : IRequest<AlunoViewModel>
    {
        public int Id { get; set; }
    }
}
