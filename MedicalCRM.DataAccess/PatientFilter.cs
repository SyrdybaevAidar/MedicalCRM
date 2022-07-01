using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalCRM.DataAccess {
    public class PatientFilter: UserFilterView {
        public int DoctorId { get; set; }
    }
}
