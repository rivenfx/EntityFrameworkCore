using JetBrains.Annotations;

using Oracle.EntityFrameworkCore.Storage.Internal;

namespace Microsoft.EntityFrameworkCore.Storage.Internal
{
    public class RivenOracleRelationalCommandBuilderFactory : OracleRelationalCommandBuilderFactory
    {
        public RivenOracleRelationalCommandBuilderFactory([NotNull] RelationalCommandBuilderDependencies dependencies)
            : base(dependencies)
        {
        }

        public override IRelationalCommandBuilder Create()
        {
            var instance = base.Create();
            return OracleRelationalCommandBuilderProxy.Create(instance);
        }
    }
}
