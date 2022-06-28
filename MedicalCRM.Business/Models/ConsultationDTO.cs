using MedicalCRM.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalCRM.Business.Models {
    public class ConsultationDTO {
        public int Id { get; set; }
        public DoctorDTO Doctor { get; set; }
        public int? DoctorId { get; set; }
        public PatientDTO Patient { get; set; }
        public int? PatientId { get; set; }
        public string Diseases { get; set; }
        public string Recommendations { get; set; }
        public DateTime Date { get; set; }
        public string Complaints { get; set; }
    }
}
