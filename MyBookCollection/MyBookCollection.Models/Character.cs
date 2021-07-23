﻿using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MyBookCollection.Models
{
    public class Character : AuditableBase
    {
        [Key]
        public int CharacterId { get; set; }

        [Required]
        public string CharacterName { get; set; }


        public List<Book> Books { get; set; }

    }

    
}