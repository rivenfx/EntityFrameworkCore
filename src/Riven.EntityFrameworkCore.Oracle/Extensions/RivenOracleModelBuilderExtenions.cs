using Microsoft.EntityFrameworkCore.Metadata;

using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.EntityFrameworkCore.Extensions
{
    public static class RivenOracleModelBuilderExtenions
    {
        /// <summary>
        /// 表映射到Oracle, 表名/列名 大写
        /// </summary>
        /// <param name="modelBuilder">modelBuilder</param>
        /// <param name="verifyingEntityType">验证实体类型是否需要处理</param>
        /// <returns>modelBuilder</returns>
        public static ModelBuilder TableMappingToOracle(this ModelBuilder modelBuilder,
            Func<IMutableEntityType, bool> verifyingEntityType)
        {
            return modelBuilder.TableMappingTo(verifyingEntityType, (s) => s.ToUpper());
        }
    }
}
