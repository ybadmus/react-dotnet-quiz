using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace React.NET.Entities
{
    public class Question
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [MaxLength(500)]
        public string Text { get; set; }

        public ICollection<Answer> Answers { get; set; }
           = new List<Answer>();
    }
}
