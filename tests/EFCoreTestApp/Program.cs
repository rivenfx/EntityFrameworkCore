using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace EFCoreTestApp
{
    public class Program
    {
        public static void Main(string[] args)
        {
            //System.Reflection.DispatchProxy.Create()


            var types = typeof(OracleDbContextOptionsBuilderExtensions).Assembly.GetTypes();
            var entitySqlGeneratorHelperType = default(Type);
            var oracleEntitySqlGeneratorHelperType = default(Type);

            foreach (var type in types)
            {
                if (type.Name.ToLower()== "EntityProviderNaming".ToLower())
                {

                }

                if (type.IsAbstract
                    && type.GetInterface("ISqlGenerationHelper") != null
                    )
                {
                    entitySqlGeneratorHelperType = type;
                    continue;
                }


                if (!type.IsAbstract
                    && type.GetInterface("ISqlGenerationHelper") != null
                    )
                {
                    oracleEntitySqlGeneratorHelperType = type;
                    continue;
                }
            }















            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }


}
