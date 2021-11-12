using System.Reflection;

namespace Microsoft.EntityFrameworkCore.Storage.Internal
{
    public class OracleRelationalCommandBuilderProxy : DispatchProxy
    {
        IRelationalCommandBuilder _builder;

        protected override object Invoke(MethodInfo targetMethod, object[] args)
        {
            if (targetMethod.Name == "Append" && args != null && args.Length == 1 && args[0] != null)
            {
                var val = args[0].ToString().Trim();
                if (val.Contains("\""))
                {
                    args[0] = val.Replace("\"", string.Empty);
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
