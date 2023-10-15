using System.ComponentModel.DataAnnotations;

namespace DynamicFormBuilder.Domain.Entities
{
    public class FieldSpec
    {
        [Key]
        public int Id { get; set; }
        public int FormSpecId { get; set; }
        public FormSpec FormSpec { get; set; }
        public string Label { get; set; }
        public string InputName { get; set; }
        public int InputTypeId { get; set; }
        public InputType InputType { get; set; }
        public string Caption { get; set; }
        public int Order { get; set; }
        public string PlaceHolder { get; set; }
        public bool Visible { get; set; }
        public bool Enable { get; set; }


        public IEnumerable<FieldData> FieldDatas { get; set; }
    }
    public class FieldSpec<TValue> : FieldSpec
    {
        public TValue OutputValue { get; set; }
    }
}
