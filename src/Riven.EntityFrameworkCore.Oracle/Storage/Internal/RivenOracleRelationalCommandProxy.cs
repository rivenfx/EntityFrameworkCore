using System.Reflection;

namespace Microsoft.EntityFrameworkCore.Storage.Internal
{
    /// <summary>
    /// IRelationalCommand 代理服务
    /// </summary>
    public class RivenOracleRelationalCommandProxy : DispatchProxy
    {
        IRelationalCommand _command;

        protected override object Invoke(MethodInfo targetMethod, object[] args)
        {
            var res = targetMethod.Invoke(this._command, args);
            return res;
        }


        public static IRelationalCommand Create(IRelationalCommand instance)
        {
            var obj = DispatchProxy.Create<IRelationalCommand, RivenOracleRelationalCommandProxy>();
            (obj as RivenOracleRelationalCommandProxy)._command = instance;

            return obj;
        }
    }
}
