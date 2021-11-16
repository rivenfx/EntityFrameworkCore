using Microsoft.EntityFrameworkCore.Metadata;

using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.EntityFrameworkCore.Extensions
{
    public static class RivenDevartOracleModelBuilderExtenions
    {
        public static readonly Dictionary<string, string> IdentifierMap = new Dictionary<string, string>();

        /// <summary>
        /// 表映射到 Devart Oracle。表名/列名/主键/外键/索引 全大写
        /// </summary>
        /// <param name="modelBuilder">modelBuilder</param>
        /// <param name="verifyingEntityType">验证实体类型是否需要处理</param>
        /// <returns>modelBuilder</returns>
        public static ModelBuilder TableMappingToDevartOracle(this ModelBuilder modelBuilder,
            Func<IMutableEntityType, bool> verifyingEntityType)
        {
            return modelBuilder.TableMappingTo(verifyingEntityType, (s) =>
            {
                var identifier = GenNewIdentifier(s).ToUpper();

                if (identifier.Length > 30)
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine($"[ORA-00972:标识符过长] 命名超出最大长度(30) : {identifier} ({identifier.Length})");
                    Console.ResetColor();
                }

                return identifier;
            });
        }

        /// <summary>
        /// 表映射到 Devart Oracle。表名/列名/主键/外键/索引 全大写
        /// </summary>
        /// <param name="modelBuilder">modelBuilder</param>
        /// <returns>modelBuilder</returns>
        public static ModelBuilder TableMappingToDevartOracle(this ModelBuilder modelBuilder)
        {
            return modelBuilder.TableMappingToDevartOracle((e) => true);
        }

        /// <summary>
        /// 处理并生成新的 identifier
        /// </summary>
        /// <param name="identifier"></param>
        /// <returns></returns>
        public static string GenNewIdentifier(string identifier)
        {
            if (identifier.Length > 30)
            {
                // 主外键、索引超长
                if (identifier.StartsWith("PK_")
                    || identifier.StartsWith("FK_")
                    || identifier.StartsWith("IX_"))
                {
                    if (!IdentifierMap.TryGetValue(identifier, out string newIdentifier))
                    {
                        var start = identifier.Substring(0, 3);
                        var end = GenerateMD5(identifier).Substring(0, 27);
                        newIdentifier = $"{start}{end}";
                        IdentifierMap.Add(identifier, newIdentifier);
                    }

                    return newIdentifier.ToUpper();
                }
            }

            return identifier;
        }

        /// <summary>
        /// 字符串MD5
        /// </summary>
        /// <param name="txt"></param>
        /// <returns></returns>
        public static string GenerateMD5(string txt)
        {
            using (var mi = System.Security.Cryptography.MD5.Create())
            {
                byte[] buffer = Encoding.Default.GetBytes(txt);
                //开始加密
                byte[] newBuffer = mi.ComputeHash(buffer);
                StringBuilder sb = new StringBuilder();
                for (int i = 0; i < newBuffer.Length; i++)
                {
                    sb.Append(newBuffer[i].ToString("x2"));
                }

                return sb.ToString();
            }
        }
    }
}
