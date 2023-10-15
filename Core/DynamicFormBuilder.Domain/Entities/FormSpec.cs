using System.ComponentModel.DataAnnotations;

namespace DynamicFormBuilder.Domain.Entities
{
    public class FormSpec
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Label { get; set; }
        public string ClassName { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? FinishDate { get; set; }

        public IEnumerable<FieldSpec> FieldSpecs { get; set; }
        public IEnumerable<FormSubmission> FormSubmissions { get; set; }
    }
}
