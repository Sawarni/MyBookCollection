using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MyBookCollection.Models
{
    public class AuthorDto : AuditableBase
    {
        [Key]
        [Required]
        public int AuthorId { get; set; }

        [Required]
        public string AuthorName { get; set; }

        //public List<BookDto> Books { get; set; }
    }
}