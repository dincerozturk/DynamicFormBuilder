using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DynamicFormBuilder.Domain.Base
{
    public interface IEntityBase
    {
    }
    public interface IEntity : IEntityBase
    {
        object Id { get; set; }
    }
    public interface IEntity<TKey> : IEntity
    {
        TKey Id { get; set; }
    }
    public interface ICreateDate
    {
        DateTime? CreatedDate { get; set; }
    }
    public interface ICreatedById
    {
        int? CreatedById { get; set; }
    }
    public interface IUpdatedDate
    {
        DateTime? UpdatedDate { get; set; }
    }
    public interface IUpdatedById
    {
        int? UpdatedById { get; set; }
    }

    public interface ISoftDelete
    {
        bool IsDeleted { get; set; }
    }
    public interface ICreateAuditableEntity : ICreateDate, ICreatedById
    {
    }
    public interface IUpdateAuditableEntity : IUpdatedDate, IUpdatedById
    {
    }
    public interface IDeleteAuditableEntity : IUpdateAuditableEntity, ISoftDelete
    {
    }
    public interface IAuditableEntity : ICreateAuditableEntity, IDeleteAuditableEntity, IEntity
    {
    }
    public interface IAuditableEntity<TKey> : IAuditableEntity, IEntity<TKey>
    {
    }

    public abstract class AEntity<TKey> : IEntity<TKey> where TKey : struct
    {
        object IEntity.Id { get { return Id; } set { Id = (TKey)Convert.ChangeType(value, typeof(TKey)); } }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column(Order = 1)]
        public virtual TKey Id { get; set; }
    }

    public abstract class AAuditableEntity<TKey> : AEntity<TKey>, IAuditableEntity<TKey>, IEntity<TKey> where TKey : struct
    {
        [Column(Order = 2)]
        public DateTime? CreatedDate { get; set; }

        [Column(Order = 3)]
        public int? CreatedById { get; set; }

        [Column(Order = 4)]
        public DateTime? UpdatedDate { get; set; }

        [Column(Order = 5)]
        public int? UpdatedById { get; set; }

        [Column(Order = 6)]
        public bool IsDeleted { get; set; }
    }
}
