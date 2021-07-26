using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MyBookCollection.WebApi.DomainEntities
{
    public class Publisher : AuditableBase
    {
        [Key]
        public int PublisherId { get; set; }

        public string PiublisherName { get; set; }

        public List<Book> Books { get; set; }
    }
}