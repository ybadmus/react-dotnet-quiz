using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace React.NET.Models
{
    public class EntryForCreationDto
    {
        public Guid QuestionId { get; set; }
        public Guid UserId { get; set; }
        public bool Correct { get; set; }
    }
}
