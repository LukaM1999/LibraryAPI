using FluentValidation;
using LibraryAPI.DTO;

namespace LibraryAPI.Validators
{
    public class UserEmailValidator : AbstractValidator<UpdateUserEmailDTO>
    {
        public UserEmailValidator()
        {
            RuleFor(user => user.Email).EmailAddress()
                .WithMessage("Please provide a valid email address");
        }
    }
}
