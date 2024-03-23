using Aluno.Application.Command.CreateUserCommand;
using Aluno.Application.Validations.CommandValidations;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.DependencyInjection;

namespace Aluno.Application
{
    public static class ApplicationModules
    {
        public static IServiceCollection AddApplicationModules(this IServiceCollection services)
        {
            services
                .AddMediatr()
                .AddValidation();

            return services;
        }

        private static IServiceCollection AddMediatr(this IServiceCollection services)
        {
            services
                .AddMediatR(mt => mt.RegisterServicesFromAssemblies(typeof(CreateAlunoCommand).Assembly));

            return services;
        }

        private static IServiceCollection AddValidation(this IServiceCollection service)
        {
            service
                .AddFluentValidationAutoValidation();

            service
                .AddValidatorsFromAssemblyContaining<CreateAlunoCommandValidation>();

            return service;
        }
    }
}
