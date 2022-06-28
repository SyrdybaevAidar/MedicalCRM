using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalCRM.Business.Models.Email {
    public class EmailMessage {
        public string Receiver { get; set; }
        public string Theme { get; set; }
        public string Text { get; set; }
        public MemoryStream Attachment { get; set; }
    }
}
