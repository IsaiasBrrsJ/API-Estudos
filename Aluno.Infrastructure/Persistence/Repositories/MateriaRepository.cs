using Aluno.Core.Entities;
using Aluno.Core.Enums;
using Aluno.Core.Repositories;

namespace Aluno.Infrastructure.Persistence.Repositories
{
    public class MateriaRepository : IMateriaRepository
    {
        private readonly AlunoDbContext _DbContext;

        public MateriaRepository(AlunoDbContext dbContext)
        {
            _DbContext = dbContext;
        }

        public async Task<int> AddAsync(Materia materia)
        {
            throw new NotImplementedException();
        }

        public async Task DeleteAsync(Materia materia)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Materia>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<Materia> GetByCodigoAsync(string codigo)
        {
            throw new NotImplementedException();
        }

        public async Task<Materia> GetByIdasync(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Materia>> GetByStatusAsync(StatusMateria status)
        {
            throw new NotImplementedException();
        }

        public async Task UpdateAsync(Materia materia)
        {
            throw new NotImplementedException();
        }
    }
}
