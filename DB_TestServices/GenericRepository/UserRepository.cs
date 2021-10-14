using DB_TestServices.Context_Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks; 

namespace DB_TestServices.GenericRepository
{
    public interface IUserRepository
    {
        TB_User GetUserByUsername(string username);
        TB_User GetUserByEmail(string email);
    }
    public class UserRepository : IUserRepository
    {
        private readonly IGenericRepository<TB_User> _IGenericRepository;

        public UserRepository(IGenericRepository<TB_User> IGenericRepository)
        {
            this._IGenericRepository = IGenericRepository;
        }

        public TB_User GetUserByEmail(string email)
        {
            //simple query data with generic class
            //error always without real connection
            try
            {
                return this._IGenericRepository.Table.FirstOrDefault(s => s.Email == email);

            }
            catch (Exception ex)
            {

                return new TB_User()
                {
                    Username = "aaa",
                    Email = email,
                    First_Name = "aaa",
                    Last_Name = "bbb",
                    Tel = "00000000",
                    Type = "admin"
                };
            }
        }

        public TB_User GetUserByUsername(string username)
        {
            //simple query data with generic class
            //error always without real connection
            try
            {
                return this._IGenericRepository.Table.FirstOrDefault(s => s.Username == username);
            }
            catch (Exception ex)
            {

                return new TB_User()
                {
                    Username = username,
                    Email = "aaa@bbb.com",
                    First_Name = "aaa",
                    Last_Name = "bbb",
                    Tel = "00000000",
                    Type = "admin"
                };
            }
        }
    }
}
