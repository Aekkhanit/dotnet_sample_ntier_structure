using DB_TestServices.Context_Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks; 

namespace UserService.Infrastructure.SpecificRepository
{
    public interface IUserAuthorizeRepository
    {
        public Task<string[]> GetTotalRolesOfUserAsync(TB_User user);
    }
    public class UserAuthorizeRepository : IUserAuthorizeRepository
    {
        private readonly DB_TestContext _DB_TestContext;
        public UserAuthorizeRepository(DB_TestContext DB_TestContext)
        {
            _DB_TestContext = DB_TestContext;
        }

        public async Task<string[]> GetTotalRolesOfUserAsync(TB_User user)
        {
            //you can code here to connect your context with many table for relation of data or some customize logic
            //eg. tb_user, tb_role, tb_permission

            //retreive role from db (eg. var _db_roles=_MyDB_Context.TB_Roles.ToList()
            switch (user.Type)
            {
                case "admin":
                    return await Task.FromResult(new string[] { "admin", "super_admin" });

                default:
                    return await Task.FromResult(new string[] { "staff" });
            }

        }
    }
}
