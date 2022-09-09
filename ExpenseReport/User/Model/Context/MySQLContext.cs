using Microsoft.EntityFrameworkCore;

namespace User.Model.Context
{
    public class MySQLContext : DbContext
    {
        public MySQLContext() { }
        public MySQLContext(DbContextOptions<MySQLContext> options) : base(options) { }
        public DbSet<UserModel> Users { get; set; }
    }
}
