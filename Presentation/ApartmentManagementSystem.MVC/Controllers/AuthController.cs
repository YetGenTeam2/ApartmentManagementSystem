using ApartmentManagementSystem.Domain.Entities;
using ApartmentManagementSystem.MVC.Extentions;
using ApartmentManagementSystem.MVC.Models.Request;
using ApartmentManagementSystem.Persistance.Context;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using NToastNotify;
using Resend;
using System.Data;
using System.Web;

namespace ApartmentManagementSystem.MVC.Controllers
{

    public class AuthController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly UserManager<AppUser> _UserManager;
        private readonly SignInManager<AppUser> _signInManager;
        private readonly IToastNotification _toastNotification;
        private readonly ApartmentManagementSystemDbContext _context;
        private readonly IResend _resend;
        private readonly IWebHostEnvironment _environment;

        public AuthController(ILogger<HomeController> logger, UserManager<AppUser> userManager, SignInManager<AppUser> signInManager, IToastNotification toastNotification, IResend resend, IWebHostEnvironment environment)
        {
            _logger = logger;
            _UserManager = userManager;
            _signInManager = signInManager;
            _toastNotification = toastNotification;
            _resend = resend;
            _environment = environment;
        }
        public IActionResult SignUp()
        {
            return View();
        }
        public IActionResult SignIn()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> SignUp(SignUpRequest request)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            AppUser user = new AppUser() { UserName = request.PhoneNumber, firstName = request.firstName, lastName = request.lastName, Email = request.Email, PhoneNumber = request.PhoneNumber };
            var identityResult = await _UserManager.CreateAsync(user,
                 password: request.PasswordConfirm);
            await _UserManager.AddToRoleAsync(user, "User");
            if (identityResult.Succeeded)
            {
                
                _toastNotification.AddSuccessToastMessage("Üyelik kayıt işlemi başarıyla gerçekleşmiştir.");
                // Building the button's URL
                var token = await _UserManager.GenerateEmailConfirmationTokenAsync(user); // token, UserId

                token = HttpUtility.UrlEncode(token);

                var buttonLink = $"https://localhost:7206/Auth/VerifyEmail?email={user.Email}&token={token}";

                //
                var wwwRootPath = _environment.WebRootPath;

                var fullPathToHtml = Path.Combine(wwwRootPath, "email-templates", "verify-email.html");

                var htmlText = await System.IO.File.ReadAllTextAsync(fullPathToHtml);

                var title = "Seri Köz Getir - E-Posta Doğrulama";

                // Title
                htmlText = htmlText.Replace("{{Title}}", title);

                // Description
                htmlText = htmlText.Replace("{{Description}}",
                    "Uygulamamıza hoş geldiniz. E-Posta adresinizi doğrulamak için lütfen aşağıdaki \"Onayla\" butonuna tıklayınız.");

                htmlText = htmlText.Replace("{{ButtonLink}}", buttonLink);

                htmlText = htmlText.Replace("{{ButtonText}}", "Onayla");

                var message = new EmailMessage();
                message.From = "onboarding@resend.dev";
                message.To.Add(user.Email);
                message.Subject = title;
                message.HtmlBody = htmlText;

                await _resend.EmailSendAsync(message);

                return RedirectToAction(nameof(HomeController.SignIn));
            }

            ModelState.AddModelErrorList(identityResult.Errors.Select(x => x.Description).ToList());
            return View();

            
        }
        [HttpPost]
        public async Task<IActionResult> SignIn(SignInRequest model, string returnUrl = null)
        {
            returnUrl = returnUrl ?? Url.Action("Index", "Home");

            var hasUser = await _UserManager.FindByEmailAsync(model.Email);
            if (hasUser == null)
            {
                ModelState.AddModelError(string.Empty, "Email veya şifre yanlış.");
                _toastNotification.AddErrorToastMessage("Email veya şifre yanlış.");
                return View();
            }

            var signInResult = await _signInManager.PasswordSignInAsync(hasUser, model.Password, model.RememberMe, false);

            if (signInResult.Succeeded)
            {
                _toastNotification.AddSuccessToastMessage("Giriş işlemi başarıyla gerçekleşmiştir.");
                return Redirect(returnUrl);
            }
            ModelState.AddModelErrorList(new List<string>() { $"Email veya şifre yanlış." });
            _toastNotification.AddErrorToastMessage($"Email veya şifre yanlış.");

            return View();
        }
    }
}
