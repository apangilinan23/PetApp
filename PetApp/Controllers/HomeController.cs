using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authentication;
using PetApp.Models;
using PetApp.Services.Pet;
using PetApp.ViewModel;

namespace PetApp.Controllers
{
    public class HomeController : Controller
    {
        private IPetService _petService;

        public HomeController(IPetService petService)
        {
            _petService = petService;
        }

        public IActionResult Index(string? returnUrl = null)
        {
            ViewData["ReturnUrl"] = Url.Action("PetList", "Home") ?? string.Empty;
            return View("~/Views/Home/Login.cshtml", new LoginViewModel());
        }

        // GET: /Home/PetList
        [HttpGet]
        public IActionResult PetList()
        {
            var petList = _petService.GetPets();
            var petViewModel = new PetViewModel
            {
                Pets = petList
            };
            return View("~/Views/Home/Index.cshtml", petViewModel);
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

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Login(LoginViewModel model, string? returnUrl = null)
        {
            ViewData["ReturnUrl"] = returnUrl;

            if (!ModelState.IsValid)
                return View("~/Views/Home/Login.cshtml", model);

            // Replace this with your real authentication logic (DB lookup, Identity, etc.)
            if (model.Username == "admin" && model.Password == "admin123")
            {
                if (!string.IsNullOrEmpty(returnUrl) && Url.IsLocalUrl(returnUrl))
                    return Redirect(returnUrl);

                // Redirect to PetList action on successful login
                return RedirectToAction("PetList", "Home");
            }

            ModelState.AddModelError(string.Empty, "Invalid username or password.");
            return View("~/Views/Home/Login.cshtml", model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Logout()
        {
            // Clear session state if configured
            try
            {
                HttpContext.Session?.Clear();
            }
            catch
            {
                // Session may not be configured; ignore failures to avoid throwing at logout.
            }

            // If authentication is configured, sign the user out.
            await HttpContext.SignOutAsync();

            TempData["SuccessMessage"] = "Signed out successfully.";
            return RedirectToAction("Index", "Home");
        }
    }
}
