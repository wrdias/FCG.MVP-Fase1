using FCG.Mvp.API.DTOs;
using FluentValidation;
using System.Text.RegularExpressions;

namespace FCG.Mvp.API.Validators
{
    public class RegisterRequestValidator : AbstractValidator<RegisterRequest>
    {
        public RegisterRequestValidator()
        {
            RuleFor(x => x.Name).NotEmpty();
            RuleFor(x => x.Email).NotEmpty().EmailAddress();
            RuleFor(x => x.Password).NotEmpty().MinimumLength(8)
                .Must(HasNumber).WithMessage("Password must contain a number")
                .Must(HasLetter).WithMessage("Password must contain a letter")
                .Must(HasSpecial).WithMessage("Password must contain a special character");
        }

        private bool HasNumber(string pw) => Regex.IsMatch(pw, @"\d");
        private bool HasLetter(string pw) => Regex.IsMatch(pw, @"[A-Za-z]");
        private bool HasSpecial(string pw) => Regex.IsMatch(pw, @"[^a-zA-Z0-9]");
    }
}
