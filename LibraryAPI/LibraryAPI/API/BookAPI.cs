namespace LibraryAPI.API
{
    using FluentValidation;
    using global::LibraryAPI.DTO;
    using global::LibraryAPI.Services;
    using LibraryCL.Model;
    using LibraryCL.Security;
    using Microsoft.AspNetCore.Authorization;
    using Swashbuckle.AspNetCore.Annotations;
    using System.Net;
    using System.Text.Json;

    namespace LibraryAPI.API
    {
        public static class BookAPI
        {
            public static void RegisterBookAPI(this WebApplication webApplication, ILogger logger)
            {
                webApplication.MapPost("/book",
                [SwaggerResponse(200, "Successfully created book")]
                [SwaggerResponse(400, "Invalid book information provided")]
                [SwaggerResponse(409, "Unable to create book")]
                [SwaggerOperation(
                        Summary = "Create new book | [Authorized: Admin or Librarian]",
                        Description = "Creates a new book, with optional author")]
                [Authorize(Policy = AuthorizationPolicies.AdminLibrarian)] async (BookCreationDTO bookDto,
                    IValidator<BookCreationDTO> validator, IBookService bookService) =>
                {
                    logger.LogInformation("Creating book: {book}", JsonSerializer.Serialize(bookDto));
                    var validationResult = await validator.ValidateAsync(bookDto);
                    if (!validationResult.IsValid)
                    {
                        logger.LogWarning("Validation of the book creation request failed");
                        return Results.ValidationProblem(validationResult.ToDictionary(),
                        statusCode: (int)HttpStatusCode.BadRequest);
                    }

                    BookDTO book;

                    try
                    {
                        book = await bookService.CreateBook(bookDto);
                    }
                    catch (Exception exception)
                    {
                        logger.LogWarning(exception, "Couldn't create book: {book}", bookDto);
                        return Results.Conflict("Couldn't create book");
                    }
                    return Results.Ok("Successfully created book");
                }).WithTags("Book")
                  .Produces(StatusCodes.Status200OK)
                  .ProducesValidationProblem(StatusCodes.Status400BadRequest)
                  .Produces(StatusCodes.Status409Conflict);

                webApplication.MapPut("/book/{id}",
                [SwaggerResponse(200, "Successfully updated book")]
                [SwaggerResponse(400, "Invalid book information provided")]
                [SwaggerResponse(404, "Book with provided id not found")]
                [SwaggerResponse(409, "Unable to update book")]
                [SwaggerOperation(
                        Summary = "Update specific book | [Authorized: Admin or Librarian]",
                        Description = "Updates specific book information, with the author of the book")]
                [Authorize(Policy = AuthorizationPolicies.AdminLibrarian)] async (int id, BookCreationDTO bookDto,
                    IValidator<BookCreationDTO> validator, IBookService bookService) =>
                {
                    logger.LogInformation("Updating book with id: {bookId}, with information: {book}", id, JsonSerializer.Serialize(bookDto));
                    var validationResult = await validator.ValidateAsync(bookDto);
                    if (!validationResult.IsValid)
                    {
                        logger.LogWarning("Validation of the book update request failed");
                        return Results.ValidationProblem(validationResult.ToDictionary(),
                        statusCode: (int)HttpStatusCode.BadRequest);
                    }

                    Book? book = await bookService.GetBookById(id);
                    if (book == null)
                    {
                        logger.LogWarning("Book not found with id: {bookId}", id);
                        return Results.NotFound("Book with provided id not found");
                    }

                    try
                    {
                        await bookService.UpdateBook(book, bookDto);
                    }
                    catch (Exception exception)
                    {
                        logger.LogWarning(exception, "Couldn't update book: {book}", bookDto);
                        return Results.Conflict("Couldn't update book");
                    }
                    return Results.Ok("Successfully updated book");
                }).WithTags("Book")
                  .Produces(StatusCodes.Status200OK)
                  .ProducesValidationProblem(StatusCodes.Status400BadRequest)
                  .Produces(StatusCodes.Status404NotFound)
                  .Produces(StatusCodes.Status409Conflict);

                webApplication.MapGet("/book/{id}",
                [SwaggerResponse(200, "Returns book with basic information about its author")]
                [SwaggerResponse(409, "Unable to retrieve book")]
                [SwaggerOperation(
                        Summary = "Get specific book | [Authorized]",
                        Description = "Gets specific book with information about their author")]
                [Authorize] async (int id, IBookService bookService) =>
                {
                    logger.LogInformation("Retrieving book with id: {bookId}", id);

                    BookDTO? book;

                    try
                    {
                        book = await bookService.GetBookWithAuthorById(id);
                    }
                    catch (Exception exception)
                    {
                        logger.LogWarning(exception, "Book with id: {bookId} couldn't be retrieved", id);
                        return Results.Conflict("Couldn't retrieve book");
                    }

                    return Results.Ok(book);
                }).WithTags("Book")
                  .Produces<BookDTO>(StatusCodes.Status200OK)
                  .Produces(StatusCodes.Status409Conflict);

                webApplication.MapDelete("/book/{id}",
                [SwaggerResponse(200, "Successfully deleted book")]
                [SwaggerResponse(404, "Book with provided id not found")]
                [SwaggerResponse(409, "Unable to delete book")]
                [SwaggerOperation(
                        Summary = "Delete book | [Authorized: Admin or Librarian]",
                        Description = "Deletes book and removes them from their author's books")]
                [Authorize(Policy = AuthorizationPolicies.AdminLibrarian)] async (int id, IBookService bookService) =>
                {
                    logger.LogInformation("Deleting book with id: {bookId}", id);

                    Book? book = await bookService.GetBookById(id);
                    if (book == null)
                    {
                        logger.LogWarning("Book not found with id: {bookId}", id);
                        return Results.NotFound("Book with provided id not found");
                    }

                    try
                    {
                        await bookService.DeleteBook(book);
                    }
                    catch (Exception exception)
                    {
                        logger.LogWarning(exception, "Book with id: {bookId} couldn't be deleted", id);
                        return Results.Conflict("Couldn't delete book");
                    }

                    return Results.Ok("Successfully deleted book");
                }).WithTags("Book")
                  .Produces(StatusCodes.Status200OK)
                  .Produces(StatusCodes.Status404NotFound)
                  .Produces(StatusCodes.Status409Conflict);

                webApplication.MapGet("/book",
                [SwaggerResponse(200, "Returns all books with basic information about their author")]
                [SwaggerResponse(409, "Unable to retrieve books")]
                [SwaggerOperation(
                    Summary = "Get all books | [Authorized]",
                    Description = "Gets all books with basic information about their author")]
                [Authorize] async (IBookService bookService) =>
                {
                    logger.LogInformation("Retrieving all books");

                    List<BookDTO> books = new();
                    try
                    {
                        books = bookService.GetAllBooks();
                    }
                    catch (Exception exception)
                    {
                        logger.LogWarning(exception, "Couldn't retrieve all books");
                        return Results.Conflict("Couldn't retrieve all books");
                    }

                    return Results.Ok(books);
                }).WithTags("Book")
                  .Produces<List<BookDTO>>(StatusCodes.Status200OK)
                  .Produces(StatusCodes.Status409Conflict);
            }
        }
    }

}
