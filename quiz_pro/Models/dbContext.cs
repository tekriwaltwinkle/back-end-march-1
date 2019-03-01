using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace quiz_pro.Models
{
    public class dbContext : DbContext
    {
        public dbContext(DbContextOptions<dbContext> options)
            : base(options)
        { }
        public DbSet<question> questions { get; set; }
        public DbSet<quiz> quizs { get; set; }
        public DbSet<score> scores { get; set; }
        public DbSet<user> users { get; set; }
        public DbSet<admin> admins { get; set; }

    }
}
