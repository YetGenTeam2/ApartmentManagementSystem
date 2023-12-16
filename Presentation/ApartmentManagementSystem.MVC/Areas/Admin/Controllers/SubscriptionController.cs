using ApartmentManagementSystem.Domain.Entities;
using ApartmentManagementSystem.Persistance.Context;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace ApartmentManagementSystem.MVC.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Authorize(Roles = "Admin")]
    public class SubscriptionController : Controller
    {

        private readonly UserManager<AppUser> _userManager;
        private readonly ApartmentManagementSystemDbContext _context;

        public SubscriptionController(UserManager<AppUser> userManager, ApartmentManagementSystemDbContext context)
        {
            _userManager = userManager;
            _context = context;
        }

        [HttpGet]
        public IActionResult Index()
        {
            List<Daire> daireList = _context.daires.ToList();
            return View(daireList);
        }

        [HttpPost]
        public async Task<IActionResult> SubscriptionEntry(decimal price)
        {
            List<Daire> daireList =  _context.daires.ToList();
            List<Subscription> subscriptions = new List<Subscription>();

            foreach(Daire daire in daireList)
            {
                Subscription subscription = new Subscription();

                subscription.price = price;
                subscription.daire = daire;
                subscription.isPaid = false;
                subscription.ModifiedOn = DateTime.Now;

                subscriptions.Add(subscription);

            }

            await _context.subscriptions.AddRangeAsync(subscriptions);
            await _context.SaveChangesAsync();

            return View();
        }
    }
}
