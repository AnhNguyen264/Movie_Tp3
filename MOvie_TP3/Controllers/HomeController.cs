using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Localization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Localization;
using TP2.Models;
using TP2.ViewModels;
using TP2.Models.Data;
using TP2.Utility;

namespace TP2.Controllers
{
    public class HomeController : Controller
    {

        private TPDbContext _baseDonnees { get; set; }
        private readonly IStringLocalizer<HomeController> _localizer;
        private readonly ILogger<HomeController> _logger;


        public HomeController(TPDbContext donnees, IStringLocalizer<HomeController> localizer, ILogger<HomeController> logger)
        {
            _baseDonnees = donnees;
            _localizer = localizer;
            _logger = logger;

        }

        public void OnGet()
        {
            _logger.LogInformation("About page visited at {DT}" ,
                DateTime.UtcNow.ToLongTimeString());
        }
        //[Route("")]
        //[Route("home/index")]
        //[Route("index")]
        [AllowAnonymous]
        public IActionResult Index()
        {
            //ViewData["titre"] = "Acceuil";
            return View(_baseDonnees.Parents.ToList());
        }

        [Authorize]
        public IActionResult Privacy()
        {
            ViewBag.Title = _localizer["PrivacyTitle"];
            return View();
        }

        [Authorize]
        public IActionResult Dashboard()
        {

            return View();
        }
        [Authorize(Roles = AppConstants.AdminRole)]
        public IActionResult Financial()
        {

            return View();
        }
        [Authorize(Roles = AppConstants.ChefEquipeRole + "," + AppConstants.AdminRole)]
        public IActionResult LeaderObjective()
        {
            List<Objectives> objectT = _baseDonnees.Objectives.ToList();

            return View(objectT);

        }

        public async Task<IActionResult> DetailsObjects(int id)
        {
            var detailsObject = _baseDonnees.Vendeurs.Where(x => x.ObjectivesId == id);

            ObjectiveVM objectiveVM = new()
            {
                objectives = new(),
                vendeurList = detailsObject.ToList()
            };
            objectiveVM.objectives = await _baseDonnees.Objectives.FirstOrDefaultAsync(z => z.Id == id);
            return View(objectiveVM);
        }

        [Authorize(Roles = AppConstants.ChefEquipeRole + "," + AppConstants.AdminRole)]

        public IActionResult Employes()
        {
            List<Vendeur> vendeurs = _baseDonnees.Vendeurs.ToList();

            return View(vendeurs);
        }
        [Authorize]

        public async Task<IActionResult> DetailsVendeurs(int id)
        {
            var detailsVendeurs = _baseDonnees.Objectives.Where(x => x.VendeursId == id);

            VendeurVM vendeurVM = new()
            {
                venduers = new(),
                objecttivesLists = detailsVendeurs.ToList()
            };
            vendeurVM.venduers = await _baseDonnees.Vendeurs.FirstOrDefaultAsync(z => z.Id == id);
            return View(vendeurVM);
        }
        public IActionResult Consulter(int id)
        {


            //ViewData["titre"] = "Acceuil";
            var parentRecherche = _baseDonnees.Parents.Where(p => p.Id == id).Select(x=>x).SingleOrDefault();
                
            if (parentRecherche == null)
            {
                return View("NonTrouvé", "La liste de film n'a pas été trouvé!");
            }
            else
            {
                return View(parentRecherche);
            }
        }

        [HttpPost]
        public IActionResult SetLanguage(string culture, string returnUrl)
        {
            var cookie = CookieRequestCultureProvider.MakeCookieValue(new RequestCulture(culture));
            var name = CookieRequestCultureProvider.DefaultCookieName;

            Response.Cookies.Append(name, cookie, new CookieOptions
            {
                Path = "/",
                Expires = DateTimeOffset.UtcNow.AddYears(1),
            });

            return LocalRedirect(returnUrl);
        }
    }
}
