using MedicalCRM.DataAccess.Entities.Abstract;
using MedicalCRM.DataAccess.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalCRM.DataAccess.Entities {
    public class BloodType: IEntity {
        public int Id { get; set; }
        public string Name { get; set; }
    }
}
