using DynamicFormBuilder.Domain.Base;
namespace DynamicFormBuilder.Application.DTO.Base
{
    public abstract class AEntityDto<TKey> : AEntity<TKey>, IEntity where TKey : struct
    {
        [System.Text.Json.Serialization.JsonIgnore]
        object IEntity.Id { get { return Id; } set { Id = (TKey)Convert.ChangeType(value, typeof(TKey)); } }
    }


    public abstract class AAuditableEntityDto<TKey> : AAuditableEntity<TKey>, IAuditableEntity<TKey>, IEntity<TKey> where TKey : struct
    {
        [System.Text.Json.Serialization.JsonIgnore]
        object IEntity.Id { get { return Id; } set { Id = (TKey)Convert.ChangeType(value, typeof(TKey)); } }
    }
}
