using BlogApp.Business.DTOs.StudentDTOs;
using BlogApp.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Business.Services.Intefaces
{
    public interface IStudentService
    {
        Task<ICollection<ReadStudentDTO>> ReadAsync(
        Expression<Func<Student, bool>>? expression = null,
        Expression<Func<Student, object>>? expressionOrder = null,
        bool isDescending = false,
        params string[] includes
        );
        Task<ReadStudentDTO> ReadAsync(int Id);
        Task<Student> CreateAsync(CreateStudentDTO entity, string env);
        Task<Student> UpdateAsync(UpdateStudentDTO entity, string env);
        Task<Student> DeleteAsync(int Id);

    }
}
