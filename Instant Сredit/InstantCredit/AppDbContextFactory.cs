using Infrastructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InstantCredit
{
    class AppDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
    {

        public AppDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<AppDbContext>();
            optionsBuilder.UseNpgsql("Server=newsdts.postgres.database.azure.com;UserName=postgres@newsdts;Database=dtsitis;Port=5432;Password=12345Qwert;SSLMode=Prefer");

            return new AppDbContext(optionsBuilder.Options);
        }
    }
}
