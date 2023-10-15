using System.ComponentModel.DataAnnotations;
using System.Text.Json;

namespace DynamicFormBuilder.Domain.Entities
{
    public class FieldData
    {
        [Key]
        public int Id { get; set; }
        public int FieldSpecId { get; set; }
        public FieldSpec FieldSpec { get; set; }
        public string Name { get; set; }
        public string Value { get; set; }
    }
}
