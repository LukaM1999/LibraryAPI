using FluentValidation;
using LibraryAPI.DTO;
using LibraryAPI.Exceptions;
using LibraryAPI.Services;
using Microsoft.AspNetCore.Authorization;
using System.Net;

namespace LibraryAPI.API
{
    public static class UserAPI
    {
        public static void RegisterUserAPI(this WebApplication webApplication, ILogger logger)
        {
            webApplication.MapPost("/user/register", async (UserRegistrationDTO userRegistrationDto,
                IValidator<UserRegistrationDTO> validator, IUserService userService) =>
            {
                logger.LogInformation("Validating user registration model with email {}", userRegistrationDto.Email);
                var validationResult = await validator.ValidateAsync(userRegistrationDto);
                if (!validationResult.IsValid)
                {
                    logger.LogWarning("Validation of the user registration request failed");
                    return Results.ValidationProblem(validationResult.ToDictionary(),
                    statusCode: (int)HttpStatusCode.BadRequest);
                }
                try
                {
                    logger.LogInformation("Registering user");
                    var result = await userService.RegisterUser(userRegistrationDto);
                    if (!result.Succeeded)
                    {
                        logger.LogWarning("User with email: {} couldn't be created", userRegistrationDto.Email);
                        return Results.BadRequest("User with provided email couldn't be created");
                    }
                }
                catch (Exception exception)
                {
                    logger.LogWarning("User with email {} already exists. Message: {}", userRegistrationDto.Email, exception);
                    return Results.Conflict("User with provided email already exists");
                }
                return Results.Ok();
            }).Produces(StatusCodes.Status200OK)
              .ProducesValidationProblem(StatusCodes.Status400BadRequest)
              .Produces(StatusCodes.Status409Conflict);

            webApplication.MapPut("/user/{userId}/upgradeToLibrarian", async (string userId, IUserService userService) =>
            {
                logger.LogInformation("Upgrading user role to Librarian with user id {}", userId);
                try
                {
                    await userService.UpgradeUserToLibrarian(userId);
                }
                catch (Exception exception)
                {
                    logger.LogWarning("Couldn't upgrade user with id {} to Librarian. Message: {}", userId, exception);
                    return Results.Conflict("Couldn't upgrade user with provided id to Librarian");
                }
                return Results.Ok();
            }).Produces(StatusCodes.Status200OK)
              .Produces(StatusCodes.Status409Conflict);

            webApplication.MapPut("/user/{userId}/downgradeToUser", async (string userId, IUserService userService) =>
            {
                logger.LogInformation("Downgrading Librarian to User with user id {}", userId);
                try
                {
                    await userService.DowngradeLibrarianToUser(userId);
                }
                catch (Exception exception)
                {
                    logger.LogWarning("Couldn't downgrade user with id {} to User role. Message: {}", userId, exception);
                    return Results.Conflict("Couldn't downgrade user with provided id to User role");
                }
                return Results.Ok();
            }).Produces(StatusCodes.Status200OK)
              .Produces(StatusCodes.Status409Conflict);
        }
    }
}
