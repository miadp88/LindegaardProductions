using LindegaardProductions.Web.Models.Helpers;
using LindegaardProductions.Web.Models.ModelsBuilder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Umbraco.Core;
using Umbraco.Core.Cache;
using Umbraco.Core.Models.PublishedContent;
using Umbraco.Web;

namespace LindegaardProductions.Web.Business.Services
{
    public class LanguageVariantService : IInjected
    {

        /// <summary>
        /// Generates the list of languages for the page dropdown. If there is a parallel page using same culture then this is used, otherwise it falls back to the root URL.
        /// </summary>
        /// <param name="currentPage">The currently viewed page</param>
        /// <param name="currentCulture">The current culture</param>
        /// <returns>A list of languages and cultures</returns>
        public static List<CultureUrlModel> GetCurrentLanguageList(IPublishedContent currentPage, string currentCulture, AppCaches caches)
        {
            var landing = currentPage.AncestorOrSelf<LandingPage>();

            var rootCultures = GetRootCultures(landing, caches);
            var pageCultures = currentPage.Cultures.Select(x => x.Value);

            var mapped = new List<CultureUrlModel>(5);

            foreach (var root in rootCultures)
            {
                var pageMatch = pageCultures.FirstOrDefault(c => c.Culture == root.Culture);

                CultureUrlModel mappedPage = null;

                if (pageMatch != null)
                {
                    string url = currentPage.Url(pageMatch.Culture);

                    if (url != "#")
                    {
                        mappedPage = new CultureUrlModel()
                        {
                            Culture = pageMatch.Culture,
                            Url = url
                        };
                    }
                }

                if (mappedPage == null)
                {
                    mappedPage = new CultureUrlModel()
                    {
                        Culture = root.Culture,
                        Url = landing.Url(root.Culture)
                    };
                }

                mappedPage.Current = mappedPage.Culture.InvariantEquals(currentCulture);

                mapped.Add(mappedPage);
            }

            return mapped;
        }

        private static IEnumerable<PublishedCultureInfo> GetRootCultures(IPublishedContent currentPage, AppCaches caches)
        {
            return caches.RuntimeCache.GetCacheItem("RootCultures", () => currentPage.Cultures.Select(x => x.Value).ToList());
        }
    }
}
