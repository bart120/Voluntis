using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Voluntis.Models;

namespace Voluntis.Data
{
    public class VoluntisDbContext : DbContext
    {
        public VoluntisDbContext(DbContextOptions<VoluntisDbContext> options) : base(options)
        {
        }

        public DbSet<Category> Categories { get; set; }
    }
}
