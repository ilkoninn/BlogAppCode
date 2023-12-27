using BlogApp.Business.DTOs.TeacherDTOs;
using BlogApp.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Business.Services.Intefaces
{
    public interface ITeacherService
    {
        Task<ICollection<ReadTeacherDTO>> ReadAsync();
        Task<ReadTeacherDTO> ReadAsync(int Id);
        Task<Teacher> CreateAsync(CreateTeacherDTO entity, string env);
        Task<Teacher> UpdateAsync(UpdateTeacherDTO entity, string env);
        Task<Teacher> DeleteAsync(int Id);
    }
}
