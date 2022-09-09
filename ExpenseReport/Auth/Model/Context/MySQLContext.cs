using Auth.Model;
using Microsoft.EntityFrameworkCore;

namespace Auth.Model.Context
{
    public class MySQLContext : DbContext
    {
        public MySQLContext() { }
        public MySQLContext(DbContextOptions<MySQLContext> options) : base(options) { }

    }
}
