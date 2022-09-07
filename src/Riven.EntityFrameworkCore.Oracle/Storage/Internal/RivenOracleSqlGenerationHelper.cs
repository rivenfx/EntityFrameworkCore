using JetBrains.Annotations;

using Microsoft.EntityFrameworkCore.Extensions;

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
            return base.EscapeIdentifier(
                RivenOracleDbContextModelBuilderExtensions.GenNewIdentifier(identifier)
            );
        }

        public override void EscapeIdentifier(StringBuilder builder, string identifier)
        {
            base.EscapeIdentifier(
                builder,
                identifier
            );
        }
    }
}
