using LindegaardProductions.Web.Controllers.Shared;
using LindegaardProductions.Web.Models.ModelsBuilder;
using LindegaardProductions.Web.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace LindegaardProductions.Web.Controllers
{
    public class NotFoundController : PageControllerBase
    {
        public ActionResult Index(NotFound currentPage)
        {
            return View(new NotFoundViewModel()
            {
                CurrentPage = currentPage,
            });
        }
    }
}
