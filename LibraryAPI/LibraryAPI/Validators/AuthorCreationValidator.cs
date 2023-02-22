using FluentValidation;
using LibraryAPI.DTO;

namespace LibraryAPI.Validators
{
    public class AuthorCreationValidator : AbstractValidator<AuthorCreationDTO>
    {
        public AuthorCreationValidator()
        {
            RuleFor(author => author.FirstName).NotEmpty().MaximumLength(50);
            RuleFor(author => author.LastName).NotEmpty().MaximumLength(50);
        }
    }
}
