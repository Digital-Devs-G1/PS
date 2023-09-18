
using Application.Interfaces.IRepositories;
using Application.Interfaces.IServices;
using Application.UseCases;
using Domain.Entities;
using Infrastructure;
using Infrastructure.Persistence;
using Infrastructure.Repositories.Query;

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

            builder.Services.AddSingleton<ReportsDbContext>();

            //repositories
            builder.Services.AddTransient(typeof(IGenericRepositoryQuerys<>), typeof(GenericRepositoryQuerys<>));
            builder.Services.AddTransient(typeof(IGenericRepositoryCommand<>), typeof(GenericRepositoryCommand<>));
            builder.Services.AddSingleton<IVariableFieldQuery, VariableFieldQuery>();
            builder.Services.AddSingleton<IReportTrackingQuery, ReportTrackingQuery>();
            builder.Services.AddSingleton<IDepartamentTemplateQuery, DepartmentTemplateQuery>();
            //builder.Services.AddSingleton<IReportTrackingRepository, ReportTrackingRepository>();

            //services
            builder.Services.AddSingleton<IReportTrackingService, ReportTrackingService>();
            builder.Services.AddSingleton<IReportService, ReportService>();
            builder.Services.AddSingleton<IReportTrackingService, ReportTrackingService>();
            builder.Services.AddSingleton<IReportOperationService, ReportOperationService>();
            builder.Services.AddSingleton<IDepartmentTemplateServices, DepartmentTemplateServices>();

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

            app.Run();
        }
    }
}