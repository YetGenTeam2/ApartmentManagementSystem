using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ApartmentManagementSystem.MVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class UpdateDaireController : Controller
    {
        [HttpPost]
        public IActionResult UpdateDaire()
        {
            return View();
        }
    }
}
