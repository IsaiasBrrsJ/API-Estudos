using Aluno.Core.DTOs;
using Aluno.Core.Entities;
using Aluno.Core.Enums;

namespace Aluno.Core.Repositories
{
    public interface IAlunoRepository
    {
        Task<int> AddAsync(Entities.Aluno aluno);
        Task DeleteAsync(Entities.Aluno aluno);
        Task AtivarAlunoAsync(int id);  
        Task DesativarAlunoAsync(int id);  
        Task<GetAlunoDTO> GetByMatriculaAsync(string matricula);
        Task<GetAlunoDTO> GetByEmailAsync(string email);
        Task<GetAlunoDTO> GetByIdAsync(int id);
        Task<IEnumerable<GetAlunoDTO>> GetAllAsync(); 
        Task<IEnumerable<GetAlunoDTO>> GetByStatus(StatusAluno status);
    }
}
