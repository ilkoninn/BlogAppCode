using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace BlogApp.Business.DTOs.AccountDTOs
{
    public record RegisterDTO
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
    }
    public class RegisterDTOValidation : AbstractValidator<RegisterDTO>
    {
        public RegisterDTOValidation()
        {
            RuleFor(n => n.Name)
                .NotEmpty()
                .WithMessage("Name must be filled!")
                .MaximumLength(30)
                .WithMessage("Name's max length must be 30!")
                .MinimumLength(3)
                .WithMessage("Name's min lenght must be 3!");

            RuleFor(s => s.Surname) 
                .NotEmpty()
                .WithMessage("Surname must be filled!")
                .MaximumLength(30)
                .WithMessage("Surname's max length must be 30!")
                .MinimumLength(3)
                .WithMessage("Surname's min lenght must be 3!");

            RuleFor(u => u.UserName)
                .NotEmpty()
                .WithMessage("Username must be filled!")
                .MaximumLength(30)
                .WithMessage("Username's max length must be 30!")
                .MinimumLength(3)
                .WithMessage("Username's min lenght must be 3!");

            RuleFor(e => e.Email)
                .NotEmpty()
                .WithMessage("Email must be filled!")
                .Must(r =>
                {
                    Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
                    Match match = regex.Match(r);

                    return match.Success;
                })
                .WithMessage("Email does not match the given text format!");

            RuleFor(p => p.Password)
                .NotEmpty()
                .WithMessage("Password must be filled!")
                .Must(r =>
                {
                    Regex regex = new Regex(@"^(?=.*[A-Za-z])(?=.*\d)(?=.*[@$!%*#?&])[A-Za-z\d@$!%*#?&]{8,}$");
                    Match match = regex.Match(r);

                    return match.Success;
                })
                .WithMessage("Password does not match the given text format!");

            RuleFor(r => r)
                .Must(r => r.Password == r.ConfirmPassword)
                .WithMessage("Confirm password and password is not equal!");

        }
    }
}
