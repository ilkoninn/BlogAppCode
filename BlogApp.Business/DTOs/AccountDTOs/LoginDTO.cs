using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BlogApp.Business.DTOs.AccountDTOs
{
    public record LoginDTO
    {
        public string UsernameOrEmail {  get; set; } 
        public string Password { get; set; }
    }
    public class LoginDTOValidation : AbstractValidator<LoginDTO>
    {
        public LoginDTOValidation() 
        {
            RuleFor(ue => ue.UsernameOrEmail)
                .NotEmpty()
                .WithMessage("It must be filled!");
            RuleFor(p => p.Password)
                .NotEmpty()
                .WithMessage("Password must be filled!");
        }
    }
}
