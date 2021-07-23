﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MyBookCollection.Models
{
    public class Author : AuditableBase
    {
        [Key]
        [Required]
        public int AuthorId { get; set; }

        [Required]
        public string AuthorName { get; set; }

        public List<Book> Books { get; set; }
    }
}