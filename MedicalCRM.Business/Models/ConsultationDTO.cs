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
        public ICollection<ConsultationDisease>? ChronicalDiseases { get; set; }
        public ICollection<int>? ChronicalDiseasesIds { get; set; }
        public string Recommendations { get; set; }
        public DateTime Date { get; set; }
        public string Complaints { get; set; }

        public string CheckedChronicalDiseases { get {

                if (ChronicalDiseases != null && ChronicalDiseases.Count() > 0) {
                    return ChronicalDiseases.Select(i => i.Disease.Name).Aggregate((txt, name) => txt + ", " + name);
                }
                return "";
            } 
        
       }
    }
}
