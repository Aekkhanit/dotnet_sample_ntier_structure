using BusUserCore.Models;
using DB_TestServices.Context_Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BusUserCore.Mappings
{
    public static class UserMappings
    {
        public static TB_User ToDataModel(this User_Model source)
        {
            return new TB_User()
            {
                Email = source.email,
                First_Name = source.first_name,
                Last_Name = source.last_name,
                Tel = source.Tel,
                Type = source.Tel,
                Username = source.username,
            };
        }

        public static User_Model FromDataModel(this TB_User source, string[] _db_roles = null)
        {
            return new User_Model()
            {
                email = source.Email,
                username = source.Username,
                Tel = source.Tel,
                last_name = source.Last_Name,
                first_name = source.First_Name,
                type = source.Type,
                role = _db_roles != null && _db_roles.Length > 0 ? _db_roles : new string[] { },
                tel = source.Tel
            };
        }

    }
}
