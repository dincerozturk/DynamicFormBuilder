using DynamicFormBuilder.Application.DTO.Base;

namespace DynamicFormBuilder.Application.DTO
{
    public class FieldDataDTO : AAuditableEntityDto<int>
    {
        public int FieldSpecId { get; set; }
        public FieldSpecDTO FieldSpec { get; set; }

        public string Name { get; set; }
        public string DisplayName { get; set; }
        public string Value { get; set; }
    }
}
