using JetBrains.Annotations;

using Oracle.EntityFrameworkCore.Storage.Internal;

using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.EntityFrameworkCore.Storage.Internal
{
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Usage", "EF1001:Internal EF Core API usage.",
        Justification = "<挂起>")]
    public class RivenOracleSqlGenerationHelper : OracleSqlGenerationHelper
    {
        static Dictionary<string, string> _identifierMap = new Dictionary<string, string>();


        public RivenOracleSqlGenerationHelper([NotNull] RelationalSqlGenerationHelperDependencies dependencies) :
            base(dependencies)
        {
        }

        public override string EscapeIdentifier(string identifier)
        {
            if (identifier.Length > 30)
            {
                if (identifier.StartsWith("PK_")
                    || identifier.StartsWith("FK_")
                    || identifier.StartsWith("IX_"))
                {
                    if (!_identifierMap.TryGetValue(identifier, out string newIdentifier))
                    {
                        var start = identifier.Substring(0, 3);
                        var end = GenerateMD5(identifier).Substring(0, 27);
                        newIdentifier = $"{start}{end}";
                        _identifierMap.Add(identifier, newIdentifier);
                    }

                    identifier = newIdentifier;
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine($"命名超出最大长度(30): {identifier}   长度: {identifier.Length}");
                    Console.ResetColor();
                }
            }

            return base.EscapeIdentifier(
                identifier.ToUpper()
            );
        }

        public override void EscapeIdentifier(StringBuilder builder, string identifier)
        {
            base.EscapeIdentifier(
                builder,
                identifier.ToUpper()
            );
        }


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
