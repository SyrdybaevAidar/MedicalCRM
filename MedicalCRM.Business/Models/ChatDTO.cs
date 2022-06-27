using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalCRM.Business.Models {
    public class ChatDTO {
        public int Id { get; set; }
        public UserDTO PatientUser { get; set; }
        public UserDTO DoctorUser { get; set; }
        public List<MessageDTO> Messages { get; set; }
    }
}
