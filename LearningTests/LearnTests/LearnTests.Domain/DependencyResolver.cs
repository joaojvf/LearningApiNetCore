using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class DependencyResolver
    {
        public static IServiceCollection ResolveDomainDependecy(this IServiceCollection services)
            => services;
    }
}
