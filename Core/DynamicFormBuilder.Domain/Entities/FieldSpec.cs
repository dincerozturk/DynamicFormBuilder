using DynamicFormBuilder.Domain.Entities.Base;
using System.ComponentModel.DataAnnotations;

namespace DynamicFormBuilder.Domain.Entities
{
    public class FieldSpec : AAuditableEntity<int>
    {
        public int FormSpecId { get; set; }
        public FormSpec FormSpec { get; set; }

        public string Label { get; set; }
        public string InputName { get; set; }

        public byte ElementTypeId { get; set; }

        public string Caption { get; set; }
        public int Order { get; set; }
        public string PlaceHolder { get; set; }
        public bool Required { get; set; }
        public bool Visible { get; set; }
        public bool Enable { get; set; }

        public string ClassName { get; set; }
        public string Style { get; set; }

        public IEnumerable<FieldData> FieldDatas { get; set; }
    }
    public class FieldSpec<TValue> : FieldSpec
    {
        public TValue OutputValue { get; set; }
    }
}
