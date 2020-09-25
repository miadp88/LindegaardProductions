using LindegaardProductions.Web.Models.Helpers;
using System.Collections.Generic;
using System.Linq;
using Umbraco.Core.Models.PublishedContent;
using LindegaardProductions.Web.Models.ModelsBuilder;
using Umbraco.Web;
using LindegaardProductions.Web.Business.Extensions;
using Umbraco.Core;

namespace LindegaardProductions.Web.Business.Helpers
{
    public static class TeaserPageHelper
    {
        public static TeaserPageModel GetTeaserForPage(this IPublishedContent page)
        {

            var model = new TeaserPageModel()
            {
                Title = string.IsNullOrEmpty(page.Value<string>("title")) ? page.Value<string>("metaTitle") : page.Value<string>("title"),
                Description = string.IsNullOrEmpty(page.Value<string>("subHeading")) ? page.Value<string>("metaDescription") : page.Value<string>("subHeading"),
                Image = page.Value<Image>("metaImage"),
                Url = page.Url,
                Date = page.CreateDate.StandardDateTimeFormat(),
                Id = page.Id,
            };
            return model;
        }
        public static IEnumerable<TeaserPageModel> GetTeaserForPage(this IEnumerable<IPublishedContent> pages)
        {
            return pages.Where(ProcessTypedContent).Select(x => GetTeaserForPage(x)).WhereNotNull();
        }
        private static bool ProcessTypedContent(IPublishedContent content)
        {
            return content.IsVisible();
        }
    }
}
