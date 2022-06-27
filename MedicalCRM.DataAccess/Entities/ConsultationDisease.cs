using MedicalCRM.DataAccess.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalCRM.DataAccess.Entities {
    public class ConsultationDisease: IEntity {
        public int Id { get; set; }
        public int ConsultationId { get; set; }
        public Consultation Consultation { get; set; }
        public int DiseaseId { get; set; }
        public Disease Disease { get; set; }
    }
}
