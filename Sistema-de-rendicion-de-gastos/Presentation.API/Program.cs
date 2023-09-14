
using Application.DTO.Response;
using Application.Interfaces.IRepositories;
using Application.Interfaces.IServices;
using Application.UseCases;
using Infrastructure;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;

namespace Presentation.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.AddSingleton<DbContext, ReportsDbContext>();
            builder.Services.AddSingleton<IVariableFieldQuery, VariableFieldQuery>();
            builder.Services.AddSingleton<IVariableFieldService, VariableFieldService>();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            //app.Run();

            Run(app.Services);

        }

        public static void Run(IServiceProvider services)
        {
            while (true)
            {
                var service = services.GetService<IVariableFieldService>();
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("Ingrese el numero de template: ");
                int i = int.Parse(Console.ReadLine());
                IList<VariableFieldResponse> fields = service.GetTemplate(i);
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("\nRendicion de gatos:\n-------------------\n");
                Console.ForegroundColor = ConsoleColor.White;
                foreach (VariableFieldResponse field in fields)
                {
                    Console.Write(field.Label + ": ");
                    Console.ReadLine();
                }
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\nSu Reporte se ingreso con exito\n");
            }
        }
    }
}