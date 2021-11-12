using JetBrains.Annotations;

using Oracle.EntityFrameworkCore.Storage.Internal;

using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.EntityFrameworkCore.Storage.Internal
{
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Usage", "EF1001:Internal EF Core API usage.", Justification = "<挂起>")]
    public class RivenOracleSqlGenerationHelper : OracleSqlGenerationHelper
    {
        public RivenOracleSqlGenerationHelper([NotNull] RelationalSqlGenerationHelperDependencies dependencies) : base(dependencies)
        {
        }

        public override string DelimitIdentifier(string identifier)
        {
            return EscapeIdentifier(identifier);
        }

        public override void DelimitIdentifier(StringBuilder builder, string identifier)
        {
            //builder.Append('"');
            EscapeIdentifier(builder, identifier);
            //builder.Append('"');
        }
    }
}
