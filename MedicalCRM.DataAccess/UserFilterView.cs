using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalCRM.DataAccess {
    public class UserFilterView {
        public string Surname { get; set; }
        public string Name { get; set; }
        public string Patronimic { get; set; }
        public string UserName { get; set; }
        public DateTime? BirthDateStart { get; set; }
        public DateTime? BirthDateEnd { get; set; }
        public int _page { get; set; }
        public int Page {
            get {
                if (_page == 0)
                    return 1;
                return _page;
            }
            set { _page = value; }
        }
        public int PageSize { get; set; }
        public int TotalItem { get; set; }
    }
}
