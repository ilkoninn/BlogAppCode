using AutoMapper.Configuration.Annotations;
using BlogApp.Core.Entities;
using FluentValidation;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace BlogApp.Business.DTOs.CategoryDTOs
{
    public record CreateCategoryDTO
    {
        public string? Name { get; set; }
        public IFormFile? File { get; set; }
    }
    public class CreateCategoryDTOValidation : AbstractValidator<CreateCategoryDTO>
    {
        public CreateCategoryDTOValidation()
        {
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
