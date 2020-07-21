using LearnTests.Domain.Interfaces.Repositories;
using LearnTests.Infra.Data.Repositories;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class DependencyResolver
    {
        public static IServiceCollection ResolveInfraDependecy(this IServiceCollection services)        
            => services
                .ResolveRepositoryDependecy();

        private static IServiceCollection ResolveRepositoryDependecy(this IServiceCollection services)
            => services.AddScoped<ICustomerRepository, CustomerRepository>(); 
    }
}
