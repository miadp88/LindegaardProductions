using LindegaardProductions.Web.Controllers.Shared;
using LindegaardProductions.Web.Models.ModelsBuilder;
using LindegaardProductions.Web.Models.ViewModels;
using System.Web.Mvc;
using Umbraco.Web;

namespace LindegaardProductions.Web.Controllers
{
    public class LandingPageController : PageControllerBase
    {
        public ActionResult Index(LandingPage currentPage)
        {
            return View(new LandingPageViewModel()
            {
                CurrentPage = currentPage,
                RoadMapPages = currentPage.Children<Frontpage>(),
            });
        }
    }
}
