using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MyBookCollection.WebApi.DomainEntities
{
    public class Book : AuditableBase
    {
        [Required]
        [Key]
        public int BookId { get; set; }

        [Required]
        [MinLength(2)]
        public string BookName { get; set; }

        public int PublisherId { get; set; }

        public int BookTypeId { get; set; }


        public List<Character> Characters { get; set; }

        public List<Author> Authors { get; set; }

        public Publisher Publisher { get; set; }

        public BookType BookType { get; set; }

        public ImageFile BookImage { get; set; }

        


    }
}
