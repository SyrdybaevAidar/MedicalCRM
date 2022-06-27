using MedicalCRM.DataAccess.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalCRM.DataAccess.Entities.UserEntities.ChatEntities {
    public class Message: IEntity {
        public int Id { get; set; }
        public int ChatId { get; set; }
        public Chat Chat { get; set; }
        public int UserId { get; set; }
        public string Text { get; set; }
        public DateTime SendDate { get; set; } 
        public bool IsRead { get; set; }
    }
}
