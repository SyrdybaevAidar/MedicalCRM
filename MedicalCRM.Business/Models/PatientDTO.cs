using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalCRM.Business.Models {
    public class PatientDTO: UserDTO {
        public int DoctorUserId { get; set; }
        public DoctorDTO Doctor { get; set; }

        public List<ConsultationDTO> Consultations;
        public int BloodTypeId { get; set; }
        public BloodTypeDTO BloodType { get; set; }
        public string Address { get; set; }
        public string GetFullName() {
            return $"{Surname} {Name} {Patronimic}";
        }
    }
}
