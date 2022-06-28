using MedicalCRM.Business.Models;
using MedicalCRM.Business.UOWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalCRM.Business.Services {
    public class AdminService {
        private readonly IUnitOfWork _uow;
        public AdminService(IUnitOfWork uow) {
            _uow = uow;
        }

        public async Task CreateDoctor(UserDTO user) { 
            
        }
    }
}
