using JetBrains.Annotations;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;

namespace Microsoft.EntityFrameworkCore.Storage.Internal
{

    [System.Diagnostics.CodeAnalysis.SuppressMessage("Usage", "EF1001:Internal EF Core API usage.", Justification = "<挂起>")]
    public class RivenDevartOracleSqlGenerationHelper: RelationalSqlGenerationHelper
    {
        public RivenDevartOracleSqlGenerationHelper([NotNull] RelationalSqlGenerationHelperDependencies dependencies)
            : base(dependencies)
        {
        }

        public override string EscapeIdentifier(string identifier)
        {
            return base.EscapeIdentifier(identifier).ToUpperInvariant();
        }

        public override void EscapeIdentifier(StringBuilder builder, string identifier)
        {
            base.EscapeIdentifier(builder, identifier.ToUpperInvariant());
        }

        //private ISqlGenerationHelper GetInstance()
        //{

        //}
    }
}
