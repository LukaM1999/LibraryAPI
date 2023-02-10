using AutoMapper;
using Castle.DynamicProxy.Generators.Emitters.SimpleAST;
using LibraryAPI.DTO;
using LibraryCL.Model;
using LibraryCL.Repository;
using System.Linq.Expressions;

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
            User user = _mapper.Map<User>(userRegistrationDto);
            await _unitOfWork.UserRepository.Create(user);
            await _unitOfWork.Save();
        }
    }
}
