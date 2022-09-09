using Bill.Model;
using Microsoft.EntityFrameworkCore;

namespace Bill.Model.Context
{
    public class MySQLContext : DbContext
    {
        public MySQLContext() { }
        public MySQLContext(DbContextOptions<MySQLContext> options) : base(options) { }

        public DbSet<BillModel> Bills { get; set; }
        public DbSet<BillInfo> BillInfo { get; set; }
    }
}
