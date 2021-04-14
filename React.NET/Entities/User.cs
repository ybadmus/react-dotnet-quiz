using System;
using System.ComponentModel.DataAnnotations;

namespace React.NET.Entities
{
    public class User
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [MaxLength(50)]
        public string Username { get; set; }
    }
}
