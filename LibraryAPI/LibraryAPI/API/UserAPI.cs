using FluentValidation;
using LibraryAPI.DTO;
using LibraryAPI.Services;
using LibraryCL.Model;
using LibraryCL.Security;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using System.Net;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace LibraryAPI.API
{
    public static class UserAPI
    {
        public static void RegisterUserAPI(this WebApplication webApplication, ILogger logger)
        {
            webApplication.MapPost("/user/register", [AllowAnonymous] async (UserRegistrationDTO userRegistrationDto,
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

            webApplication.MapPut("/user/{userId}/upgradeToLibrarian", [Authorize(Policy = AuthorizationPolicies.Admin)] async (string userId, IUserService userService) =>
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

            webApplication.MapPut("/user/{userId}/downgradeToUser", [Authorize(Policy = AuthorizationPolicies.Admin)] async (string userId, IUserService userService) =>
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

            webApplication.MapPut("/user/basicInformation", [Authorize] async (UpdateUserBasicDTO userDto, IHttpContextAccessor httpContextAccessor, IUserService userService) =>
            {
                logger.LogInformation("Updating basic user information: {}", JsonSerializer.Serialize(userDto));

                var userId = httpContextAccessor.HttpContext?.User?.FindFirst("UserId")?.Value;
                if(userId == null)
                {
                    logger.LogWarning("Current user not found: {}", JsonSerializer.Serialize(userDto));
                    return Results.Conflict("Couldn't update basic user information");
                }

                User? user = await userService.GetUserById(userId);
                if(user == null)
                {
                    logger.LogWarning("User not found with id: {}", userId);
                    return Results.Conflict("Couldn't update basic user information");
                }

                try
                {
                    await userService.UpdateBasicInformation(user, userDto);
                } catch (Exception exception)
                {
                    logger.LogWarning("Couldn't update user with id: {} and information: {}. Message: {}", userId, JsonSerializer.Serialize(userDto), exception.Message);
                    return Results.Conflict("Couldn't update basic user information");
                }

                logger.LogInformation("User with id: {} successfully updated with information: {}", userId, JsonSerializer.Serialize(userDto));
                return Results.Ok();
            }).Produces(StatusCodes.Status204NoContent)
              .Produces(StatusCodes.Status409Conflict);

            webApplication.MapPost("/user/login", [AllowAnonymous] async (LoginDTO loginDTO, IUserService userService) =>
            {
                logger.LogInformation("Attempting to log in user with email {}", loginDTO.Email);

                LoginResponseDTO tokenDto;
                try
                {
                    tokenDto = await userService.Login(loginDTO);
                }
                catch (Exception exception)
                {
                    logger.LogWarning("Couldn't login user with email {}. Message: {}", loginDTO.Email, exception);
                    return Results.Conflict("Couldn't login user with provided login information");
                }

                return Results.Ok(tokenDto);
            }).Produces(StatusCodes.Status200OK)
              .Produces(StatusCodes.Status409Conflict);
        }
    }
}
