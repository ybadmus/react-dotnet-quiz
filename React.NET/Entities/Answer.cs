using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace React.NET.Entities
{
    public class Answer
    {
        [Key]
        public Guid Id { get; set; }

        [ForeignKey("AuthorId")]
        public Question Question { get; set; }

        public Guid QuestionId { get; set; }

        [MaxLength(500)]
        public string Text { get; set; }
    }
}
