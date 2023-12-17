using ApartmentManagementSystem.Domain.Entities;
using ApartmentManagementSystem.MVC.Models.Request;
using ApartmentManagementSystem.Persistance.Context;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NToastNotify;
using Resend;

namespace ApartmentManagementSystem.MVC.Controllers
{
    public class DairesController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IToastNotification _toastNotification;
        private readonly ApartmentManagementSystemDbContext _context;
        private readonly IResend _resend;
        private readonly UserManager<AppUser> _userManager;

        public DairesController(ILogger<HomeController> logger, IToastNotification toastNotification, IResend resend, UserManager<AppUser> userManager)
        {
            _logger = logger;
            _toastNotification = toastNotification;
            _resend = resend;
            _userManager = userManager;
        }


        public IActionResult Index()
        {
            return View();
        }

        // Add Method()
        [HttpGet]
        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> AddDaires( DairesRequest request)
        {

            if (!ModelState.IsValid)
            {
                return View();
            }

            _toastNotification.AddSuccessToastMessage("Daire bilgileri başarıyla kaydedildi.");

            Daire daire = new ();
            daire.daireNo = request.DaireNo;
            daire.floorNo = request.FloorNo;
            daire.user.Id = request.UserId;
            foreach (var subscription in daire.subscriptions)
            {
                subscription.price = request.Subscriptions;
                subscription.isPaid = false;
            }
            

            daire.CreatedOn = DateTime.UtcNow;



            return View();


        }
    }
}
