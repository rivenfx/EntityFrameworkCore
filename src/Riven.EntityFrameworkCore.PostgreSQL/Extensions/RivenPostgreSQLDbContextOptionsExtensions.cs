using JetBrains.Annotations;

using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;

using Npgsql.EntityFrameworkCore.PostgreSQL.Infrastructure;

using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Text;

namespace Microsoft.EntityFrameworkCore
{
    public static class RivenPostgreSQLDbContextOptionsExtensions
    {
        /// <summary>
        /// Configures the context to connect to a PostgreSQL database. by RivenFx
        /// </summary>
        /// <param name="optionsBuilder"> The builder being used to configure the context. </param>
        /// <param name="connectionString"> The connection string of the database to connect to. </param>
        /// <param name="dbContextOptionsAction">An optional action to allow additional PostgreSQL specific configuration.</param>
        /// <returns> The options builder so that further configuration can be chained. </returns>
        public static DbContextOptionsBuilder UseRivenPostgreSQL(
             [NotNull] this DbContextOptionsBuilder optionsBuilder,
             [NotNull] string connectionString,
             [CanBeNull] Action<NpgsqlDbContextOptionsBuilder> dbContextOptionsAction = null
            )
        {
            optionsBuilder.UseNpgsql(
                connectionString,
                (dbContextOptionsBuilder) =>
                {
                    dbContextOptionsAction?.Invoke(dbContextOptionsBuilder);
                })
                .UseRivenPostgreSqlGeneration();


            return optionsBuilder;
        }

        /// <summary>
        ///     Configures the context to connect to a PostgreSQL database. by RivenFx
        /// </summary>
        /// <param name="optionsBuilder"> The builder being used to configure the context. </param>
        /// <param name="connection">
        ///     An existing <see cref="DbConnection" /> to be used to connect to the database. If the connection is
        ///     in the open state then EF will not open or close the connection. If the connection is in the closed
        ///     state then EF will open and close the connection as needed.
        /// </param>
        /// <param name="dbContextOptionsAction">An optional action to allow additional PostgreSQL specific configuration.</param>
        /// <returns> The options builder so that further configuration can be chained. </returns>
        public static DbContextOptionsBuilder UseRivenPostgreSQL([NotNull] this DbContextOptionsBuilder optionsBuilder,
            [NotNull] DbConnection connection,
            [CanBeNull] Action<NpgsqlDbContextOptionsBuilder> dbContextOptionsAction
            = null)
        {
            optionsBuilder.UseNpgsql(
                 connection,
                 (dbContextOptionsBuilder) =>
                 {
                     dbContextOptionsAction?.Invoke(dbContextOptionsBuilder);
                 })
                 .UseRivenPostgreSqlGeneration();
            return optionsBuilder;
        }


        /// <summary>
        /// 使用RivenFx的PostgreSQL SqlGeneration实现
        /// </summary>
        /// <param name="optionsBuilder"></param>
        /// <returns></returns>
        public static DbContextOptionsBuilder UseRivenPostgreSqlGeneration(this DbContextOptionsBuilder optionsBuilder)
        {
            return optionsBuilder
                     .ReplaceService<ISqlGenerationHelper, RivenPostgreSqlSqlGenerationHelper>();
        }

    }
}
