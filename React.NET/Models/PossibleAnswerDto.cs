using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace React.NET.Models
{
    public class PossibleAnswerDto
    {
        public Guid Id { get; set; }
        public Guid QuestionId { get; set; }
        public string PossibleAnswerText { get; set; }
        public bool Answer { get; set; }
    }
}
