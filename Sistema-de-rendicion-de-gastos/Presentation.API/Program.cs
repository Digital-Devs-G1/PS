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
using Application.Dto.Response.StatusResponseNS;
using Microsoft.OpenApi.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Application.Interfaces.IRepositories.Microservices;
using Infrastructure.Authentication;
using Infrastructure.MicroservicesClient.GenericClient;
using Application.Interfaces.IMicroservices.Generic;
using Application.Interfaces.IMicroservicesClient;
using Infrastructure.MicroservicesClient;

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
            builder.Services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo
                {
                    Version = "v1",
                    Title = "Microservice - Reports"
                });

                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
                {
                    Name = "Authorization",
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer",
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Description = "JWT Authorization header using the Bearer scheme. \r\n\r\n Enter 'Bearer' [space] and then your token in the text input below.\r\n\r\nExample: \"Bearer 12345abcdef\"",
                });

                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            }
                        },
                        new string[] {}

                    }
                });
            });

            builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateIssuerSigningKey = true,
                    ValidateLifetime = true,
                    ValidIssuer = builder.Configuration["JWT:Issuer"],
                    ValidAudience = builder.Configuration["JWT:Audience"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JWT:Key"]))
                };
            });

            builder.Services.AddCors(Options =>
            {
                Options.AddPolicy("CorsPolicy", policy =>
                {
                    policy.AllowAnyOrigin()
                          .AllowAnyHeader()
                          .AllowAnyMethod();

                });
            });

            builder.Services.AddSingleton<ReportsDbContext>();

            //repositories
            builder.Services.AddSingleton<IDepartmentTemplateQuery, DepartmentTemplateQuery>();
            builder.Services.AddSingleton<IFieldTemplateQuery, FieldTemplateQuery>();
            builder.Services.AddTransient(typeof(IGenericCommand<>), typeof(GenericCommand<>));
            builder.Services.AddTransient(typeof(IGenericRepositoryQuerys<>), typeof(GenericRepositoryQuerys<>));
            builder.Services.AddSingleton<IReportTrackingQuery, ReportTrackingQuery>();
            builder.Services.AddSingleton<IVariableFieldCommand, VariableFieldCommand>();
            builder.Services.AddTransient<IReportTrackingQuery, ReportTrackingQuery>();
            builder.Services.AddTransient<IDepartmentTemplateQuery, DepartmentTemplateQuery>();
            builder.Services.AddTransient<IFieldTemplateQuerys, FieldTemplateQuerys>();
            builder.Services.AddTransient<IFieldTemplateCommands, FieldTemplateCommands>();
            builder.Services.AddTransient<IVariableFieldQuery, VariableFieldQuery>();
            builder.Services.AddTransient<IReportQuery, ReportQuery>();
            builder.Services.AddTransient<IHttpContextAccessor, HttpContextAccessor>();
            builder.Services.AddTransient<IJwtHelper, JwtHelper>();
            builder.Services.AddTransient<IGetMicroserviceClient, GetMicroserviceClient>();
            builder.Services.AddTransient<IPostMicroserviceClient, PostMicroservicClient>();
            builder.Services.AddTransient<ICompanyClient, CompanyClient>();
            //builder.Services.AddSingleton<IReportTrackingRepository, ReportTrackingRepository>();

            //services
            builder.Services.AddSingleton<IDepartmentTemplateServices, DepartmentTemplateServices>();
            builder.Services.AddSingleton<IFieldTemplateServices, FieldTemplateService>();
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
            builder.Services.AddTransient<IReportTrackingQuery, ReportTrackingQuery>();
            builder.Services.AddTransient<IServiceResponseFactory, ServiceResponseFactory>();
            builder.Services.AddTransient<IAddReportTrackingService, AddReportTrackingService>();

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

            app.UseCors("CorsPolicy");
            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}