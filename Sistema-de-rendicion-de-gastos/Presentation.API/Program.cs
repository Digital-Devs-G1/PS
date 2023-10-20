using Application.Interfaces.IRepositories.ICommand;
using Application.Interfaces.IRepositories.IQuery;

using Application.DTO.Response.ReportNS;
using Application.Interfaces.IRepositories;
using Application.Interfaces.IServices;
using Application.Interfaces.IServices.IReportTraking;
using Application.Interfaces.IServices.IVariableFields;
using Application.UseCases;
using Application.UseCases.ReportTrackingService;
using Application.UseCases.VariableFieldsService;
using Application.Validations;
using Domain.Entities;
using FluentValidation;
using Infrastructure;
using Infrastructure.Persistence;
using Infrastructure.Repositories;
using Infrastructure.Repositories.Command;
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
            builder.Services.AddSingleton<IDepartamentTemplateQuery, DepartmentTemplateQuery>();
            builder.Services.AddSingleton<IFieldTemplateQuery, FieldTemplateQuery>();
            builder.Services.AddTransient(typeof(IGenericRepositoryCommand<>), typeof(GenericRepositoryCommand<>));
            builder.Services.AddTransient(typeof(IGenericRepositoryQuerys<>), typeof(GenericRepositoryQuerys<>));
            builder.Services.AddSingleton<IReportTrackingQuery, ReportTrackingQuery>();
            builder.Services.AddSingleton<IVariableFieldCommand, VariableFieldCommand>();
            builder.Services.AddTransient<IReportTrackingQuery, ReportTrackingQuery>();
            builder.Services.AddTransient<IDepartmentTemplateQuery, DepartmentTemplateQuery>();
            builder.Services.AddTransient<IFieldTemplateQuerys, FieldTemplateQuerys>();
            builder.Services.AddTransient<IFieldTemplateCommands, FieldTemplateCommands>();
            builder.Services.AddTransient<IVariableFieldQuery, VariableFieldQuery>();
            builder.Services.AddTransient<IReportQuery, ReportQuery>();
            //builder.Services.AddSingleton<IReportTrackingRepository, ReportTrackingRepository>();

            //services
            builder.Services.AddSingleton<IDepartmentTemplateServices, DepartmentTemplateServices>();
            builder.Services.AddSingleton<IFieldTemplateService, FieldTemplateService>();
            builder.Services.AddSingleton<IReportOperationService, ReportOperationService>();
            builder.Services.AddSingleton<IReportService, ReportService>();
            builder.Services.AddSingleton<IReportTrackingService, ReportTrackingService>();
            builder.Services.AddSingleton<IVariableFieldService, VariableFieldService>();
            builder.Services.AddTransient<IReportTrackingService, ReportTrackingService>();
            builder.Services.AddTransient<IReportService, ReportService>();
            builder.Services.AddTransient<IReportTrackingService, ReportTrackingService>();
            builder.Services.AddTransient<IReportOperationService, ReportOperationService>();
            builder.Services.AddTransient<IDepartmentTemplateServices, DepartmentTemplateServices>();
            builder.Services.AddTransient<IFieldTemplateServices, FieldTemplateServices>();
            builder.Services.AddTransient<IVariableFieldServices, VariableFieldServices>();

            //validators
            builder.Services.AddScoped<IValidator<VariableFieldResponse>, VariableFieldValidator>();

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