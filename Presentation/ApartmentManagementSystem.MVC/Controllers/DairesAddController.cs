using ApartmentManagementSystem.Domain.Entities;
using ApartmentManagementSystem.MVC.Models.Request;
using ApartmentManagementSystem.Persistance.Context;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NToastNotify;
using Resend;

namespace ApartmentManagementSystem.MVC.Controllers
{
    
    public class DairesAddController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IToastNotification _toastNotification;
        private readonly ApartmentManagementSystemDbContext _context;
        private readonly IResend _resend;
        private readonly UserManager<AppUser> _userManager;

        public DairesAddController(ILogger<HomeController> logger, IToastNotification toastNotification, IResend resend, UserManager<AppUser> userManager, ApartmentManagementSystemDbContext context)
        {
            _logger = logger;
            _toastNotification = toastNotification;
            _resend = resend;
            _userManager = userManager;
            _context = context;
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

        [HttpPost] // https://localhost:7063/DairesAdd/Add
        public async Task<IActionResult> Add(DairesRequest request)
        {

            if (!ModelState.IsValid)
            {
                return View();
            }

            _toastNotification.AddSuccessToastMessage("Daire bilgileri başarıyla kaydedildi.");


            Daire daire = new();

            if (request != null)
            {
                daire.daireNo = request.DaireNo;
                daire.floorNo = request.FloorNo;

                // Kullanıcıyı UserManager ile çek
                var User = await _userManager.FindByIdAsync(request.UserId);

                // User'ı başlat
                daire.user = User;

                AppUser DaireUser = new AppUser
                {
                    UserName = daire.user.UserName,
                    firstName = daire.user.firstName, 
                    lastName = daire.user.lastName,
                    PhoneNumber = daire.user.PhoneNumber,
                    Email = daire.user.Email
                };

                // Subscriptions listesini başlat
                daire.subscriptions = new List<Subscription>();

                // Subscriptions'ları request.Subscriptions'tan kopyala               
                    var subscription = new Subscription
                    {
                        price = request.Subscriptions,
                        isPaid = false // Varsayılan değeri false olarak ayarla
                    };

                    daire.subscriptions.Add(subscription);   
                
                daire.CreatedOn = DateTime.UtcNow;

                // Daire nesnesini veritabanına ekleyin
                _context.daires.Add(daire);

                try
                {
                    await _context.SaveChangesAsync();
                }
                catch (Exception ex)
                {
                    // Hata mesajını logla
                    _logger.LogError(ex, "SaveChangesAsync hatası");
                    throw; // Hatanın tekrar fırlatılması
                }


            }

            return View();


        }
    }
}
