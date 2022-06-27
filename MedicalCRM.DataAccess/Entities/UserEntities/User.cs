using MedicalCRM.DataAccess.Entities.Abstract;
using MedicalCRM.DataAccess.Enums;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace MedicalCRM.DataAccess.Entities.UserEntities {
    public class User : IdentityUser<int>, IEntity {
        public Sex Sex { get; set; }
        public string Surname { get; set; }
        public string Name { get; set; }
        public string Patronimic { get; set; }
        public DateTime BirthDate { get; set; }
        public UserType UserType { get; set; }
        public string GetFullName() {
            return $"{Surname} {Name} {Patronimic}";
        }
    }
}
