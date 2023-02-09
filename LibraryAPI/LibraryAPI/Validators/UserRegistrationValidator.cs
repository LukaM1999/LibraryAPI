using FluentValidation;
using LibraryAPI.DTO;

namespace LibraryAPI.Validators
{
    public class UserRegistrationValidator : AbstractValidator<UserRegistrationDTO>
    {
        public UserRegistrationValidator()
        {
            RuleFor(user => user.Email).EmailAddress()
                .WithMessage("Please provide a valid email address");
            RuleFor(user => user.Password).Matches("^(?=.*?[A-Z])(?=.*?[a-z])(?=.*?[0-9])(?=.*?[#?!@$%^&*-]).{8,}$")
                .WithMessage("The password must have at least 8 characters, one uppercase letter," +
                " one lowercase letter, one number, and one special character");
        }
    }
}
