using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalCRM.Business.Models {
    public class FilterResult {
        public FilterResult(int totalItemCount, int page, List<UserDTO> users) {
            TotalItemCount = totalItemCount;
            PageCount = totalItemCount / PageSize;
            PageCount = PageCount == 0 ? 1 : PageCount;
            Users = users;
            Page = page;
        }
        public List<UserDTO> Users { get; set; }
        public int Page { get; set; }
        public int TotalItemCount { get; set; }
        public int PageSize { get; set; } = 10;
        public int PageCount { get; set; }
        public int PagesVisibleCount => 2;
        public bool IsLastPage => Page == PageCount;
        public bool IsFirstPage => Page == 0 || Page == 1;
    }
}
