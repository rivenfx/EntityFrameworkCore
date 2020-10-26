using System;
using System.Data.Common;

using Devart.Data.Oracle.Entity;

using JetBrains.Annotations;

using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;

namespace Microsoft.EntityFrameworkCore
{
    public static class RivenDevartOracleDbContextOptionsExtensions
    {
        /// <summary>
        /// Configures the context to connect to a Oracle database. by RivenFx
        /// </summary>
        /// <param name="optionsBuilder"> The builder being used to configure the context. </param>
        /// <param name="connectionString"> The connection string of the database to connect to. </param>
        /// <param name="oracleOptionsAction">An optional action to allow additional Oracle specific configuration.</param>
        /// <returns> The options builder so that further configuration can be chained. </returns>
        public static DbContextOptionsBuilder UseRivenDevartOracle(
             [NotNull] this DbContextOptionsBuilder optionsBuilder,
             [NotNull] string connectionString,
             [CanBeNull] Action<OracleDbContextOptionsBuilder> databaseOptionsBuilderAction = null
            )
        {
            optionsBuilder.UseOracle(connectionString, (dbContextOptionsBuilder) =>
            {
                databaseOptionsBuilderAction?.Invoke(dbContextOptionsBuilder);
            });

            optionsBuilder.UseRivenDevartOracleSqlGeneration();

            return optionsBuilder;
        }

        /// <summary>
        ///     Configures the context to connect to a Oracle database. by RivenFx
        /// </summary>
        /// <param name="optionsBuilder"> The builder being used to configure the context. </param>
        /// <param name="connection">
        ///     An existing <see cref="DbConnection" /> to be used to connect to the database. If the connection is
        ///     in the open state then EF will not open or close the connection. If the connection is in the closed
        ///     state then EF will open and close the connection as needed.
        /// </param>
        /// <param name="oracleOptionsAction">An optional action to allow additional Oracle specific configuration.</param>
        /// <returns> The options builder so that further configuration can be chained. </returns>
        public static DbContextOptionsBuilder UseRivenDevartOracle([NotNull] this DbContextOptionsBuilder optionsBuilder,
            [NotNull] DbConnection connection,
            [CanBeNull] Action<OracleDbContextOptionsBuilder> databaseOptionsBuilderAction = null)
        {
            optionsBuilder.UseOracle(connection, (dbContextOptionsBuilder) =>
            {
                databaseOptionsBuilderAction?.Invoke(dbContextOptionsBuilder);
            });

            optionsBuilder.UseRivenDevartOracleSqlGeneration();

            return optionsBuilder;
        }


        /// <summary>
        /// 使用RivenFx的SqlGeneration实现
        /// </summary>
        /// <param name="optionsBuilder"></param>
        /// <returns></returns>
        public static DbContextOptionsBuilder UseRivenDevartOracleSqlGeneration(this DbContextOptionsBuilder optionsBuilder)
        {
            return optionsBuilder
                 .ReplaceService<ISqlGenerationHelper, RivenDevartOracleSqlGenerationHelper>();
        }

    }
}
