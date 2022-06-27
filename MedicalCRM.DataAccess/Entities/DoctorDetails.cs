using MedicalCRM.DataAccess.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalCRM.DataAccess.Entities {
    public class DoctorDetails : IEntity {
        public int Id { get; set; }
        public int DoctorId { get; set; }
        public int PositionId { get; set; }
        public Position Position { get; set; }
    }
}
