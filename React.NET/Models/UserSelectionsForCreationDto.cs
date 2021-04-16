using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace React.NET.Models
{
    public class UserSelectionsForCreationDto
    {
        public IEnumerable<PossibleAnswerDto> Selection{ get; set; }
        public Guid QuestionId { get; set; }
        public Guid UserId { get; set; }
    }
}
