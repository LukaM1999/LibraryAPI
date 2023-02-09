using FluentValidation;
using LibraryAPI.DTO;
using LibraryAPI.Services;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace LibraryAPI.API
{
    public static class UserAPI
    {
        public static void InvokeUserAPI(this WebApplication webApplication) {
            webApplication.MapPost("/register", async (UserRegistrationDTO userRegistrationDto, 
                IValidator<UserRegistrationDTO> validator, IUserService userService) =>
            {
                var validationResult = await validator.ValidateAsync(userRegistrationDto);
                if (!validationResult.IsValid)
                {
                    return Results.ValidationProblem(validationResult.ToDictionary(),
                    statusCode: (int)HttpStatusCode.BadRequest);
                }
                try
                {
                    await userService.RegisterUser(userRegistrationDto);
                } catch (Exception ex)
                {
                    return Results.Conflict("User with provided email already exists");
                }
                return Results.Ok();
            });
        }
    }
}
