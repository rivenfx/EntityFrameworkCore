using System;
using System.Data.Common;

using JetBrains.Annotations;

using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;

using Oracle.EntityFrameworkCore.Infrastructure;

namespace Microsoft.EntityFrameworkCore
{
    public static class RivenOracleDbContextOptionsExtensions
    {
        /// <summary>
        /// Configures the context to connect to a Oracle database. by RivenFx
        /// </summary>
        /// <param name="optionsBuilder"> The builder being used to configure the context. </param>
        /// <param name="connectionString"> The connection string of the database to connect to. </param>
        /// <param name="oracleOptionsAction">An optional action to allow additional Oracle specific configuration.</param>
        /// <returns> The options builder so that further configuration can be chained. </returns>
        public static DbContextOptionsBuilder UseRivenOracle(
             [NotNull] this DbContextOptionsBuilder optionsBuilder,
             [NotNull] string connectionString,
             [CanBeNull] Action<OracleDbContextOptionsBuilder> oracleOptionsAction = null
            )
        {
            optionsBuilder.UseOracle(
                connectionString,
                (oracleDbContextOptionsBuilder) =>
                {
                    oracleDbContextOptionsBuilder.UseOracleSQLCompatibility();
                    oracleOptionsAction?.Invoke(oracleDbContextOptionsBuilder);
                })
                .UseRivenOracleSqlGeneration();


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
        public static DbContextOptionsBuilder UseRivenOracle([NotNull] this DbContextOptionsBuilder optionsBuilder,
            [NotNull] DbConnection connection,
            [CanBeNull] Action<OracleDbContextOptionsBuilder> oracleOptionsAction = null)
        {
            optionsBuilder.UseOracle(
                connection,
                (oracleDbContextOptionsBuilder) =>
                {
                    oracleDbContextOptionsBuilder.UseOracleSQLCompatibility();
                    oracleOptionsAction?.Invoke(oracleDbContextOptionsBuilder);
                })
                .UseRivenOracleSqlGeneration();
            return optionsBuilder;
        }


        /// <summary>
        /// 设置Oracle兼容性,默认为11
        /// </summary>
        /// <param name="oracleDbContextOptionsBuilder"></param>
        /// <param name="oracleSQLCompatibility"></param>
        /// <returns></returns>
        public static OracleDbContextOptionsBuilder UseOracleSQLCompatibility(this OracleDbContextOptionsBuilder oracleDbContextOptionsBuilder, OracleSQLCompatibility oracleSQLCompatibility = OracleSQLCompatibility.V11)
        {
            switch (oracleSQLCompatibility)
            {
                case OracleSQLCompatibility.V12:
                    oracleDbContextOptionsBuilder.UseOracleSQLCompatibility("12");
                    break;
                case OracleSQLCompatibility.V11:
                default:
                    oracleDbContextOptionsBuilder.UseOracleSQLCompatibility("11");
                    break;
            }

            return oracleDbContextOptionsBuilder;
        }

        /// <summary>
        /// 使用RivenFx的SqlGeneration实现
        /// </summary>
        /// <param name="optionsBuilder"></param>
        /// <returns></returns>
        public static DbContextOptionsBuilder UseRivenOracleSqlGeneration(this DbContextOptionsBuilder optionsBuilder)
        {
            return optionsBuilder
                 .ReplaceService<ISqlGenerationHelper, RivenOracleSqlGenerationHelper>();
        }

    }
}
