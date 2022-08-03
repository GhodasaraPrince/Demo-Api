using Microsoft.EntityFrameworkCore;
using test_dynamic_api.Models;

namespace test_dynamic_api.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<Registration> Registration { get; set; }

        public DbSet<User> User { get; set; }

        public DbSet<CreateModel> CreateTableData { get; set; }

        public DbSet<Fields> CreateTableField { get; set; }
    }
}
