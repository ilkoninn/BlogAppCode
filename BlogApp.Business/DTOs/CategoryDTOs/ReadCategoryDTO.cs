using BlogApp.Business.DTOs.CommonDTOs;
using BlogApp.Core.Entities;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Business.DTOs.CategoryDTOs
{
    public record ReadCategoryDTO : BaseAuditableTableDTO
    {
        public string Name { get; set; }
        public int? ParentCategoryId { get; set; }
        public Category ParentCategory { get; set; }
        public ICollection<Category> ChildCategories { get; set; }
    }
    public class ReadCategoryDTOValidation : AbstractValidator<ReadCategoryDTO>
    {
        public ReadCategoryDTOValidation()
        {
            RuleFor(c => c.Id)
                .NotEmpty()
                .WithMessage("It must be filled!");
        }
    }
}
