using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace MyBookCollection.Models
{
    public class BookTypeDto : AuditableBase
    {
        [Key]
        public int BookTypeId { get; set; }

        [Required]
        public string BookTypeName { get; set; }

       // public List<BookDto> Books { get; set; }

    }
}
