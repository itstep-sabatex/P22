using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;

namespace Cafe.Data
{
    public class CafeSQLiteDbContext : CafeDbContext
    {
        string _connectionString;
        public CafeSQLiteDbContext(string connectionString)
        {
            _connectionString = connectionString;
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlite(_connectionString);
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
