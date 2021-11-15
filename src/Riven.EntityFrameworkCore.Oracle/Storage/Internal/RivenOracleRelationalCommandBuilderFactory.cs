using JetBrains.Annotations;

using Oracle.EntityFrameworkCore.Storage.Internal;

namespace Microsoft.EntityFrameworkCore.Storage.Internal
{
    [System.Diagnostics.CodeAnalysis.SuppressMessage("Usage", "EF1001:Internal EF Core API usage.", Justification = "<挂起>")]
    public class RivenOracleRelationalCommandBuilderFactory : OracleRelationalCommandBuilderFactory
    {
        public RivenOracleRelationalCommandBuilderFactory([NotNull] RelationalCommandBuilderDependencies dependencies)
            : base(dependencies)
        {
        }

        public override IRelationalCommandBuilder Create()
        {
            var instance = base.Create();
            return RivenOracleRelationalCommandBuilderProxy.Create(instance);
        }
    }
}
