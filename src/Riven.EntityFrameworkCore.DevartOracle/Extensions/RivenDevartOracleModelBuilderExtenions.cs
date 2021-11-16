using Microsoft.EntityFrameworkCore.Metadata;

using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.EntityFrameworkCore.Extensions
{
    public static class RivenDevartOracleModelBuilderExtenions
    {
        /// <summary>
        /// 表映射到 Devart Oracle, 表名/列名 大写
        /// </summary>
        /// <param name="modelBuilder">modelBuilder</param>
        /// <param name="verifyingEntityType">验证实体类型是否需要处理</param>
        /// <returns>modelBuilder</returns>
        public static ModelBuilder TableMappingToDevartOracle(this ModelBuilder modelBuilder,
            Func<IMutableEntityType, bool> verifyingEntityType)
        {
            return modelBuilder.TableMappingTo(verifyingEntityType, (s) => s.ToUpper());
        }

        /// <summary>
        /// 表映射到 Devart Oracle, 表名/列名 大写
        /// </summary>
        /// <param name="modelBuilder">modelBuilder</param>
        /// <returns>modelBuilder</returns>
        public static ModelBuilder TableMappingToDevartOracle(this ModelBuilder modelBuilder)
        {
            return modelBuilder.TableMappingToDevartOracle((e) => true);
        }
    }
}
