using Microsoft.EntityFrameworkCore;

namespace DynamicFormBuilder.Persistence.Context
{
    public class DynamicFormBuilderDbContextFactory : DesignTimeDbContextFactory<DynamicFormBuilderDbContext>
    {
        protected override DynamicFormBuilderDbContext CreateNewInstance(DbContextOptions<DynamicFormBuilderDbContext> options)
        {
            return new DynamicFormBuilderDbContext(options);
        }
    }
}
