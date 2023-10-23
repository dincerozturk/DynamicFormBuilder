using DynamicFormBuilder.Domain.Base;

namespace DynamicFormBuilder.Domain.Entities
{
    public class FieldData : AAuditableEntity<int>
    {
        public int FieldSpecId { get; set; }
        public FieldSpec FieldSpec { get; set; }
        public string Name { get; set; }
        public string DisplatName { get; set; }
        public string Value { get; set; }
    }
}
