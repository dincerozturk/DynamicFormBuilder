﻿using DynamicFormBuilder.Domain.Base;
using System.ComponentModel.DataAnnotations.Schema;

namespace DynamicFormBuilder.Domain.Entities
{
    public class FormSpec : AAuditableEntity<int>
    {
        /// <summary>
        /// Form adı
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// Form Form Başlığı
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Formun başlangıç tarihi
        /// </summary>
        public DateTime StartDate { get; set; }

        /// <summary>
        /// Formun Bitiş Tarihi
        /// </summary>
        public DateTime? FinishDate { get; set; }


        public string Action { get; set; }

        /// <summary>
        /// Form styşe
        /// </summary>
        public Dictionary<string, object> AdditionalAttribute { get; }

        public IEnumerable<FieldSpec> FieldSpecs { get; set; }
        public IEnumerable<FormSubmission> FormSubmissions { get; set; }
    }
}
