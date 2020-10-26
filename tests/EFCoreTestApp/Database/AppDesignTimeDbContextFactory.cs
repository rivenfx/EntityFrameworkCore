using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore.Design.Internal;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;

namespace EFCoreTestApp.Database
{
    public class AppDesignTimeDbContextFactory : IDesignTimeDbContextFactory<AppDbContext>
    {
        public AppDbContext CreateDbContext(string[] args)
        {
            var builder = new DbContextOptionsBuilder<AppDbContext>();


            //builder.UseRivenOracle(
            //    ""
            //     );
            //builder.UseRivenPostgreSQL(
            //    ""
            //);

            builder.UseRivenPostgreSQL(
                "server=;port=;database=;uid=;pwd=;"
                );

            return new AppDbContext(builder.Options);
        }
    }
}
