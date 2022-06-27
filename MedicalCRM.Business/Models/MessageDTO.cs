using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalCRM.Business.Models {
    public class MessageDTO {
        public int UserId { get; set; }
        public string SenderName { get; set; }
        public string ReceiverName { get; set; }
        public string Text { get; set; }
        public DateTime SendDate { get; set; }
        public bool IsCurrentUserMessage { get; set; }
    }
}
