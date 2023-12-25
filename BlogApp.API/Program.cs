using BlogApp.Business.DTOs.CategoryDTOs;
using BlogApp.Business.Services.Implementations;
using BlogApp.Business.Services.Intefaces;
using BlogApp.DAL.Context;
using BlogApp.DAL.Repositories.Abstractions;
using BlogApp.DAL.Repositories.Interfaces;
using FluentValidation.AspNetCore;
using Microsoft.EntityFrameworkCore;

namespace BlogApp.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
            builder.Services.AddScoped<ICategoryService, CategoryService>();

            builder.Services.AddAutoMapper(typeof(MapperProfile).Assembly);

            builder.Services.AddControllers().AddFluentValidation(opt => 
            {
                opt.RegisterValidatorsFromAssembly(typeof(CreateCategoryDTOValidation).Assembly);
                opt.RegisterValidatorsFromAssembly(typeof(ReadCategoryDTOValidation).Assembly);
                opt.RegisterValidatorsFromAssembly(typeof(UpdateCategoryDTOValidation).Assembly);
            });

            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            // DB Connection
            builder.Services.AddDbContext<AppDbContext>(opt =>
            {
                opt.UseSqlServer(builder.Configuration.GetConnectionString("Default"));
            });

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
