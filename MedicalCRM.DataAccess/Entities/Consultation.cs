using MedicalCRM.DataAccess.Entities.Abstract;
using MedicalCRM.DataAccess.Entities.UserEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalCRM.DataAccess.Entities {
    public class Consultation: IEntity {
        public int Id { get; set; }
        public int? DoctorId { get; set; }
        public DoctorUser Doctor {get;set;}
        public int? PatientId { get; set; }
        public PatientUser Patient { get; set; }
        public string Diseases { get; set; }
        public DateTime Date { get; set; }
        public string? Complaints { get; set; }
        public string Recommendations { get; set; }
        public Recept Recept { get; set; }
    }
}
