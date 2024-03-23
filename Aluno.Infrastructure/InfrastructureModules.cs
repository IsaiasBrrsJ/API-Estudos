using Aluno.Core.Repositories;
using Aluno.Infrastructure.Persistence.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Aluno.Infrastructure
{
    public static class InfrastructureModules
    {

        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services
                .AddPesistence(configuration)
                .AddDependencyInjeciton();

            return services;
        }

        private static IServiceCollection AddPesistence(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("sqlServer");

            services
                .AddDbContext<AlunoDbContext>(options =>
                {
                    options.UseSqlServer(connectionString);
                });

            return services;
        }

        private static IServiceCollection AddDependencyInjeciton(this IServiceCollection services)
        {
            services
                .AddScoped<IAlunoRepository, AlunoRepository>();

            services
                .AddScoped<IMateriaRepository, MateriaRepository>();


            return services;
        }
    }
}
