using Queros.ProjectManagement.Data.Models;
using Queros.ProjectManagement.Data.Repositories;
using Queros.ProjectManagement.DTOs;
using Queros.ProjectManagement.Processors;

namespace Queros.ProjectManagement.Services;

    public class AuthenticationService
    {
        private readonly IHashingService _hashingService;
        private readonly ITokenServiceProvider _tokenServiceProvider;
        private readonly IUserRepository _userRepository;
        public AuthenticationService(IHashingService hashingService, ITokenServiceProvider tokenServiceProvider, IUserRepository userRepository)
        {
            _hashingService = hashingService;
            _tokenServiceProvider = tokenServiceProvider;
            _userRepository = userRepository;
        }

        public async Task<AuthResponseDto?> Register(AuthRequest newUser)
        {
            var user = new User
            {
                Id = Guid.NewGuid(),
                Name = newUser.UserName,
                PasswordHash = _hashingService.Hash(newUser.Password),
                Role = newUser.Role
            }; 
            
            var addedSuccessfully = await _userRepository.AddAsync(user);
            return addedSuccessfully ? _tokenServiceProvider.GenerateAccessToken(user) : null;
        }


        public async Task<AuthResponseDto?> Login(AuthRequest loginRequest)
        {
            var user = await _userRepository.GetFirstAsync(u => u, u => u.Name == loginRequest.UserName);
            if (user == null) return null;
            var isAuthorized = _hashingService.HashCheck(user.PasswordHash, loginRequest.Password);
            return isAuthorized ?  _tokenServiceProvider.GenerateAccessToken(user) : null;
        }
        
        public async Task<bool> CheckIfUserNameExist(string userName)
        {
            return await _userRepository.GetFirstAsync(x => x , x => x.Name == userName) != null;
        }
    }
