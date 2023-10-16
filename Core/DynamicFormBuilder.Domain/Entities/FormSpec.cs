using DynamicFormBuilder.Domain.Entities.Base;

namespace DynamicFormBuilder.Domain.Entities
{
    public class FormSpec : AAuditableEntity<int>
    {
        public string Name { get; set; }
        public string Label { get; set; }
        public string ClassName { get; set; }
        public string Style { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? FinishDate { get; set; }
        public string Action { get; set; }

        public IEnumerable<FieldSpec> FieldSpecs { get; set; }
        public IEnumerable<FormSubmission> FormSubmissions { get; set; }
    }
}
