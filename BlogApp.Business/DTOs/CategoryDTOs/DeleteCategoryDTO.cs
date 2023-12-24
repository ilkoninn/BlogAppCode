using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Business.DTOs.CategoryDTOs
{
    public record DeleteCategoryDTO
    {
        public int Id { get; set; }
    }
    public class DeleteCategoryDTOValidation : AbstractValidator<DeleteCategoryDTO>
    {
        public DeleteCategoryDTOValidation()
        {
            RuleFor(c => c.Id)
                .NotEmpty()
                .WithMessage("It must be filled!");
        }
    }
}
