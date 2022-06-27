using Microsoft.AspNetCore.SignalR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MedicalCRM.Business.Services {
    public class CustomUserIdProvider : IUserIdProvider {
        public virtual string GetUserId(HubConnectionContext connection) {
            return connection.User?.Identity.Name;
        }
    }
}
