using BusUserCore.Mappings;
using BusUserCore.Models;
using DB_TestServices.GenericRepository;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using UserService.Infrastructure.SpecificRepository;
using UtilitiesServices.JWT;

namespace BusUserServices
{
    public interface IBusAUserServices
    {
        public Task<string> GenerateTokenAsync(string user_or_email);
        public Task<User_Model> GetUserInfoByUsernameAsync(string username);
        public Task<User_Model> GetUserInfoFromEmailAsync(string email);

    }
    public class BusAUserServices : IBusAUserServices
    {
        private readonly IUserRepository _IUserRepository;
        private readonly IUserAuthorizeRepository _IUserAuthorizeRepository;
        private readonly IJwtServices _IJwtServices;

        public BusAUserServices(IUserRepository IUserRepository, IJwtServices IJwtServices, IUserAuthorizeRepository IUserAuthorizeRepository)
        {
            _IUserAuthorizeRepository = IUserAuthorizeRepository;
            _IUserRepository = IUserRepository;
            _IJwtServices = IJwtServices;
        }

        public async Task<User_Model> GetUserInfoByUsernameAsync(string username)
        {
            var _db_user = await _IUserRepository.GetUserByUsernameAsync(username);
            if (_db_user == null)
                throw new Exception("user not found");
            else
            {
                var _db_roles = await _IUserAuthorizeRepository.GetTotalRolesOfUserAsync(_db_user);
                return _db_user.FromDataModel(_db_roles);
            }

        }

        public async Task<User_Model> GetUserInfoFromEmailAsync(string email)
        {
            var _db_user = await _IUserRepository.GetUserByEmailAsync(email);
            if (_db_user == null)
                throw new Exception("user not found");
            else
            {
                var _db_roles = await _IUserAuthorizeRepository.GetTotalRolesOfUserAsync(_db_user);
                return _db_user.FromDataModel(_db_roles);
            }
        }

        public async Task<string> GenerateTokenAsync(string user_or_email)
        {
            return await _IJwtServices.GenerateTokenAsync(user_or_email);
        }

    }
}
