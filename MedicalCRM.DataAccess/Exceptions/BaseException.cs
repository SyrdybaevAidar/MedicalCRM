﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalCRM.DataAccess.Exceptions {
    public class BaseException: Exception {
        public string ReadbleMessage;

        public BaseException(string readbleMessage): base() { 
            ReadbleMessage = readbleMessage;
        }
    }
}
