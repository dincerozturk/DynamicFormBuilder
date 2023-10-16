using DynamicFormBuilder.Domain.Entities.Base;

namespace DynamicFormBuilder.Domain.Entities
{
    public class FormSubmission : AAuditableEntity<int>
    {
        public int FormSpecId { get; set; }
        public FormSpec FormSpec { get; set; }
        public string Payload { get; set; }
    }
}
