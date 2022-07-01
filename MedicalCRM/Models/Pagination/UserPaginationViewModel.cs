using MedicalCRM.Business.Models;

namespace MedicalCRM.Models.Pagination {
    public class UserPaginationViewModel {
        public PatientFilterDTO PatientFilter { get; set; }
        public FilterResult FilterResult { get; set; }
    }
}
