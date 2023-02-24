using FluentValidation;
using LibraryAPI.DTO;
using LibraryAPI.Services;
using LibraryCL.Model;
using LibraryCL.Security;
using LibraryCL.Utilities;
using Microsoft.AspNetCore.Authorization;
using Swashbuckle.AspNetCore.Annotations;
using System.Net;
using System.Text.Json;

namespace LibraryAPI.API
{
    public static class UserAPI
    {
        public static void RegisterUserAPI(this WebApplication webApplication, ILogger logger)
        {
            webApplication.MapPost("/user/register",
            [SwaggerResponse(200, "User registered successfully")]
            [SwaggerResponse(400, "Invalid registration information")]
            [SwaggerResponse(409, "User with provided email already exists")]
            [SwaggerOperation(
                    Summary = "Create new user | [Anonymous]",
                    Description = "Registers new user")]
            [AllowAnonymous] async (UserRegistrationDTO userRegistrationDto,
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
                        logger.LogWarning("User with email: {email} couldn't be created", userRegistrationDto.Email);
                        return Results.BadRequest("User with provided email couldn't be created");
                    }
                }
                catch (Exception exception)
                {
                    logger.LogWarning(exception, "User with email {email} already exists", userRegistrationDto.Email);
                    return Results.Conflict("User with provided email already exists");
                }
                return Results.Ok("Successfully registered user");
            }).WithTags("User")
              .Produces(StatusCodes.Status200OK)
              .ProducesValidationProblem(StatusCodes.Status400BadRequest)
              .Produces(StatusCodes.Status409Conflict);

            webApplication.MapPut("/user/{userId}/upgradeToLibrarian",
            [SwaggerResponse(200, "User registered successfully")]
            [SwaggerResponse(409, "Unable to upgrade user to librarian")]
            [SwaggerOperation(
                    Summary = "Upgrade user to librarian | [Authorized: Admin]",
                    Description = "Updates the role of user to Librarian")]
            [Authorize(Policy = AuthorizationPolicies.Admin)] async (string userId, IUserService userService) =>
            {
                logger.LogInformation("Upgrading user role to Librarian with user id {userId}", userId);
                try
                {
                    await userService.UpgradeUserToLibrarian(userId);
                }
                catch (Exception exception)
                {
                    logger.LogWarning(exception, "Couldn't upgrade user with id {userId} to Librarian", userId);
                    return Results.Conflict("Couldn't upgrade user with provided id to Librarian");
                }
                return Results.Ok("Successfully upgraded user to librarian");
            }).WithTags("User")
              .Produces(StatusCodes.Status200OK)
              .Produces(StatusCodes.Status409Conflict);

            webApplication.MapPut("/user/{userId}/downgradeToUser",
            [SwaggerResponse(200, "User registered successfully")]
            [SwaggerResponse(409, "Unable to downgrade librarian to user")]
            [SwaggerOperation(
                    Summary = "Downgrade librarian to user | [Authorized: Admin]",
                    Description = "Updates the role of librarian to User")]
            [Authorize(Policy = AuthorizationPolicies.Admin)] async (string userId, IUserService userService) =>
            {
                logger.LogInformation("Downgrading Librarian to User with user id {userId}", userId);
                try
                {
                    await userService.DowngradeLibrarianToUser(userId);
                }
                catch (Exception exception)
                {
                    logger.LogWarning(exception, "Couldn't downgrade user with id {userId} to User role", userId);
                    return Results.Conflict("Couldn't downgrade user with provided id to User role");
                }
                return Results.Ok("Successfully downgraded librarian to user");
            }).WithTags("User")
              .Produces(StatusCodes.Status200OK)
              .Produces(StatusCodes.Status409Conflict);

            webApplication.MapPut("/user/basicInformation",
            [SwaggerResponse(200, "Basic user information updated successfully")]
            [SwaggerResponse(409, "Unable to update basic user information")]
            [SwaggerOperation(
                    Summary = "Update basic user information | [Authorized]",
                    Description = "Updates basic signed in user information like first and last name")]
            [Authorize] async (UpdateUserBasicDTO userDto, IHttpContextAccessor httpContextAccessor, IUserService userService) =>
            {
                logger.LogInformation("Updating basic user information: {userInfo}", JsonSerializer.Serialize(userDto));

                var userId = httpContextAccessor.HttpContext?.User?.FindFirst("UserId")?.Value;
                if (userId == null)
                {
                    logger.LogWarning("Current user not found: {userInfo}", JsonSerializer.Serialize(userDto));
                    return Results.Conflict("Couldn't update basic user information");
                }

                User? user = await userService.GetUserById(userId);
                if (user == null)
                {
                    logger.LogWarning("User not found with id: {userId}", userId);
                    return Results.Conflict("Couldn't update basic user information");
                }

                try
                {
                    await userService.UpdateBasicInformation(user, userDto);
                }
                catch (Exception exception)
                {
                    logger.LogWarning(exception, "Couldn't update user with id: {userId} and information: {userInfo}", userId, JsonSerializer.Serialize(userDto));
                    return Results.Conflict("Couldn't update basic user information");
                }

                logger.LogInformation("User with id: {userId} successfully updated with information: {userInfo}", userId, JsonSerializer.Serialize(userDto));
                return Results.Ok("Successfully updated basic user information");
            }).WithTags("User")
              .Produces(StatusCodes.Status200OK)
              .Produces(StatusCodes.Status409Conflict);

            webApplication.MapPut("/user/email",
            [SwaggerResponse(200, "User email successfully updated")]
            [SwaggerResponse(400, "Invalid user email provided")]
            [SwaggerResponse(409, "User with provided email already exists")]
            [SwaggerOperation(
                    Summary = "Update user email | [Authorized]",
                    Description = "Updates signed in user's email")]
            [Authorize] async (UpdateUserEmailDTO emailDto, IValidator<UpdateUserEmailDTO> validator, IHttpContextAccessor httpContextAccessor, IUserService userService) =>
            {
                logger.LogInformation("Updating user email: {email}", emailDto.Email);

                var validationResult = await validator.ValidateAsync(emailDto);
                if (!validationResult.IsValid)
                {
                    logger.LogWarning("Validation of provided user email failed");
                    return Results.ValidationProblem(validationResult.ToDictionary(),
                    statusCode: (int)HttpStatusCode.BadRequest);
                }

                var userId = httpContextAccessor.HttpContext?.User?.FindFirst("UserId")?.Value;
                if (userId == null)
                {
                    logger.LogWarning("Current user not found: {email}", emailDto.Email);
                    return Results.Conflict("Couldn't update user email");
                }

                User? userWithEmail = await userService.GetUserByEmail(emailDto.Email);
                if (userWithEmail != null && userWithEmail.Id != userId)
                {
                    logger.LogWarning("User with provided email: {email} already exists", emailDto.Email);
                    return Results.Conflict("User with provided email already exists");
                }

                User? user = await userService.GetUserById(userId);
                if (user == null)
                {
                    logger.LogWarning("User not found with id: {userId}", userId);
                    return Results.Conflict("Couldn't update user email");
                }

                try
                {
                    await userService.UpdateEmail(user, emailDto.Email);
                }
                catch (Exception exception)
                {
                    logger.LogWarning(exception, "Couldn't update user with id: {userId} and email: {email} with new email: {newEmail}", userId, user.Email, emailDto.Email);
                    return Results.Conflict("Couldn't update basic user information");
                }

                logger.LogInformation("User with id: {userId} and email: {email} successfully updated with new email: {newEmail}", userId, user.Email, emailDto.Email);
                return Results.Ok("Successfully updated user email");
            }).WithTags("User")
              .Produces(StatusCodes.Status200OK)
              .ProducesValidationProblem(StatusCodes.Status400BadRequest)
              .Produces(StatusCodes.Status409Conflict);

            webApplication.MapPut("/user/avatar",
            [SwaggerResponse(200, "User avatar updated successfully")]
            [SwaggerResponse(409, "Unable to update user avatar")]
            [SwaggerOperation(
                    Summary = "Updates user avatar | [Authorized]",
                    Description = "Updates signed in user's avatar")]
            [Authorize] async (IHttpContextAccessor httpContextAccessor, IUserService userService) =>
            {
                logger.LogInformation("Updating user avatar");

                var userId = httpContextAccessor.HttpContext?.User?.FindFirst("UserId")?.Value;
                if (userId == null)
                {
                    logger.LogWarning("Current user not found");
                    return Results.Conflict("Couldn't update user avatar");
                }

                httpContextAccessor.HttpContext?.Request.EnableBuffering();
                string base64Avatar = await httpContextAccessor.HttpContext?.Request?.BodyReader.GetBase64String();
                httpContextAccessor.HttpContext?.Request.Body.Seek(0, SeekOrigin.Begin);

                User? user = await userService.GetUserById(userId);
                if (user == null)
                {
                    logger.LogWarning("User not found with id: {userId}", userId);
                    return Results.Conflict("Couldn't update user avatar");
                }

                await userService.UpdateAvatar(user, base64Avatar);

                logger.LogInformation("Avatar successfully updated for user with id: {userId}", userId);
                return Results.Ok("Successfully updated user avatar");
            }).WithTags("User")
              .Produces(StatusCodes.Status200OK)
              .Produces(StatusCodes.Status409Conflict)
              .Accepts<IFormFile>("image/png,image/jpg");

            webApplication.MapDelete("/user/avatar",
            [SwaggerResponse(200, "Successfully removed user avatar")]
            [SwaggerResponse(409, "Unable to remove user avatar")]
            [SwaggerOperation(
                    Summary = "Deletes user avatar | [Authorized]",
                    Description = "Deletes signed in user's avatar")]
            [Authorize] async (IHttpContextAccessor httpContextAccessor, IUserService userService) =>
            {
                logger.LogInformation("Removing user avatar");

                var userId = httpContextAccessor.HttpContext?.User?.FindFirst("UserId")?.Value;
                if (userId == null)
                {
                    logger.LogWarning("Current user not found");
                    return Results.Conflict("Couldn't remove user avatar");
                }

                User? user = await userService.GetUserById(userId);
                if (user == null)
                {
                    logger.LogWarning("User not found with id: {userId}", userId);
                    return Results.Conflict("Couldn't remove user avatar");
                }

                await userService.RemoveAvatar(user);

                logger.LogInformation("Avatar successfully removed for user with id: {userId}", userId);
                return Results.Ok("User avatar successfully removed");
            }).WithTags("User")
              .Produces(StatusCodes.Status200OK)
              .Produces(StatusCodes.Status409Conflict);

            webApplication.MapGet("/user/avatar",
            [SwaggerResponse(200, "Returns user avatar as .jpg image file")]
            [SwaggerResponse(409, "Unable to retrieve user avatar")]
            [SwaggerOperation(
                    Summary = "Retrieve user avatar | [Authorized]",
                    Description = "Retrieves signed in user's avatar")]
            [Authorize] async (IHttpContextAccessor httpContextAccessor, IUserService userService) =>
            {
                logger.LogInformation("Getting user avatar");

                var userId = httpContextAccessor.HttpContext?.User?.FindFirst("UserId")?.Value;
                if (userId == null)
                {
                    logger.LogWarning("Current user not found");
                    return Results.Conflict("Couldn't retrieve user avatar");
                }

                User? user = await userService.GetUserById(userId);
                if (user == null)
                {
                    logger.LogWarning("User not found with id: {userId}", userId);
                    return Results.Conflict("Couldn't retrieve user avatar");
                }

                if (user.Avatar == null) return Results.Ok();

                logger.LogInformation("Avatar successfully retrieved for user with id: {userId}", userId);

                return Results.File(Convert.FromBase64String(user.Avatar), "image/jpg");

            }).WithTags("User")
              .Produces<IResult>(StatusCodes.Status200OK)
              .Produces(StatusCodes.Status409Conflict);

            webApplication.MapPost("/user/login",
            [SwaggerResponse(200, "Returns JWT and time until the token becomes invalid")]
            [SwaggerResponse(409, "Couldn't sign in user with provided credentials")]
            [SwaggerOperation(
                    Summary = "Sign in user | [Anonymous]",
                    Description = "Signs in user with provided credentials")]
            [AllowAnonymous] async (LoginDTO loginDTO, IUserService userService) =>
            {
                logger.LogInformation("Attempting to log in user with email {email}", loginDTO.Email);

                LoginResponseDTO tokenDto;
                try
                {
                    tokenDto = await userService.Login(loginDTO);
                }
                catch (Exception exception)
                {
                    logger.LogWarning(exception, "Couldn't login user with email {email}", loginDTO.Email);
                    return Results.Conflict("Couldn't login user with provided login information");
                }

                return Results.Ok(tokenDto);
            }).WithTags("User")
              .Produces<LoginDTO>(StatusCodes.Status200OK)
              .Produces(StatusCodes.Status409Conflict);

            webApplication.MapGet("/user/{email}",
            [SwaggerResponse(200, "Returns basic user information by their email")]
            [SwaggerResponse(409, "Unable to retrieve basic user information by email")]
            [SwaggerOperation(
                    Summary = "Get user by email | [Anonymous]",
                    Description = "Gets user with provided email address")]
            [AllowAnonymous] async (string email, IUserService userService) =>
                {
                    logger.LogInformation("Attempting to get user with email {email}", email);

                    UserDTO? user;
                    try
                    {
                        user = await userService.GetUserDTOByEmail(Uri.UnescapeDataString(email));
                    }
                    catch (Exception exception)
                    {
                        logger.LogWarning(exception, "Couldn't retrieve user with email {email}", email);
                        return Results.Conflict("Couldn't retrieve user with provided email");
                    }

                    return Results.Ok(user);
                }).WithTags("User")
                  .Produces<UserDTO>(StatusCodes.Status200OK)
                  .Produces(StatusCodes.Status409Conflict);
        }
    }
}
