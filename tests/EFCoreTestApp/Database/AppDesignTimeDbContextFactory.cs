using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

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

            // Êý¾Ý¿âÁ´½Ó×Ö·û´®
            var connectionString = string.Empty;

            // PostgreSQL

            builder.UseNpgsql(
                connectionString,
                (options) =>
                {

                });




            // Oracle
            builder.UseOracle(
                connectionString,
                (options) =>
                {
                    //  SQLCompatibility V11
                    options.UseOracleSQLCompatibility(OracleSQLCompatibility.V11);
                });




            // Devart Oracle

            var license = ""; // Devart license
            builder.UseDevartOracle(
                connectionString,
                license,
                (options) =>
                {

                });

            return new AppDbContext(builder.Options);
        }
    }
}
