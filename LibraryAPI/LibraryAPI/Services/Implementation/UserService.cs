using AutoMapper;
using LibraryAPI.DTO;
using LibraryAPI.Security;
using LibraryCL.Model;
using LibraryCL.Repository;

namespace LibraryAPI.Services.Implementation
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger _logger;
        private readonly IMapper _mapper;

        public UserService(IUnitOfWork unitOfWork, ILogger<UserService> logger, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
            _mapper = mapper;

        }

        public async Task<User?> GetUserById(int id)
        {
            _logger.LogInformation("Getting user with id: {id}", id);
            return await _unitOfWork.UserRepository.GetById(id);
        }

        public async Task RegisterUser(UserRegistrationDTO userRegistrationDto)
        {
            _logger.LogInformation("Mapping user registration data transfer object to user model");
            User user = _mapper.Map<User>(userRegistrationDto);
            try
            {
                _logger.LogInformation("Hashing provided password");
                user.Password = Hasher.HashPassword(userRegistrationDto.Password);
            }
            catch (ArgumentNullException)
            {
                _logger.LogWarning("Provided password can't be null or empty");
            }
            _logger.LogInformation("Creating user");
            await _unitOfWork.UserRepository.Create(user);
            _logger.LogInformation("Saving user");
            await _unitOfWork.Save();
        }
    }
}
