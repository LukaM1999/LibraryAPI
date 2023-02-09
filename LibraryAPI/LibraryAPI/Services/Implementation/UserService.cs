using LibraryAPI.DTO;
using LibraryCL.Model;
using LibraryCL.Repository;

namespace LibraryAPI.Services.Implementation
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly ILogger _logger;

        public UserService(IUnitOfWork unitOfWork, ILogger<UserService> logger)
        {
            _unitOfWork = unitOfWork;
            _logger = logger;
        }

        public async Task<User?> GetUserById(int id)
        {
            _logger.LogInformation("Getting user with id: {id}", id);
            return await _unitOfWork.UserRepository.GetById(id);
        }

        public async Task RegisterUser(UserRegistrationDTO userRegistrationDto)
        {
            await Task.CompletedTask;
        }
    }
}
