using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MyBookCollection.Models
{
    public class CharacterDto : AuditableBase
    {
        [Key]
        public int CharacterId { get; set; }

        [Required]
        public string CharacterName { get; set; }


        //public List<BookDto> Books { get; set; }

    }

    
}