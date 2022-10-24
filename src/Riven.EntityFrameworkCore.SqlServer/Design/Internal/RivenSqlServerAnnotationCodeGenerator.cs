
// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.
// See the LICENSE file in the project root for more information.

using System.Linq;
using JetBrains.Annotations;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore.Design;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.SqlServer.Design.Internal;

namespace Microsoft.EntityFrameworkCore.Design.Internal
{

    public class RivenSqlServerAnnotationCodeGenerator : SqlServerAnnotationCodeGenerator
    {
        public RivenSqlServerAnnotationCodeGenerator([NotNull] AnnotationCodeGeneratorDependencies dependencies)
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

                    res[index] = new MethodCallCodeFragment($"{item.Method}SqlServer", item.Arguments?.ToArray());
                }
                else
                {

                    res[index] = new MethodCallCodeFragment($"{item.Method}SqlServer", item.Arguments?.ToArray(), item.ChainedCall);
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

                    res[index] = new MethodCallCodeFragment($"{item.Method}SqlServer", item.Arguments?.ToArray());
                }
                else
                {

                    res[index] = new MethodCallCodeFragment($"{item.Method}SqlServer", item.Arguments?.ToArray(), item.ChainedCall);
                }
            }

            return res;
        }
#endif
    }
}

