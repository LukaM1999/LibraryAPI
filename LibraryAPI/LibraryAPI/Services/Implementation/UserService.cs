using AutoMapper;
using LibraryAPI.DTO;
using LibraryAPI.Exceptions;
using LibraryAPI.Options;
using LibraryCL.Model;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace LibraryAPI.Services.Implementation
{
    public class UserService : IUserService
    {
        private readonly IMapper _mapper;
        private readonly UserManager<User> _userManager;
        private readonly JWTOptions _jwtOptions;

        public UserService(IMapper mapper, UserManager<User> userManager, IOptions<JWTOptions> jwtOptions)
        {
            _mapper = mapper;
            _userManager = userManager;
            _jwtOptions = jwtOptions.Value;
        }

        public async Task<User?> GetUserById(string id)
        {
            return await _userManager.FindByIdAsync(id);
        }

        public async Task<IdentityResult> RegisterUser(UserRegistrationDTO userRegistrationDto)
        {
            User user = _mapper.Map<User>(userRegistrationDto);

            var creationResult = await _userManager.CreateAsync(user, userRegistrationDto.Password);
            if(!creationResult.Succeeded)
            {
                return creationResult;
            }

            return await _userManager.AddToRoleAsync(user, Roles.User);
        }

        public async Task UpgradeUserToLibrarian(string userId)
        {
            var user = await GetUserById(userId);
            if(user == null)
            {
                throw new UserNotFoundException(nameof(user));
            }

            var roleRemovalResult = await _userManager.RemoveFromRoleAsync(user, Roles.User);
            if (!roleRemovalResult.Succeeded)
            {
                throw new RoleRemovalException(nameof(user));
            }

            var roleAdditionResult = await _userManager.AddToRoleAsync(user, Roles.Librarian);
            if (!roleAdditionResult.Succeeded)
            {
                throw new RoleAdditionException(nameof(user));
            }
        }

        public async Task DowngradeLibrarianToUser(string userId)
        {
            var user = await GetUserById(userId);
            if (user == null)
            {
                throw new UserNotFoundException(nameof(user));
            }

            var roleRemovalResult = await _userManager.RemoveFromRoleAsync(user, Roles.Librarian);
            if (!roleRemovalResult.Succeeded)
            {
                throw new RoleRemovalException(nameof(user));
            }

            var roleAdditionResult = await _userManager.AddToRoleAsync(user, Roles.User);
            if (!roleAdditionResult.Succeeded)
            {
                throw new RoleAdditionException(nameof(user));
            }
        }

        public async Task<LoginResponseDTO> Login(LoginDTO loginDTO)
        {
            var user = await _userManager.FindByEmailAsync(loginDTO.Email);
            if (user == null)
            {
                throw new UserNotFoundException(nameof(user));
            }

            var isLoginValid = await _userManager.CheckPasswordAsync(user, loginDTO.Password);
            if(!isLoginValid)
            {
                throw new InvalidLoginException(nameof(user));
            }

            var userRoles = await _userManager.GetRolesAsync(user);

            var authClaims = new List<Claim>
                {
                    new Claim("UserId", user.Id),
                    new Claim(ClaimTypes.Email, user.Email),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                };

            foreach (var userRole in userRoles)
            {
                authClaims.Add(new Claim(ClaimTypes.Role, userRole.ToUpper()));
            }

            var token = GetToken(authClaims);
            return new LoginResponseDTO
            {
                JWT = new JwtSecurityTokenHandler().WriteToken(token),
                ValidTo = token.ValidTo
            };
        }

        private JwtSecurityToken GetToken(List<Claim> authClaims)
        {
            var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_jwtOptions.Secret));

            var token = new JwtSecurityToken(
                issuer: _jwtOptions.ValidIssuer,
                audience: _jwtOptions.ValidAudience,
                expires: DateTime.UtcNow.AddMinutes(30),
                claims: authClaims,
                signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
                );

            return token;
        }
    }
}
