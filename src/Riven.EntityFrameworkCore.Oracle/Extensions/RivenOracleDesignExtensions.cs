using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Microsoft.EntityFrameworkCore.Extensions
{

    public static class RivenOracleDesignExtensions
    {
        /// <summary>
        /// <see cref="OracleModelBuilderExtensions.UseIdentityColumns"/>
        /// </summary>
        /// <param name="modelBuilder"></param>
        /// <param name="seed"></param>
        /// <param name="increment"></param>
        /// <returns></returns>
        public static ModelBuilder UseIdentityColumnsOracle(this ModelBuilder modelBuilder, int seed = 1, int increment = 1)
        {
            return OracleModelBuilderExtensions.UseIdentityColumns(modelBuilder, seed, increment);
        }

        /// <summary>
        /// <see cref="<see cref="OraclePropertyBuilderExtensions.UseIdentityColumn"/>"/>
        /// </summary>
        /// <param name="propertyBuilder"></param>
        /// <param name="seed"></param>
        /// <param name="increment"></param>
        /// <returns></returns>
        public static PropertyBuilder UseIdentityColumnOracle(
            [NotNull] this PropertyBuilder propertyBuilder,
            int seed = 1,
            int increment = 1)
        {
            return OraclePropertyBuilderExtensions.UseIdentityColumn(propertyBuilder, seed, increment);
        }
    }
}
