using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace MedicalCRM.Controllers {
    public class BaseController : Controller {
        public int CurrentUserId => int.TryParse(User.FindFirstValue(ClaimTypes.NameIdentifier), out int result) ? result : 0;
        public string CurrentUserName => User.FindFirstValue(ClaimTypes.Name);
    }
}
