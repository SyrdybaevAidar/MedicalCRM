using MedicalCRM.DataAccess.Enums;

namespace MedicalCRM.Business.Models {
    public class UserDTO {
        public int Id { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public Sex Sex { get; set; }
        public string Surname { get; set; }
        public string Name { get; set; }
        public string Patronimic { get; set; }
        public DateTime BirthDate { get; set; }
        public int BloodTypeId { get; set; }
        public string Address { get; set; }
        public int DoctorUserId { get; set; }
        public string GetFullName() {
            return $"{Surname} {Name} {Patronimic}";
        }
    }
}