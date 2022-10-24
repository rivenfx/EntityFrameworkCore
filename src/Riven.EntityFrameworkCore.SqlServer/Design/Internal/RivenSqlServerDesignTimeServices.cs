using Microsoft.Extensions.DependencyInjection;

using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.EntityFrameworkCore.Design.Internal
{
    public class RivenSqlServerDesignTimeServices : IDesignTimeServices
    {
        public virtual void ConfigureDesignTimeServices(IServiceCollection serviceCollection)
        {
            serviceCollection.AddSingleton<IAnnotationCodeGenerator, RivenSqlServerAnnotationCodeGenerator>();
        }
    }
}
