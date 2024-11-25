
using Microsoft.EntityFrameworkCore;

namespace Cafe.Data
{

    public  class CafeMSSQLDbContext : CafeDbContext
    {
 //       public CafeMSSQLDbContext(DbContextOptions options) : base(options)
 //       {
 //
//
 //       }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlServer();
        }
    }
}
