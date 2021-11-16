using System;
using System.Collections.Generic;
using System.Text;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Microsoft.EntityFrameworkCore.Extensions
{
    public static class RivenModelBuilderExtenions
    {
        /// <summary>
        /// 表映射。表名/列名/主键/外键/索引 名称处理
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
                {
                    var tabaleName = entityBuilder.Metadata.GetTableName();
                    var annotation = entityBuilder.Metadata.GetAnnotation(RelationalAnnotationNames.TableName);
                    if (annotation != null)
                    {
                        tabaleName = annotation.Value.ToString();
                    }

                    entityBuilder.Metadata.SetTableName(
                        processString.Invoke(tabaleName)
                        );
                }

                // 列名处理
                {
                    var annotation = default(IAnnotation);
                    var columnName = string.Empty;
                    foreach (var property in entityType.GetProperties())
                    {
                        columnName = property.GetColumnBaseName();
                        annotation = property.FindAnnotation(RelationalAnnotationNames.ColumnName);
                        if (annotation != null)
                        {
                            columnName = annotation.Value.ToString();
                        }
                        property.SetColumnName(
                            processString.Invoke(columnName)
                        );
                    }
                }

                // 主键处理
                {
                    var keyName = string.Empty;
                    var keys = entityBuilder.Metadata.GetKeys();
                    foreach (var key in keys)
                    {
                        keyName = key.GetName();
                        if (string.IsNullOrEmpty(keyName))
                        {
                            keyName = key.GetDefaultName();
                        }
                        keyName = processString.Invoke(keyName);
                        key.SetName(keyName);
                    }
                }

                // 外键处理
                {
                    var keyName = string.Empty;
                    var keys = entityBuilder.Metadata.GetForeignKeys();
                    foreach (var key in keys)
                    {
                        keyName = key.GetConstraintName();
                        if (string.IsNullOrEmpty(keyName))
                        {
                            keyName = key.GetDefaultName();
                        }
                        keyName = processString.Invoke(keyName);
                        key.SetConstraintName(keyName);
                    }
                }

                // 索引处理
                {
                    var keyName = string.Empty;
                    var keys = entityBuilder.Metadata.GetIndexes();
                    foreach (var key in keys)
                    {
                        keyName = key.GetDatabaseName();
                        if (string.IsNullOrEmpty(keyName))
                        {
                            keyName = key.GetDefaultDatabaseName();
                        }
                        keyName = processString.Invoke(keyName);
                        key.SetDatabaseName(keyName);
                    }
                }
            }

            return modelBuilder;
        }

    }
}
