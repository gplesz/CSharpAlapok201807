using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace _03CodeFirstCore.Models
{
    public class CodeFirstContext : DbContext
    {
        public CodeFirstContext(DbContextOptions<CodeFirstContext> options) : base(options)
        {

        }

        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Subject> Subjects { get; set; }
    }
}
