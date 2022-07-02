using MedicalCRM.Business.Models;
using MedicalCRM.DataAccess.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalCRM.Business.Services.Interfaces {
    public interface IReceptService {
        Task Add(int consultationId);
        Task AddMedicament(MedicamentDTO dto);
        Task DeleteMedicament(int id);
        Task<Recept> GetById(int id);
    }
}
