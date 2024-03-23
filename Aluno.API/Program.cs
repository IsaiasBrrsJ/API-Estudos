using Aluno.Infrastructure;
using Aluno.Application;
using Aluno.API.Middlewares;
using Aluno.API.Filters;

namespace Aluno.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);
            var configuration = builder.Configuration;

            builder
                .Services
                .AddInfrastructure(configuration);

            builder
                .Services
                .AddApplicationModules();



            // Add services to the container.

            builder.Services.AddControllers(filter =>
            {
                filter.Filters.Add(typeof(ResponseFilter));
            })
            .ConfigureApiBehaviorOptions(opt =>
            {
                opt.SuppressModelStateInvalidFilter = true;
            });


            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseMiddleware<ResponseGlobalExceptionHandler>();

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
