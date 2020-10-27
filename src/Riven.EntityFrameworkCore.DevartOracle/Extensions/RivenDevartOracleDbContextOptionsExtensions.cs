using System;
using System.Linq;
using System.Data.Common;

using Devart.Data.Oracle.Entity;

using JetBrains.Annotations;

using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage;
using Microsoft.EntityFrameworkCore.Storage.Internal;
using System.Runtime.CompilerServices;
using Devart.Data.Oracle.Entity.Configuration;

namespace Microsoft.EntityFrameworkCore
{
    public static class RivenDevartOracleDbContextOptionsExtensions
    {
        static RivenDevartOracleDbContextOptionsExtensions()
        {
            RivenDevartOracleDbContextOptionsExtensions
                .UseRivenDevartOracleQuoting(null, false);
        }

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
            return optionsBuilder.UseOracle(
                connectionString,
                (dbContextOptionsBuilder) =>
                {
                    databaseOptionsBuilderAction?.Invoke(dbContextOptionsBuilder);
                });

        }

        /// <summary>
        /// Configures the context to connect to a Oracle database. by RivenFx
        /// </summary>
        /// <param name="optionsBuilder"> The builder being used to configure the context. </param>
        /// <param name="connectionString"> The connection string of the database to connect to. </param>
        /// <param name="license"> Devart oracle drive license key. </param>
        /// <param name="oracleOptionsAction">An optional action to allow additional Oracle specific configuration.</param>
        /// <returns> The options builder so that further configuration can be chained. </returns>
        public static DbContextOptionsBuilder UseRivenDevartOracle(
             [NotNull] this DbContextOptionsBuilder optionsBuilder,
             [NotNull] string connectionString,
             [NotNull] string license,
             [CanBeNull] Action<OracleDbContextOptionsBuilder> databaseOptionsBuilderAction = null
            )
        {
            // 处理拼接证书
            if (!connectionString.ToLower().Contains("license key="))
            {
                if (connectionString.EndsWith(";"))
                {
                    connectionString = $"{connectionString}license key={license};";
                }
                else
                {
                    connectionString = $"{connectionString};license key={license};";
                }
            }

            return optionsBuilder.UseRivenDevartOracle(
                connectionString,
                databaseOptionsBuilderAction
                );

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
            return optionsBuilder.UseOracle(
                    connection,
                    (dbContextOptionsBuilder) =>
                    {
                        databaseOptionsBuilderAction?
                        .Invoke(dbContextOptionsBuilder);
                    });
        }

        /// <summary>
        /// 生成sql时包含双引号, 启用："Id" 不启用：Id
        /// </summary>
        /// <param name="optionsBuilder"></param>
        /// <param name="enable">是否启用,默认false</param>
        /// <returns></returns>
        public static DbContextOptionsBuilder UseRivenDevartOracleQuoting([NotNull] this DbContextOptionsBuilder optionsBuilder, bool enable = false)
        {
            OracleEntityProviderConfig.Instance.Workarounds
                .DisableQuoting = !enable;

            return optionsBuilder;
        }

    }
}
