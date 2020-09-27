using LindegaardProductions.Web.Business.Services;
using LindegaardProductions.Web.Models.Helpers;
using LindegaardProductions.Web.Models.ModelsBuilder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Umbraco.Core;
using Umbraco.Core.Models.PublishedContent;
using Umbraco.Web;
using Umbraco.Web.Security;

namespace LindegaardProductions.Web.Business.Mappers
{
    public class NavigationItemMapper : IInjected
    {
        private static bool ProcessTypedContent(IPublishedContent content)
        {
            return content.IsVisible();
        }

        public static T Map<T>(IPublishedContent content, IPublishedContent currentNode, UmbracoHelper helper, T model = default(T))
            where T : NavigationItemModel, new()
        {
            if (content == null) return null;
            if (model == null) model = new T();

            if (content is INavigation)
            {
                var naviContent = (INavigation)content;

                model.Active = content.IsAncestorOrSelf(currentNode);
                model.Name = content.Name;
                model.Url = content.Url;
                model.IsHidden = naviContent.UmbracoNaviHide;
            }

            return model;
        }

        public static IEnumerable<T> Map<T>(IEnumerable<IPublishedContent> content, IPublishedContent currentNode, UmbracoHelper helper)
            where T : NavigationItemModel, new()
        {
            return content.Where(ProcessTypedContent).Select(x => Map<T>(x, currentNode, helper)).WhereNotNull();
        }
    }
}
