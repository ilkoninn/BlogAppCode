using BlogApp.Business.DTOs.CategoryDTOs;
using BlogApp.Core.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Business.Services.InternalServices.Intefaces
{
    public interface ICategoryService
    {
        Task<ICollection<ReadCategoryDTO>> ReadAsync();
        Task<DetailCategoryDTO> ReadIdAsync(int Id);
        Task<Category> CreateAsync(CreateCategoryDTO entity, string env);
        Task<Category> UpdateAsync(UpdateCategoryDTO entity, string env);
        Task<Category> DeleteAsync(int Id);
    }
}
