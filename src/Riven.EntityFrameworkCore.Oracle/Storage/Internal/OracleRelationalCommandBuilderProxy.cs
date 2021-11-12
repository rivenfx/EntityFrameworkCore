using System.Reflection;

namespace Microsoft.EntityFrameworkCore.Storage.Internal
{
    public class OracleRelationalCommandBuilderProxy : DispatchProxy
    {
        const string _doubleQuotation = "\"";
        const string _methodName = nameof(IRelationalCommandBuilder.Append);

        IRelationalCommandBuilder _builder;

        protected override object Invoke(MethodInfo targetMethod, object[] args)
        {
            if (targetMethod.Name == _methodName
                && args != null
                && args.Length == 1
                && args[0] != null
                && args[0] is string)
            {
                var val = args[0].ToString().Trim();
                if (val.Contains(_doubleQuotation))
                {
                    args[0] = val.Replace(_doubleQuotation, string.Empty);
                }
            }

            return targetMethod.Invoke(this._builder, args);
        }


        public static IRelationalCommandBuilder Create(IRelationalCommandBuilder instance)
        {
            var obj = DispatchProxy.Create<IRelationalCommandBuilder, OracleRelationalCommandBuilderProxy>();
            (obj as OracleRelationalCommandBuilderProxy)._builder = instance;

            return obj;
        }
    }
}
