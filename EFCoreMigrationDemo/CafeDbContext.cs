using Cafe.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EFCore_Demo
{
    internal class CafeDbContext:DbContext
    {
        public DbSet<User> Users { get; set; }
        public DbSet<ClientTable> ClientTables { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder);
            optionsBuilder.UseSqlite("DataSource=C:/Users/serhi/.databases/itstep/cafe-demo-1.db");
        }
    }
}
