using DynamicFormBuilder.Domain.Base;

namespace DynamicFormBuilder.Domain.Entities
{
    public class FormSubmission : AAuditableEntity<int>
    {
        public int FormSpecId { get; set; }
        public FormSpec FormSpec { get; set; }

        /// <summary>
        /// payload olarak FieldSpecId ve kullanıcı tarafından girilen değerlerin dictionary olarak tutulduğu alan
        /// </summary>
        public Dictionary<int, object> Payload { get; set; }
    }
}
