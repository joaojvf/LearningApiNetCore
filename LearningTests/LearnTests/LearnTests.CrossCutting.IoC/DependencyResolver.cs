using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class DependencyResolver
    {
        public static IServiceCollection ResolveIoCDependecy(this IServiceCollection services)
            => services
                .ResolveInfraDependecy()
                .ResolveDomainDependecy();
    }
}
