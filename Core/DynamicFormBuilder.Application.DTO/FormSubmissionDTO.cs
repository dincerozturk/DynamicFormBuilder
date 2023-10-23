using DynamicFormBuilder.Application.DTO.Base;

namespace DynamicFormBuilder.Application.DTO
{
    public class FormSubmissionDTO : AAuditableEntityDto<int>
    {
        public int FormSpecId { get; set; }
        public FormSpecDTO FormSpec { get; set; }

        /// <summary>
        /// payload olarak FieldSpecId ve kullanıcı tarafından girilen değerlerin dictionary olarak tutulduğu alan
        /// </summary>
        public Dictionary<int, string> Payload { get; set; }
    }
}
