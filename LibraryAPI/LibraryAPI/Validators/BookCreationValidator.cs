using FluentValidation;
using LibraryAPI.DTO;

namespace LibraryAPI.Validators
{
    public class BookCreationValidator : AbstractValidator<BookCreationDTO>
    {
        public BookCreationValidator()
        {
            RuleFor(book => book.Name).NotEmpty().MaximumLength(250);
            RuleFor(book => book.AuthorId).GreaterThan(0);
        }
    }
}
