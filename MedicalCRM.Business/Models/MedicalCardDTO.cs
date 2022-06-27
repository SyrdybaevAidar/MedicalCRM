using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalCRM.Business.Models {
    public class MedicalCardDTO {
        public int Id { get; set; }
        public int PatientId { get; set; }
        public string FamilyDoctorName { get; set; }
        public int BloodTypeId { get; set; }
        public BloodTypeDTO BloodType { get; set; }
        public string Address { get; set; }
    }
}
