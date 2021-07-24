using System;
using System.Collections.Generic;
using System.Text;

namespace MyBookCollection.Models
{
    public class AuditableBase
    {
        public DateTim CreatedDate { get; set; }

        public DateTime? UpdatedDate { get; set; }

        public string CreatedBy { get; set; }

        public string UpdatedBy { get; set; }
    }
}
