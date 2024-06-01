using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UE.STOREDB.DOMAIN.Core.DTO;
using UE.STOREDB.DOMAIN.Core.Entities;
using UE.STOREDB.DOMAIN.Core.Interfaces;

namespace UE.STOREDB.DOMAIN.Core.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        private readonly IJWTService _jWTService;
        public UserService(IUserRepository userRepository, IJWTService jWTService)
        {
            _userRepository = userRepository;
            _jWTService = jWTService;
        }



        public async Task<UserResponseAuthDTO> SignIn(string email, string pwd)
        {
            var user = await _userRepository.SignIn(email, pwd);
            if (user == null)
                return null;

            //TODO: implementar token & email
            var token = _jWTService.GenerateJWToken(user);
            var sendEmail = false;

            var userResponseAuth = new UserResponseAuthDTO()
            {
                Id = user.Id,
                Email = email,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Country = user.Country,
                DateOfBirth = user.DateOfBirth,
                Token = token,
                IsEmailSent = sendEmail,
                Address = user.Address
            };
            return userResponseAuth;
        }

        public async Task<bool> Insert(User user)
        {
            return await _userRepository.Insert(user);
        }
    }
}
