using FluentValidation;
using LibraryAPI.DTO;
using LibraryAPI.Services;
using LibraryCL.Model;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System.Net;

namespace LibraryAPI.API
{
    public static class UserAPI
    {
        public static void RegisterUserAPI(this WebApplication webApplication, ILogger logger)
        {
            webApplication.MapPost("/register", async (UserRegistrationDTO userRegistrationDto,
                IValidator<UserRegistrationDTO> validator, IUserService userService) =>
            {
                logger.LogInformation("Validating user registration model with email {}", userRegistrationDto.Email);
                var validationResult = await validator.ValidateAsync(userRegistrationDto);
                if (!validationResult.IsValid)
                {
                    logger.LogError("Validation of the user registration request failed");
                    return Results.ValidationProblem(validationResult.ToDictionary(),
                    statusCode: (int)HttpStatusCode.BadRequest);
                }
                try
                {
                    logger.LogInformation("Registering user");
                    await userService.RegisterUser(userRegistrationDto);
                }
                catch (Exception exception)
                {
                    logger.LogError("User with email {} already exists", userRegistrationDto.Email);
                    return Results.Conflict("User with provided email already exists");
                }
                return Results.Ok();
            });
        }
    }
}
