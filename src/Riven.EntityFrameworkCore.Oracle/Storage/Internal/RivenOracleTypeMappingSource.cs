using JetBrains.Annotations;

using Oracle.EntityFrameworkCore.Infrastructure.Internal;
using Oracle.EntityFrameworkCore.Storage.Internal;

namespace Microsoft.EntityFrameworkCore.Storage.Internal
{
    /// <summary>
    /// Oracle数据库字段类型映射器
    /// </summary>
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Usage", "EF1001:Internal EF Core API usage.", Justification = "<挂起>")]
    public class RivenOracleTypeMappingSource : OracleTypeMappingSource
    {
        public RivenOracleTypeMappingSource([NotNull] TypeMappingSourceDependencies dependencies, [NotNull] RelationalTypeMappingSourceDependencies relationalDependencies, [NotNull] IOracleOptions oracleOptions)
            : base(dependencies, relationalDependencies, oracleOptions)
        {
        }

        protected override RelationalTypeMapping FindMapping(in RelationalTypeMappingInfo mappingInfo)
        {
            var input = mappingInfo;

            if (mappingInfo.ClrType == typeof(string)
                && string.IsNullOrWhiteSpace(mappingInfo.StoreTypeName)
                )
            {
                // 是否要替换为clob
                var replaceToClob = false;
                // 字段长度
                var size = mappingInfo.Size;

                // 未指定长度 或 最大长度超过2000
                if (!mappingInfo.Size.HasValue
                    || mappingInfo.Size.Value > 2000)
                {
                    size = null;
                    replaceToClob = true;
                }

                // 替换类型为clob
                if (replaceToClob)
                {
                    var isUnicode = input.IsUnicode.HasValue ? input.IsUnicode.Value : true;
                    var storeTypeName = isUnicode ? "nclob" : "clob";

                    input = new RelationalTypeMappingInfo(
                        input.ClrType,
                        storeTypeName,
                        input.StoreTypeNameBase,
                        input.IsKeyOrIndex,
                        isUnicode,
                        size,
                        input.IsRowVersion,
                        input.IsFixedLength,
                        input.Precision,
                        input.Scale
                        );
                }
            }

            return base.FindMapping(input);
        }
    }
}
