﻿using LindegaardProductions.Web.Controllers.Shared;
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
    public class FrontPageController : PageControllerBase
    {
        public ActionResult Index(Frontpage currentPage)
        {
            var news = currentPage.Children<News>().FirstOrDefault();
            var allArticles = news.Descendants<Article>().OrderByDescending(x => x.CreateDate);
            
            return View(new FrontPageViewModel()
            {
                CurrentPage = currentPage,
                News = allArticles != null ? allArticles.Take(9) : null,
                MoreArticlesAvailable = allArticles.Count() > 9,
                NewsPageLink = news.Url,
            });
        }
    }
}