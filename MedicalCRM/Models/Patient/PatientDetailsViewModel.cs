using MedicalCRM.DataAccess.Enums;

namespace MedicalCRM.Models.Patient {
    public class PatientDetailsViewModel {
        public string Id { get; set; }
        public Sex Sex { get; set; }
        public string Surname { get; set; }
        public string Name { get; set; }
        public string Patronimic { get; set; }
        public DateTime BirthDate { get; set; } 
        public string BloodType { get; set; }
        public string Address { get; set; }
        public string FamilyDoctor { get; set; }
        public List<DiseaseIndexViewModel> Diseases { get; set; }
    }
}
