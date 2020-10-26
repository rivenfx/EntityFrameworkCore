using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.EntityFrameworkCore.Internal
{
    public class RivenDevartOracleServiceProviderCache : ServiceProviderCache
    {
        static RivenDevartOracleServiceProviderCache()
        {
            var serviceProvider = default(ServiceProvider);

            serviceProvider.GetService<ServiceProviderCache>();
        }
    }
}
