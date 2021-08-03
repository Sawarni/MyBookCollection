using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Text;

namespace MyBookCollection.Models
{
   public class ImageFileDto
    {
        [Key]
        public int ImageId { get; set; }

        [Required]
        public string ImageFileName { get; set; }

        [Required]
        public byte[] ImageContent { get; set; }

        public string ImageBase64
        {
            get
            {
                if (ImageContent == null)
                    return null;
               return Convert.ToBase64String(ImageContent);
            }
        }

        public string ImageType
        {
            get
            {
                string fileExtension = Path.GetExtension(ImageFileName);
                return $"data:image/{fileExtension};base64";
            }
        }


    }
}
