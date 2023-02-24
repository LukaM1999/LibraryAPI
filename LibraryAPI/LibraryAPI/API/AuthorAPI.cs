using FluentValidation;
using LibraryAPI.DTO;
using LibraryAPI.Services;
using LibraryCL.Model;
using LibraryCL.Security;
using Microsoft.AspNetCore.Authorization;
using Swashbuckle.AspNetCore.Annotations;
using System.Net;
using System.Text.Json;

namespace LibraryAPI.API
{
    public static class AuthorAPI
    {
        public static void RegisterAuthorAPI(this WebApplication webApplication, ILogger logger)
        {
            webApplication.MapPost("/author",
            [SwaggerResponse(200, "Successfully created author")]
            [SwaggerResponse(400, "Invalid author information provided")]
            [SwaggerResponse(409, "Unable to create author")]
            [SwaggerOperation(
                    Summary = "Create new author | [Authorized: Admin or Librarian]",
                    Description = "Creates a new author")]
            [Authorize(Policy = AuthorizationPolicies.AdminLibrarian)] async (AuthorCreationDTO authorDto,
                IValidator<AuthorCreationDTO> validator, IAuthorService authorService) =>
            {
                logger.LogInformation("Creating author: {author}", JsonSerializer.Serialize(authorDto));
                var validationResult = await validator.ValidateAsync(authorDto);
                if (!validationResult.IsValid)
                {
                    logger.LogWarning("Validation of the author creation request failed");
                    return Results.ValidationProblem(validationResult.ToDictionary(),
                    statusCode: (int)HttpStatusCode.BadRequest);
                }

                AuthorDTO author;

                try
                {
                    author = await authorService.CreateAuthor(authorDto);
                }
                catch (Exception exception)
                {
                    logger.LogWarning(exception, "Couldn't create author: {author}", authorDto);
                    return Results.Conflict("Couldn't create author");
                }
                return Results.Ok("Successfully created author");
            }).WithTags("Author")
              .Produces(StatusCodes.Status200OK)
              .ProducesValidationProblem(StatusCodes.Status400BadRequest)
              .Produces(StatusCodes.Status409Conflict);

            webApplication.MapPut("/author/{id}",
            [SwaggerResponse(200, "Successfully updated author")]
            [SwaggerResponse(400, "Invalid author information provided")]
            [SwaggerResponse(409, "Unable to update author information")]
            [SwaggerOperation(
                    Summary = "Update specific author | [Authorized: Admin or Librarian]",
                    Description = "Updates specific author information")]
            [Authorize(Policy = AuthorizationPolicies.AdminLibrarian)] async (int id, AuthorCreationDTO authorDto,
                IValidator<AuthorCreationDTO> validator, IAuthorService authorService) =>
            {
                logger.LogInformation("Updating author with id: {authorId}, with information: {author}", id, JsonSerializer.Serialize(authorDto));
                var validationResult = await validator.ValidateAsync(authorDto);
                if (!validationResult.IsValid)
                {
                    logger.LogWarning("Validation of the author update request failed");
                    return Results.ValidationProblem(validationResult.ToDictionary(),
                    statusCode: (int)HttpStatusCode.BadRequest);
                }

                Author? author = await authorService.GetAuthorById(id);
                if (author == null)
                {
                    logger.LogWarning("Author not found with id: {authorId}", id);
                    return Results.Conflict("Couldn't update author");
                }

                try
                {
                    await authorService.UpdateAuthor(author, authorDto);
                }
                catch (Exception exception)
                {
                    logger.LogWarning(exception, "Couldn't update author: {author}", authorDto);
                    return Results.Conflict("Couldn't update author");
                }
                return Results.Ok("Successfully updated author");
            }).WithTags("Author")
              .Produces(StatusCodes.Status200OK)
              .ProducesValidationProblem(StatusCodes.Status400BadRequest)
              .Produces(StatusCodes.Status409Conflict);

            webApplication.MapGet("/author/{id}",
            [SwaggerResponse(200, "Returns author with information about their books")]
            [SwaggerResponse(409, "Unable to retrieve author")]
            [SwaggerOperation(
                    Summary = "Get specific author | [Authorized]",
                    Description = "Gets specific author with information about their books")]
            [Authorize] async (int id, IAuthorService authorService) =>
            {
                logger.LogInformation("Retrieving author with id: {authorId}", id);

                AuthorDTO? author;

                try
                {
                    author = await authorService.GetAuthorWithBooksById(id);
                }
                catch (Exception exception)
                {
                    logger.LogWarning(exception, "Author with id: {authorId} couldn't be retrieved", id);
                    return Results.Conflict("Couldn't retrieve author");
                }

                return Results.Ok(author);
            }).WithTags("Author")
              .Produces<AuthorDTO>(StatusCodes.Status200OK)
              .Produces(StatusCodes.Status409Conflict);

            webApplication.MapDelete("/author/{id}",
            [SwaggerResponse(200, "Successfully deleted author")]
            [SwaggerResponse(409, "Unable to delete author")]
            [SwaggerOperation(
                    Summary = "Delete author | [Authorized: Admin or Librarian]",
                    Description = "Delete author and remove them from their books")]
            [Authorize(Policy = AuthorizationPolicies.AdminLibrarian)] async (int id, IAuthorService authorService) =>
            {
                logger.LogInformation("Deleting author with id: {authorId}", id);

                Author? author = await authorService.GetAuthorById(id);
                if (author == null)
                {
                    logger.LogWarning("Author not found with id: {authorId}", id);
                    return Results.Ok("Successfully deleted author");
                }

                try
                {
                    await authorService.DeleteAuthor(author);
                }
                catch (Exception exception)
                {
                    logger.LogWarning(exception, "Author with id: {authorId} couldn't be deleted", id);
                    return Results.Conflict("Couldn't delete author");
                }

                return Results.Ok("Successfully deleted author");
            }).WithTags("Author")
              .Produces(StatusCodes.Status200OK)
              .Produces(StatusCodes.Status409Conflict);

            webApplication.MapGet("/author",
            [SwaggerResponse(200, "Returns all authors with basic information about their books")]
            [SwaggerResponse(409, "Unable to retrieve authors")]
            [SwaggerOperation(
                    Summary = "Get all authors | [Authorized]",
                    Description = "Gets all authors with basic information about their books")]
            [Authorize] async (IAuthorService authorService) =>
            {
                logger.LogInformation("Retrieving all authors");

                List<AuthorDTO> authors = new();
                try
                {
                    authors = authorService.GetAllAuthors();
                }
                catch (Exception exception)
                {
                    logger.LogWarning(exception, "Couldn't retrieve all authors");
                    return Results.Conflict("Couldn't retrieve all authors");
                }

                return Results.Ok(authors);
            }).WithTags("Author")
             .Produces<List<AuthorDTO>>(StatusCodes.Status200OK)
             .Produces(StatusCodes.Status409Conflict);
        }
    }
}
