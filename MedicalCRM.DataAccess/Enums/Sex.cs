using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalCRM.DataAccess.Enums {
    public enum Sex {
        [Display(Name="Мужской")]
        Man,
        [Display(Name = "Женский")]
        Woman
    }
}
