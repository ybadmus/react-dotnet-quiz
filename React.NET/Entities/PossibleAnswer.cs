using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace React.NET.Entities
{
    public class PossibleAnswer
    {
        [Key]
        public Guid Id { get; set; }

        [ForeignKey("QuestionId")]
        public Question Question { get; set; }

        public Guid QuestionId { get; set; }

        public string PossibleAnswerText { get; set; }

        public bool Answer { get; set; }
    }
}
