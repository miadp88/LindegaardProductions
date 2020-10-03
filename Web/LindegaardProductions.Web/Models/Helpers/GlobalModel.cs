using LindegaardProductions.Web.Models.ModelsBuilder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Umbraco.Core.Models.PublishedContent;

namespace LindegaardProductions.Web.Models.Helpers
{
    public class GlobalModel
    {
        public string LandingPageLink { get; internal set; }
        public HeaderModel Header { get; internal set; }
        public SeoModel Seo { get; internal set; }
        public NavigationItemModel NavigationItems { get; internal set; }
        public string CurrentFrontpageLink { get; internal set; }
        public IEnumerable<IPublishedContent> ListenBlock { get; internal set; }
        public IEnumerable<Image> GalleryBlock { get; internal set; }
        public IEnumerable<TeaserPageModel> NewestArticlesBlock { get; internal set; }
        public FooterModel Footer { get; internal set; }
        public IEnumerable<CultureUrlModel> GetLanguages { get; internal set; }
    }
}
