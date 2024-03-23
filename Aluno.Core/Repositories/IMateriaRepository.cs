using Aluno.Core.Entities;
using Aluno.Core.Enums;

namespace Aluno.Core.Repositories
{
    public interface IMateriaRepository
    {
        Task<int> AddAsync(Materia materia);
        Task DeleteAsync(Materia materia);
        Task UpdateAsync(Materia materia);
        Task<Materia> GetByIdasync(int id);
        Task<Materia> GetByCodigoAsync(string codigo);
        Task<IEnumerable<Materia>> GetAllAsync();
        Task<IEnumerable<Materia>> GetByStatusAsync(StatusMateria status);


    }
}
