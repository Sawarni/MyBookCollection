using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MyBookCollection.Models
{
    public class PublisherDto : AuditableBase
    {
        [Key]
        public int PublisherId { get; set; }

        public string PublisherName { get; set; }

        //public List<BookDto> Books { get; set; }
    }
}