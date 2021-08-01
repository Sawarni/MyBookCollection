using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace MyBookCollection.WebApi.DomainEntities
{
    public class ImageFile
    {
        [Key]
        public int ImageId { get; set; }

        [Required]
        public string ImageFileName { get; set; }

        [Required]
        public byte[] ImageContent { get; set; }
    }
}
