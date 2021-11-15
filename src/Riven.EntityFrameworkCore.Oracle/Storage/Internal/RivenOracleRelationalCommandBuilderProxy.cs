
using System;
using System.Reflection;
using System.Text.RegularExpressions;

namespace Microsoft.EntityFrameworkCore.Storage.Internal
{
    /// <summary>
    /// IRelationalCommandBuilder 代理
    /// </summary>
    public class RivenOracleRelationalCommandBuilderProxy : DispatchProxy
    {

        public const string BUILDE_METHOD = nameof(IRelationalCommandBuilder.Build);

        public const string APPEND_METHOD = nameof(IRelationalCommandBuilder.Append);

        public static readonly Type RETURN_TYPE = typeof(IRelationalCommandBuilder);

        IRelationalCommandBuilder _builder;


        protected override object Invoke(MethodInfo targetMethod, object[] args)
        {
            //// 生成 command
            //if (targetMethod.Name == BUILDE_METHOD)
            //{
            //    var commandInstance = targetMethod.Invoke(this._builder, args);
            //    return RivenOracleRelationalCommandProxy.Create(commandInstance as IRelationalCommand);
            //}

            // 添加 commandtext 的一部分
            if (targetMethod.Name == APPEND_METHOD
                && args != null
                && args.Length == 1
                && args[0] != null
                && args[0] is string)
            {
                var inputVal = args[0].ToString();
                //var matchCollection = Regex.Matches(inputVal, ":new.\".*? \"");
                var matchCollection = Regex.Matches(inputVal, "\".*? \"");
                if (matchCollection.Count > 0)
                {
                    foreach (Match match in matchCollection)
                    {
                        inputVal = inputVal.Replace(match.Value, match.Value.ToUpper());
                    }
                }
                args[0] = inputVal;
            }

            // 执行原有实现 
            var res = targetMethod.Invoke(this._builder, args);
            // 如果当前aop的方法返回类型不为 IRelationalCommandBuilder，那么执行结果
            if (targetMethod.ReturnType != RETURN_TYPE)
            {
                return res;
            }

            // 返回代理
            return this;
        }


        /// <summary>
        /// 创建代理的 IRelationalCommandBuilder
        /// </summary>
        /// <param name="instance"></param>
        /// <returns></returns>
        public static IRelationalCommandBuilder Create(IRelationalCommandBuilder instance)
        {
            var obj = DispatchProxy.Create<IRelationalCommandBuilder, RivenOracleRelationalCommandBuilderProxy>();
            (obj as RivenOracleRelationalCommandBuilderProxy)._builder = instance;

            return obj;
        }
    }
}
