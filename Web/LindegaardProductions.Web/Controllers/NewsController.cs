using LindegaardProductions.Web.Controllers.Shared;
using LindegaardProductions.Web.Models.ModelsBuilder;
using LindegaardProductions.Web.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using Umbraco.Web;

namespace LindegaardProductions.Web.Controllers
{
    public class NewsController : PageControllerBase
    {
        public ActionResult Index(News currentPage)
        {
            return View(new NewsViewModel()
            {
                CurrentPage = currentPage,
                Children = currentPage.Descendants<Article>(),
            });
        }
    }
}
