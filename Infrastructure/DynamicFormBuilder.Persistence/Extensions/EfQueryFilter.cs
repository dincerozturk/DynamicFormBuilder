using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace DynamicFormBuilder.Persistence.Extensions
{
    public static class QueryFilterExtensions
    {
        public static void ApplySoftDeleteQueryFilter(this ModelBuilder modelBuilder, string propertyName)
        {
            var entityTypes = modelBuilder.Model
            .GetEntityTypes();

            foreach (var entityType in entityTypes)
            {
                var isActiveProperty = entityType.FindProperty(propertyName);
                if (isActiveProperty != null && isActiveProperty.ClrType == typeof(bool))
                {
                    var entityBuilder = modelBuilder.Entity(entityType.ClrType);
                    var parameter = Expression.Parameter(entityType.ClrType, "e");
                    var methodInfo = typeof(EF).GetMethod(nameof(EF.Property))!.MakeGenericMethod(typeof(bool))!;
                    var efPropertyCall = Expression.Call(null, methodInfo, parameter, Expression.Constant(propertyName));
                    var body = Expression.MakeBinary(ExpressionType.NotEqual, efPropertyCall, Expression.Constant(true));
                    var expression = Expression.Lambda(body, parameter);
                    entityBuilder.HasQueryFilter(expression);
                }
            }
        }
    }
}
