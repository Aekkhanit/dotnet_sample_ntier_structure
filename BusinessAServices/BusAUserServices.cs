using BusUserCore.Mappings;
using BusUserCore.Models;
using DB_TestServices.GenericRepository;
using System;
using System.Collections.Generic;
using System.Text;
using UserService.Infrastructure.SpecificRepository;
using UtilitiesServices.JWT;

namespace BusUserServices
{
    public interface IBusAUserServices
    {
        public string GenerateToken(string user_or_email); 
        public User_Model GetUserInfoByUsername(string username);
        public User_Model GetUserInfoFromEmail(string email);

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

        public User_Model GetUserInfoByUsername(string username)
        {
            var _db_user = _IUserRepository.GetUserByUsername(username);
            if (_db_user == null)
                throw new Exception("user not found");
            else
            {
                var _db_roles = _IUserAuthorizeRepository.GetTotalRolesOfUser(_db_user);
                return _db_user.FromDataModel(_db_roles);
            }

        }

        public User_Model GetUserInfoFromEmail(string email)
        {
            var _db_user = _IUserRepository.GetUserByEmail(email);
            if (_db_user == null)
                throw new Exception("user not found");
            else
            {
                var _db_roles = _IUserAuthorizeRepository.GetTotalRolesOfUser(_db_user);
                return _db_user.FromDataModel(_db_roles);
            }
        }

        public string GenerateToken(string user_or_email)
        {
            return _IJwtServices.GenerateToken(user_or_email);
        }
 
    }
}
