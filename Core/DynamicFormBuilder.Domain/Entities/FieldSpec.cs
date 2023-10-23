using DynamicFormBuilder.Domain.Base;

namespace DynamicFormBuilder.Domain.Entities
{
    public class FieldSpec : AAuditableEntity<int>
    {
        public int FormSpecId { get; set; }
        public FormSpec FormSpec { get; set; }

        public string Label { get; set; }
        public string InputName { get; set; }

        /// <summary>
        /// ElementType Enum değerlerini alır
        /// </summary>
        public byte ElementTypeId { get; set; }

        /// <summary>
        /// ElementType Input ise dolar, Input Element Type Enum değerlerini alır
        /// </summary>
        public byte? ElementInputTypeId { get; set; }

        public string Caption { get; set; }
        public int Order { get; set; }

        public Dictionary<string, object> AdditionalAttribute { get; }
        public IEnumerable<FieldData> FieldDatas { get; set; }
    }
    public class FieldSpec<TValue> : FieldSpec
    {
        public TValue OutputValue { get; set; }
    }
}
