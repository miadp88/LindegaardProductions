using LindegaardProductions.Web.Models.Helpers;
using LindegaardProductions.Web.Models.ModelsBuilder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using Umbraco.Web;
using Umbraco.Web.Mvc;

namespace LindegaardProductions.Web.Controllers.Surface
{
    public class NewsSurfaceController : SurfaceController
    {
        public ActionResult GetNews(int pageId, int year)
        {
            var page = Umbraco.Content(pageId);
            IEnumerable<Article> children = page.Descendants<Article>();
            var yearsAvailable = page.Children<Year>();

            if (year == 0)
            {
                year = DateTime.Now.Year;
            }
            if (children != null && children.Any())
            {
                var newsYear = yearsAvailable.Where(x => x.Name == year.ToString()).FirstOrDefault();
                children = newsYear.Children<Article>().OrderByDescending(x => x.CreateDate);
            }
            var model = new NewsCardsModel()
            {
                Cards = children,
                YearsAvailable = yearsAvailable.Select(x=> x.Name),
                ActiveYear = year,
                PageId = pageId
            };
            return PartialView("_NewsCards", model);
        }
    }
}
