using MedicalCRM.Business.Models;
using MedicalCRM.DataAccess.Entities;

namespace MedicalCRM.Models.Patient {
    public class ReceptFormViewModel {
        public Recept Recept { get; set; }
        public UserDTO Doctor { get; set; }
        public UserDTO User { get; set; }
    }
}
