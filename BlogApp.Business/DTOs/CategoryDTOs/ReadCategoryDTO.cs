using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.Business.DTOs.CategoryDTOs
{
    public record ReadCategoryDTO
    {
        public int Id { get; set; }
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
