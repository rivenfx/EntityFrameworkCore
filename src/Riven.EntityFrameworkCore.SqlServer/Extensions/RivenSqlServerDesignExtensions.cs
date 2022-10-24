using JetBrains.Annotations;

using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Microsoft.EntityFrameworkCore
{

    public static class RivenSqlServerDesignExtensions
    {
        /// <summary>
        /// <see cref="OracleModelBuilderExtensions.UseIdentityColumns"/>
        /// </summary>
        /// <param name="modelBuilder"></param>
        /// <param name="seed"></param>
        /// <param name="increment"></param>
        /// <returns></returns>
        public static ModelBuilder UseIdentityColumnsSqlServer(this ModelBuilder modelBuilder, int seed = 1, int increment = 1)
        {
            return SqlServerModelBuilderExtensions.UseIdentityColumns(modelBuilder, seed, increment);
        }

        /// <summary>
        /// <see cref="<see cref="OraclePropertyBuilderExtensions.UseIdentityColumn"/>"/>
        /// </summary>
        /// <param name="propertyBuilder"></param>
        /// <param name="seed"></param>
        /// <param name="increment"></param>
        /// <returns></returns>
        public static PropertyBuilder UseIdentityColumnSqlServer(
            [NotNull] this PropertyBuilder propertyBuilder,
            int seed = 1,
            int increment = 1)
        {
            return SqlServerPropertyBuilderExtensions.UseIdentityColumn(propertyBuilder, seed, increment);
        }
    }
}
