using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MyBookCollection.Models
{
    public class BookDto : AuditableBase
    {
        [Required]
        [Key]
        public int BookId { get; set; }

        [Required]
        [MinLength(2)]
        public string BookName { get; set; }

        public int PublisherId { get; set; }

        public int BookTypeId { get; set; }


        public List<CharacterDto> Characters { get; set; }

        public List<AuthorDto> Authors { get; set; }

        public PublisherDto Publisher { get; set; }

        public BookTypeDto BookType { get; set; }




    }
}
