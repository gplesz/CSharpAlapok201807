using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Text;

namespace _03CodeFirstCore.Models
{
    public class CodeFirstContextFactory : IDesignTimeDbContextFactory<CodeFirstContext>
    {
        public CodeFirstContext CreateDbContext(string[] args)
        {
            var connectionString = "Server=.\\SQLEXPRESS;Database=CodeFirstDB;Trusted_Connection=True;";

            var optionsBuilder = new DbContextOptionsBuilder<CodeFirstContext>();

            optionsBuilder.UseSqlServer(connectionString);

            return new CodeFirstContext(optionsBuilder.Options);
        }
    }
}
