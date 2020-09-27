using LindegaardProductions.Web.Business.Helpers;
using LindegaardProductions.Web.Business.ViewPages;
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

namespace LindegaardProductions.Web.Controllers.Shared
{
    public class PageControllerBase : RenderMvcController
    {
        public GlobalModel GlobalModel { get; set; }

        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (filterContext.IsChildAction)
            {
                return;
            }
            this.BuildGlobalModel();

            base.OnActionExecuting(filterContext);
        }

        private void BuildGlobalModel()
        {
            GlobalModel globalModel = this.GlobalModel = new GlobalModel();

            // Set Global model properties;
            var homePage = CurrentPage.AncestorOrSelf<LandingPage>();

            globalModel = GlobalModelHelper.GetGlobalModel(Umbraco, CurrentPage, homePage);

            this.ViewData[AbstractViewPage.GlobalModelViewDataKey] = globalModel;
        }
    }
}
