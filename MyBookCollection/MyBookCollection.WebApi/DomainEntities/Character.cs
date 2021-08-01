using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MyBookCollection.WebApi.DomainEntities
{
    public class Character : AuditableBase
    {
        [Key]
        public int CharacterId { get; set; }

        [Required]
        public string CharacterName { get; set; }


        public List<Book> Books { get; set; }


        public ImageFile CharacterImage { get; set; }

        
    }


}