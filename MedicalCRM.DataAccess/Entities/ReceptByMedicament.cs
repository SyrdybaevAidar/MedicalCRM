using MedicalCRM.DataAccess.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalCRM.DataAccess.Entities {
    public class ReceptByMedicament: IEntity {
        public int Id { get; set; }
        public int Count { get; set; }
        public int MedicamentId { get; set; }
        public Medicament Medicament { get; set; }
        public int ReceptId { get; set; }
        public Recept Recept { get; set; }
    }
}
