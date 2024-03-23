using Aluno.Core.DTOs;
using Aluno.Core.Enums;
using Aluno.Core.Repositories;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Aluno.Infrastructure.Persistence.Repositories
{
    public class AlunoRepository : IAlunoRepository
    {

        private readonly AlunoDbContext _DbContext;
        private readonly string connectionString;

        public AlunoRepository(AlunoDbContext dbContext, IConfiguration configuration)
        {
            _DbContext = dbContext;
            connectionString = configuration.GetConnectionString("sqlServer");
        }

        public async  Task<int> AddAsync(Core.Entities.Aluno aluno)
        {
            await _DbContext.Alunos.AddAsync(aluno);

            await _DbContext.SaveChangesAsync();    


            return aluno.Id;
        }

        public async Task AtivarAlunoAsync(int id)
        {
            var aluno = await _DbContext.Alunos.SingleOrDefaultAsync(x => x.Id == id);

            if (aluno is null)
                return;

            aluno.Ativar();

            _DbContext.Entry(aluno).State = EntityState.Modified;

            await _DbContext.SaveChangesAsync();
        }

        public async Task DeleteAsync(Core.Entities.Aluno aluno)
        {
            throw new NotImplementedException();
        }

        public async Task DesativarAlunoAsync(int id)
        {
            var aluno = await _DbContext.Alunos.SingleOrDefaultAsync(x => x.Id == id);

            if (aluno is null)
                return;

            aluno.Inativar();

            _DbContext.Entry(aluno).State = EntityState.Modified;

            await _DbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<GetAlunoDTO>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<GetAlunoDTO> GetByEmailAsync(string email)
        {
            throw new NotImplementedException();
        }

        public async  Task<GetAlunoDTO> GetByIdAsync(int id)
        {
           
            using(var sqlConnection = new SqlConnection(connectionString))
            {
                var query = @"
                SELECT 
                       [Nome]
                      ,[Email]
                      ,[DataCriacao]
                      ,[Status]
                  FROM [MeuTeste].[dbo].[Alunos]
                  WHERE [Id] = @Id;
                ";  
                var parameters = new DynamicParameters();
                parameters.Add("@Id", id);

                await sqlConnection.OpenAsync();

                var result = await  sqlConnection.QuerySingleOrDefaultAsync<GetAlunoDTO>(query, parameters);

                return result!;
            }
        }

        public async Task<GetAlunoDTO> GetByMatriculaAsync(string matricula)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<GetAlunoDTO>> GetByStatus(StatusAluno status)
        {
            throw new NotImplementedException();
        }

    
    }
}
