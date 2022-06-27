using MedicalCRM.DataAccess.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalCRM.DataAccess.Entities {
    public class Disease: IEntity {
        public int Id { get; set; }
        public string Name { get; set; }
        public ICollection<ConsultationDisease> Consultations { get; set; }
    }
}
