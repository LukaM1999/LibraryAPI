using FluentValidation;
using LibraryAPI.DTO;
using LibraryAPI.Services;
using LibraryCL.Model;
using LibraryCL.Security;
using Microsoft.AspNetCore.Authorization;
using System.Net;
using System.Text.Json;

namespace LibraryAPI.API
{
    public static class AuthorAPI
    {
        public static void RegisterAuthorAPI(this WebApplication webApplication, ILogger logger)
        {
            webApplication.MapPost("/author", [Authorize(Policy = AuthorizationPolicies.AdminLibrarian)] async (AuthorCreationDTO authorDto,
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
                return Results.Ok($"/author/{author.Id}");
            }).Produces(StatusCodes.Status200OK)
              .ProducesValidationProblem(StatusCodes.Status400BadRequest)
              .Produces(StatusCodes.Status409Conflict);

            webApplication.MapPut("/author/{id}", [Authorize(Policy = AuthorizationPolicies.AdminLibrarian)] async (int id, AuthorCreationDTO authorDto,
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
                return Results.NoContent();
            }).Produces(StatusCodes.Status204NoContent)
              .ProducesValidationProblem(StatusCodes.Status400BadRequest)
              .Produces(StatusCodes.Status409Conflict);

            webApplication.MapGet("/author/{id}", [Authorize] async (int id, IAuthorService authorService) =>
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
            })
              .Produces<AuthorDTO>(StatusCodes.Status200OK)
              .Produces(StatusCodes.Status409Conflict);

            webApplication.MapDelete("/author/{id}", [Authorize(Policy = AuthorizationPolicies.AdminLibrarian)] async (int id, IAuthorService authorService) =>
            {
                logger.LogInformation("Deleting author with id: {authorId}", id);

                Author? author = await authorService.GetAuthorById(id);
                if (author == null)
                {
                    logger.LogWarning("Author not found with id: {authorId}", id);
                    return Results.NoContent();
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

                return Results.NoContent();
            })
              .Produces(StatusCodes.Status204NoContent)
              .Produces(StatusCodes.Status409Conflict);
        }
    }
}
