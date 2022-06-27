using AutoMapper;
using MedicalCRM.Business.UOWork;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalCRM.Business.Services {
    public class BaseService {
        protected readonly IUnitOfWork _uow;
        protected readonly IMapper _mapper;

        public BaseService(IUnitOfWork uow, IMapper mapper) {
            _uow = uow;
            _mapper = mapper;
        }
    }
}
