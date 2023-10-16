using DynamicFormBuilder.Application.Abstraction.Context;
using DynamicFormBuilder.Domain.Entities;
using DynamicFormBuilder.Domain.Entities.Base;
using DynamicFormBuilder.Persistence.Extensions;
using Microsoft.EntityFrameworkCore;

namespace DynamicFormBuilder.Persistence.Context
{
    public class DynamicFormBuilderDbContext : DbContext, IDynamicFormBuilderDbContext
    {
        public DynamicFormBuilderDbContext(DbContextOptions<DynamicFormBuilderDbContext> options) : base(options)
        {

        }

        public DbSet<ElementType> InputTypes { get; set; }
        public DbSet<FormSpec> FormSpec { get; set; }
        public DbSet<FormSubmission> FormSubmissions { get; set; }
        public DbSet<FieldSpec> FieldSpecs { get; set; }
        public DbSet<FieldData> FieldDatas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // for the other conventions, we do a metadata model loop
            foreach (var entityType in modelBuilder.Model.GetEntityTypes())
            {
                // equivalent of modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
                entityType.SetTableName(entityType.DisplayName());

                // equivalent of modelBuilder.Conventions.Remove<OneToManyCascadeDeleteConvention>();
                entityType.GetForeignKeys()
                    .Where(fk => !fk.IsOwnership && fk.DeleteBehavior == DeleteBehavior.Cascade)
                    .ToList()
                    .ForEach(fk => fk.DeleteBehavior = DeleteBehavior.NoAction);
            }

            modelBuilder.ApplySoftDeleteQueryFilter("IsDeleted");

            #region AutoIncrements
            modelBuilder.HasSequence<int>("DynamicFormBuilderSequence").StartsAt(1).IncrementsBy(1);
            #endregion

            base.OnModelCreating(modelBuilder);
            new DbInitializer(modelBuilder).Seed();
        }
    }
}

public class DbInitializer
{
    private readonly ModelBuilder modelBuilder;

    public DbInitializer(ModelBuilder modelBuilder)
    {
        this.modelBuilder = modelBuilder;
    }

    public void Seed()
    {
        modelBuilder.Entity<ElementType>().HasData(
         new ElementType()
         {
             Id = 1,
             Name = "input",
             Description = "input",
             IsDeleted = false,
         }, new ElementType()
         {
             Id = 2,
             Name = "select",
             Description = "select",
             IsDeleted = false, 
         }, new ElementType()
         {
             Id = 3,
             Name = "textarea",
             Description = "textarea",
             IsDeleted = false,
         }, new ElementType()
         {
             Id = 4,
             Name = "button",
             Description = "button",
             IsDeleted = false,
         }, new ElementType()
         {
             Id = 5,
             Name = "option",
             Description = "option",
             IsDeleted = false,
         }, new ElementType()
         {
             Id = 6,
             Name = "optgroup",
             Description = "optgroup",
             IsDeleted = false,
         }, new ElementType()
         {
             Id = 7,
             Name = "label",
             Description = "label",
             IsDeleted = false,
         }, new ElementType()
         {
             Id = 8,
             Name = "fieldset",
             Description = "fieldset",
             IsDeleted = false,
         }, new ElementType()
         {
             Id = 9,
             Name = "datalist",
             Description = "datalist",
             IsDeleted = false,
         }, new ElementType()
         {
             Id = 10,
             Name = "legend",
             Description = "legend",
             IsDeleted = false,
         }, new ElementType()
         {
             Id = 11,
             Name = "output",
             Description = "output",
             IsDeleted = false,
         }
         );
    }
}