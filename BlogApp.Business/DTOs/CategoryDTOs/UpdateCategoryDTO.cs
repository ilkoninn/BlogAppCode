using FluentValidation;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace BlogApp.Business.DTOs.CategoryDTOs
{
    public record UpdateCategoryDTO
    {
        public int Id { get; set; }
        public string? Name { get; set; }
        public IFormFile? File { get; set; }
    }
    public class UpdateCategoryDTOValidation : AbstractValidator<UpdateCategoryDTO>
    {
        public UpdateCategoryDTOValidation()
        {
            RuleFor(c => c.Id)
                .NotEmpty()
                .WithMessage("It must be filled!");

            RuleFor(c => c.Name)
                .NotNull()
                .WithMessage("It must be filled!")
                .MaximumLength(50)
                .WithMessage("Its length must be lower than 50!");

            RuleFor(c => c.File)
                .Must(file => file != null && file.Length > 0)
                .WithMessage("The file must not be empty.");
        }
    }
}
