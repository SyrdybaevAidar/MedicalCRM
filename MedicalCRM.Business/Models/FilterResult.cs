using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalCRM.Business.Models {
    public class FilterResult {
        public List<UserDTO> Users { get; set; }
        public int Page { get; set; }
        public int TotalItemCount { get; set; }
        public int PageSize { get; set; }
        public int PageCount => TotalItemCount / PageSize;
        public int PagesVisibleCount => 2;
        public bool IsLastPage => Page == PageCount;
        public bool IsFirstPage => Page == 0;
    }
}
