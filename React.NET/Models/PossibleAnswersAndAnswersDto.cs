using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace React.NET.Models
{
    public class PossibleAnswersAndAnswersDto
    {
        public IEnumerable<PossibleAnswerDto> PossibleAnswers { get; set; }
        public IEnumerable<PossibleAnswerDto> Answers { get; set; }
    }
}
