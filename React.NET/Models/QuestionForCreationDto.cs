using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace React.NET.Models
{
    public class QuestionForCreationDto
    {
        public string QuestionText { get; set; }

        public ICollection<PossibleAnswerForCreationDto> PossibleAnswers { get; set; }
           = new List<PossibleAnswerForCreationDto>();
    }
}
