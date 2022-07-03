using MedicalCRM.DataAccess.Entities.UserEntities.ChatEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalCRM.DataAccess.Entities.UserEntities {
    public class PatientUser : User {
        public ICollection<Chat> Chats { get; set; }
        public ICollection<Consultation> Consultations {get;set;}
        public int? BloodTypeId { get; set; }
        public BloodType? BloodType { get; set; }
        public string Address { get; set; }
        public string PassportId { get; set; }
        public DoctorUser DoctorUser { get; set; }
        public int? DoctorUserId { get; set; }
    }
}
