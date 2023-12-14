using ApartmentManagementSystem.Domain.Entities;
using ApartmentManagementSystem.MVC.Models;
using ApartmentManagementSystem.MVC.Models.Request;
using ApartmentManagementSystem.Persistance.Context;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using ApartmentManagementSystem.MVC.Extentions;
using NToastNotify;
using Resend;
using System.Web;
namespace ApartmentManagementSystem.MVC.Controllers
{
    public class HomeController : Controller
    {
        
        public HomeController()
        {
 
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }
       
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
        
        


    }
}
