﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalCRM.DataAccess.Enums {
    public enum UserType {
        Unauthorized,
        User,
        Admin,
        Doctor,
        Patient
    }
}
