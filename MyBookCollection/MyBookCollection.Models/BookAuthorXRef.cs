using System.ComponentModel.DataAnnotations;

namespace MyBookCollection.Models
{
    //Do not use . Remove later
     class BookAuthorXRef
    {
        [Key]
        private int BookAuthorXrefId { get; set; }
        
        [Required]
        private int BookId { get; set; }

        [Required]
        private int AuthorId { get; set; }
    }
}