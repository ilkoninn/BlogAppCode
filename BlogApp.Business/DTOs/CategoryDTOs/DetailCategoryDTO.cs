using BlogApp.Business.DTOs.CommonDTOs;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Business.DTOs.CategoryDTOs
{
    public record DetailCategoryDTO : BaseAuditableTableDTO
    {
        public string Name { get; set; }
        public int? ParentCategoryId { get; set; }
        public DetailCategoryDTO ParentCategory { get; set; }
        public ICollection<DetailCategoryDTO> ChildCategories { get; set; }
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
