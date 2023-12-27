using BlogApp.Business.Services.Implementations;
using BlogApp.Business.Services.Intefaces;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Business.Services
{
    public static class ServiceRegistration
    {
        public static void AddServices(this IServiceCollection services)
        {
            services.AddScoped<ICourseService, CourseService>();
            services.AddScoped<ICategoryService, CategoryService>();
            services.AddScoped<ITeacherService, TeacherService>();
            services.AddScoped<IStudentService, StudentService>();
        }
    }
}
