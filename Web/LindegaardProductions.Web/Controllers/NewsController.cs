using LindegaardProductions.Web.Controllers.Shared;
using LindegaardProductions.Web.Models.Helpers;
using LindegaardProductions.Web.Models.ModelsBuilder;
using LindegaardProductions.Web.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using Umbraco.Web;

namespace LindegaardProductions.Web.Controllers
{
    public class NewsController : PageControllerBase
    {
        public ActionResult Index(News currentPage, int year = 0)
        {
            IEnumerable<Article> children = currentPage.Descendants<Article>();
            var yearsAvailable = currentPage.Children<Year>();
            if (year == 0)
            {
                year = DateTime.Now.Year;
            }
            if (children != null && children.Any())
            {
                var newsYear = yearsAvailable.Where(x => x.Name == year.ToString()).FirstOrDefault();
                children = newsYear.Children<Article>().OrderByDescending(x => x.CreateDate);
            }
            var NewsCardsModel = new NewsCardsModel(){
                Cards = children,
                ActiveYear = year,
                YearsAvailable = yearsAvailable.Select(x=> x.Name),
                PageId = currentPage.Id,
            };
            return View(new NewsViewModel()
            {
                CurrentPage = currentPage,
                NewsCards = NewsCardsModel,
            });
        }
    }
}
