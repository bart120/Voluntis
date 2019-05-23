using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Voluntis.Models;

namespace Voluntis.Data
{
    public class VoluntisDbContext : IdentityDbContext<User>//DbContext
    {
        public VoluntisDbContext(DbContextOptions<VoluntisDbContext> options) : base(options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Book>().Property(p => p.Price).HasColumnType("decimal(6,2)");
            base.OnModelCreating(builder);
        }

        public DbSet<Category> Categories { get; set; }

        public DbSet<Book> Books { get; set; }
    }
}
