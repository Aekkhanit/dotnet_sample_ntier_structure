using DB_TestServices.Context_Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks; 

namespace UserService.Infrastructure
{
    /// you can generate any context with Scaffolding
    /// In this conext just manual from code
    public class DB_TestContext : DbContext
    {
        public DB_TestContext(string connection_string) : base(GetOptions(connection_string))
        {
        }

        private static DbContextOptions GetOptions(string connectionString)
        {
            return SqlServerDbContextOptionsExtensions.UseSqlServer(new DbContextOptionsBuilder(), connectionString
                 ).Options;
        }

        public DB_TestContext(DbContextOptions<DB_TestContext> options): base(options)
        { }

        public virtual DbSet<TB_User> TB_User { get; set; }

    }

}
