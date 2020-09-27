using LindegaardProductions.Web.Controllers.Shared;
using LindegaardProductions.Web.Models.ModelsBuilder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using Umbraco.Web;

namespace LindegaardProductions.Web.Controllers
{
    public class YearController : PageControllerBase
    {
        public ActionResult Index(Year currentPage)
        {
            var first = currentPage.Children<Article>().OrderByDescending(x => x.CreateDate).FirstOrDefault();
            return Redirect(first.Url);
        }
    }
}
