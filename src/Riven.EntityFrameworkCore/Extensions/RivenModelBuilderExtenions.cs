using System;
using System.Collections.Generic;
using System.Text;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Microsoft.EntityFrameworkCore.Extensions
{
    public static class RivenModelBuilderExtenions
    {
        /// <summary>
        /// 表映射,表名，列名处理
        /// </summary>
        /// <param name="modelBuilder">modelBuilder</param>
        /// <param name="verifyingEntityType">验证实体类型是否需要处理</param>
        /// <param name="processString">处理表名/列名的实现</param>
        /// <returns>modelBuilder</returns>
        public static ModelBuilder TableMappingTo(this ModelBuilder modelBuilder,
            Func<IMutableEntityType, bool> verifyingEntityType,
            Func<string, string> processString)
        {
            if (modelBuilder == null)
            {
                throw new ArgumentNullException(nameof(modelBuilder));
            }

            if (verifyingEntityType == null)
            {
                throw new ArgumentNullException(nameof(verifyingEntityType));
            }

            if (processString == null)
            {
                throw new ArgumentNullException(nameof(processString));
            }


            var model = modelBuilder.Model;
            foreach (var entityType in model.GetEntityTypes())
            {
                // 校验
                if (!verifyingEntityType(entityType))
                {
                    continue;
                }

                var entityBuilder = modelBuilder.Entity(entityType.ClrType);

                // 表名处理
                var tabaleName = entityBuilder.Metadata.GetTableName();
                var annotation = entityBuilder.Metadata.GetAnnotation(RelationalAnnotationNames.TableName);
                if (annotation != null)
                {
                    tabaleName = annotation.Value.ToString();
                    entityBuilder.Metadata.RemoveAnnotation(RelationalAnnotationNames.TableName);
                }
                entityBuilder.Metadata.AddAnnotation(
                        RelationalAnnotationNames.TableName,
                        processString.Invoke(tabaleName)
                        );

                // 列名处理
                var columnName = string.Empty;
                foreach (var property in entityType.GetProperties())
                {
                    columnName = property.GetColumnBaseName();
                    annotation = property.FindAnnotation(RelationalAnnotationNames.ColumnName);
                    if (annotation != null)
                    {
                        columnName = annotation.Value.ToString();
                        property.RemoveAnnotation(RelationalAnnotationNames.ColumnName);
                    }
                    property.AddAnnotation(
                           RelationalAnnotationNames.ColumnName,
                           processString.Invoke(columnName)
                           );
                }
            }

            return modelBuilder;
        }
    }
}
