using MedicalCRM.DataAccess.Entities.UserEntities.ChatEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalCRM.DataAccess.Entities.UserEntities {
    public class DoctorUser: User {
        public int? DoctorDetailsId { get; set; }
        public DoctorDetails? DoctorDetails { get; set; }
        public ICollection<Chat> Chats { get; set; }
        public byte[] Image { get; set; }
    }
}
