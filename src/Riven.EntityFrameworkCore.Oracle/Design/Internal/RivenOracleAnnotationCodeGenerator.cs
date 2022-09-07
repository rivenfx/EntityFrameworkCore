using Oracle.EntityFrameworkCore.Design.Internal;
using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Infrastructure;
using System.Collections.Generic;
using System.Linq;

namespace Microsoft.EntityFrameworkCore.Design.Internal
{
    public class RivenOracleAnnotationCodeGenerator : OracleAnnotationCodeGenerator
    {
        public RivenOracleAnnotationCodeGenerator([NotNull] AnnotationCodeGeneratorDependencies dependencies)
            : base(dependencies)
        {
        }

#if NETSTANDARD2_1
        public override IReadOnlyList<MethodCallCodeFragment> GenerateFluentApiCalls(IModel model, IDictionary<string, IAnnotation> annotations)
        {
            //return base.GenerateFluentApiCalls(model, annotations);

            var res = base.GenerateFluentApiCalls(model, annotations).ToList();

            var identitys = res
                .Where(o => o.Method == "UseIdentityColumns" || o.Method == "UseIdentityColumn")
                .ToList();

            foreach (var item in identitys)
            {
                var index = res.FindIndex(o => o == item);
                if (item.ChainedCall == null)
                {

                    res[index] = new MethodCallCodeFragment($"{item.Method}Oracle", item.Arguments?.ToArray());
                }
                else
                {

                    res[index] = new MethodCallCodeFragment($"{item.Method}Oracle", item.Arguments?.ToArray(), item.ChainedCall);
                }
            }

            return res;
        }


        public override IReadOnlyList<MethodCallCodeFragment> GenerateFluentApiCalls(IProperty property, IDictionary<string, IAnnotation> annotations)
        {
            var res = base.GenerateFluentApiCalls(property, annotations).ToList();

            var identitys = res
                .Where(o => o.Method == "UseIdentityColumns" || o.Method == "UseIdentityColumn")
                .ToList();

            foreach (var item in identitys)
            {
                var index = res.FindIndex(o => o == item);
                if (item.ChainedCall == null)
                {

                    res[index] = new MethodCallCodeFragment($"{item.Method}Oracle", item.Arguments?.ToArray());
                }
                else
                {

                    res[index] = new MethodCallCodeFragment($"{item.Method}Oracle", item.Arguments?.ToArray(), item.ChainedCall);
                }
            }

            return res;
        }
#elif NET5_0
        public override IReadOnlyList<MethodCallCodeFragment> GenerateFluentApiCalls(IModel model, IDictionary<string, IAnnotation> annotations)
        {
            //return base.GenerateFluentApiCalls(model, annotations);

            var res = base.GenerateFluentApiCalls(model, annotations).ToList();

            var identitys = res
                .Where(o => o.Method == "UseIdentityColumns" || o.Method == "UseIdentityColumn")
                .ToList();

            foreach (var item in identitys)
            {
                var index = res.FindIndex(o => o == item);
                if (item.ChainedCall == null)
                {

                    res[index] = new MethodCallCodeFragment($"{item.Method}Oracle", item.Arguments?.ToArray());
                }
                else
                {

                    res[index] = new MethodCallCodeFragment($"{item.Method}Oracle", item.Arguments?.ToArray(), item.ChainedCall);
                }
            }

            return res;
        }


        public override IReadOnlyList<MethodCallCodeFragment> GenerateFluentApiCalls(IProperty property, IDictionary<string, IAnnotation> annotations)
        {
            var res = base.GenerateFluentApiCalls(property, annotations).ToList();

            var identitys = res
                .Where(o => o.Method == "UseIdentityColumns" || o.Method == "UseIdentityColumn")
                .ToList();

            foreach (var item in identitys)
            {
                var index = res.FindIndex(o => o == item);
                if (item.ChainedCall == null)
                {

                    res[index] = new MethodCallCodeFragment($"{item.Method}Oracle", item.Arguments?.ToArray());
                }
                else
                {

                    res[index] = new MethodCallCodeFragment($"{item.Method}Oracle", item.Arguments?.ToArray(), item.ChainedCall);
                }
            }

            return res;
        }
#endif
    }
}
