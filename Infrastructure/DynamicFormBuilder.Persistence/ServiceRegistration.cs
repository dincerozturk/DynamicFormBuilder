using DynamicFormBuilder.Application.Abstraction.Context;
using DynamicFormBuilder.Application.Abstraction.UnitOfWork;
using DynamicFormBuilder.Persistence.Context;
using DynamicFormBuilder.Persistence.UnitOfWork;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DynamicFormBuilder.Persistence
{
    public static class ServiceRegistration
    {
        public static void AddPersistenceServices(this IServiceCollection serviceCollection, IConfiguration configuration)
        {
            var connection = configuration.GetConnectionString("DynamicFormBuilderConnection");
            serviceCollection.AddDbContext<DynamicFormBuilderDbContext>(options =>
            {
                options.UseSqlServer(connection);
                options.EnableSensitiveDataLogging();
            });
            serviceCollection.AddScoped<DbContext, DynamicFormBuilderDbContext>();
            serviceCollection.AddScoped<IDynamicFormBuilderDbContext, DynamicFormBuilderDbContext>();
            serviceCollection.AddScoped(typeof(IUnitOfWork), typeof(UnitOfWork<DynamicFormBuilderDbContext>));

            
        }
    }
}
