using MedicalCRM.DataAccess.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalCRM.DataAccess.Entities.UserEntities.ChatEntities {
    public class Chat : IEntity {
        public int Id { get; set; }
        public int DoctorId { get; set; }
        public DoctorUser Doctor { get; set; }
        public int PatientId { get; set; }
        public PatientUser Patient { get; set; }
        public ICollection<Message> Messages { get; set; }
    }
}
