using System.ComponentModel.DataAnnotations;

namespace DynamicFormBuilder.Domain.Entities
{
    public class FormSubmission
    {
        [Key]
        public int Id { get; set; }
        public int FormSpecId { get; set; }
        public FormSpec FormSpec { get; set; }
        public string Payload { get; set; }
    }
}
