using JetBrains.Annotations;

using Npgsql.EntityFrameworkCore.PostgreSQL.Storage.Internal;

using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.EntityFrameworkCore.Storage.Internal
{
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Usage", "EF1001:Internal EF Core API usage.", Justification = "<挂起>")]
    public class RivenPostgreSqlGenerationHelper : NpgsqlSqlGenerationHelper
    {
        public RivenPostgreSqlGenerationHelper([NotNull] RelationalSqlGenerationHelperDependencies dependencies)
            : base(dependencies)
        {
        }

        public override string EscapeIdentifier(string identifier)
        {
            return base.EscapeIdentifier(
                identifier.ToLower()
                );
        }

        public override void EscapeIdentifier(StringBuilder builder, string identifier)
        {
            base.EscapeIdentifier(
                builder,
                identifier.ToLower()
                );
        }
    }
}
