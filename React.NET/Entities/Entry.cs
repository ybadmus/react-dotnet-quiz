using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace React.NET.Entities
{
    public class Entry
    {
        [Key]
        public Guid Id { get; set; }

        [ForeignKey("QuestionId")]
        public Guid Question { get; set; }

        public Guid QuestionId { get; set; }

        [ForeignKey("UserId")]
        public Guid User { get; set; }

        public Guid UserId { get; set; }

        public bool Correct { get; set; }
    }
}
