using DynamicFormBuilder.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace DynamicFormBuilder.Application.Abstraction.Context
{
    public interface IDynamicFormBuilderDbContext
    {
        DbSet<ElementType> InputTypes { get; set; }
        DbSet<FormSpec> FormSpec { get; set; }
        DbSet<FormSubmission> FormSubmissions { get; set; }
        DbSet<FieldSpec> FieldSpecs { get; set; }
        DbSet<FieldData> FieldDatas { get; set; }
    }
}
