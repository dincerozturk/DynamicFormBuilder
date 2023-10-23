using DynamicFormBuilder.Application.DTO.Base;

namespace DynamicFormBuilder.Application.DTO
{
    public interface IFieldSpec
    {
        string Value { get; set; }

        /// <summary>
        /// ElementType Enum değerlerini alır
        /// </summary>
        byte ElementTypeId { get; set; }

        /// <summary>
        /// ElementType Input ise dolar, Input Element Type Enum değerlerini alır
        /// </summary>
        byte? ElementInputTypeId { get; set; }
    }
    //public interface IFieldSpec<TValue> : IFieldSpec
    //{
    //    TValue Value { get; set; }
    //}


    //public abstract class AFieldSpecDTO<TValue> : AAuditableEntityDto<int>, IFieldSpec<TValue>
    //{
    //    object IFieldSpec.Value { get { return Value; } set { Value = (TValue)Convert.ChangeType(value, typeof(TValue)); } }
    //    public virtual TValue Value { get; set; }

    //    /// <summary>
    //    /// ElementType Enum değerlerini alır
    //    /// </summary>
    //    public byte ElementTypeId { get; set; }

    //    /// <summary>
    //    /// ElementType Input ise dolar, Input Element Type Enum değerlerini alır
    //    /// </summary>
    //    public byte? ElementInputTypeId { get; set; }        
    //}

    public class FieldSpecDTO : AAuditableEntityDto<int>, IFieldSpec
    {
        public string Value { get; set; }
        public byte ElementTypeId { get; set; }
        public byte? ElementInputTypeId { get; set; }

        public int FormSpecId { get; set; }
        public FormSpecDTO FormSpec { get; set; }

        public string Label { get; set; }
        public string InputName { get; set; }

        public string Caption { get; set; }
        public int Order { get; set; }

        public Dictionary<string, object> AdditionalAttribute { get; set; }
        public IEnumerable<FieldDataDTO> FieldDatas { get; set; }
        
    }
    public class FieldSpecDTO<TValue> : FieldSpecDTO, IFieldSpec
    {
        public FieldSpecDTO(TValue value)
        {
                Value = value;
        }
        public TValue Value { get; set; }
    }
}
