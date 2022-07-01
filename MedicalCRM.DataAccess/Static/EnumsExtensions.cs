using MedicalCRM.DataAccess.Common;
using MedicalCRM.DataAccess.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalCRM.DataAccess.Static {
    public class EnumsExtensions {
        public static List<LookUpItem<int, string>> GetSexLookUpItem() {
            return new() {
                new((int)Sex.Man, "Мужской"),
                new((int)Sex.Woman, "Женский")
            };
        }
    }
}
