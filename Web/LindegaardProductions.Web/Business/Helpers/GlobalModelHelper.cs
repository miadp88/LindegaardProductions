using LindegaardProductions.Web.Business.Mappers;
using LindegaardProductions.Web.Business.Services;
using LindegaardProductions.Web.Models.Helpers;
using LindegaardProductions.Web.Models.ModelsBuilder;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Umbraco.Core.Models.PublishedContent;
using Umbraco.Web;

namespace LindegaardProductions.Web.Business.Helpers
{
    public class GlobalModelHelper : IInjected
    {
        public static GlobalModel GetGlobalModel(UmbracoHelper umbracoHelper, IPublishedContent currentPage, LandingPage landingPage)
        {
            string currentFrontPageLink = string.Empty;

            if ((currentPage is LandingPage) == false)
            {
                currentFrontPageLink = currentPage.AncestorOrSelf<Frontpage>().Url;
            }

            var model = new GlobalModel()
            {
                LandingPageLink = landingPage.Url,
                CurrentFrontpageLink = currentFrontPageLink,
                Header = GetHeader(currentPage),
                Seo = GetSeo(currentPage),
                NavigationItems = GetNavigation(landingPage, currentPage, umbracoHelper),
                ListenBlock = GetListenBlock(currentPage, umbracoHelper),
                GalleryBlock = GetGalleryBlock(currentPage, umbracoHelper),
                NewestArticlesBlock = GetNewestArticles(currentPage, umbracoHelper),
            };

            return model;
        }

        private static IEnumerable<TeaserPageModel> GetNewestArticles(IPublishedContent currentPage, UmbracoHelper umbracoHelper)
        {
            var frontPage = currentPage.AncestorOrSelf<Frontpage>();
            if (frontPage == null)
            {
                return null;
            }
            var newsPage = frontPage.Children<Frontpage>().FirstOrDefault();
            var articles = newsPage.Descendants<Article>().OrderByDescending(x => x.CreateDate).Take(5).GetTeaserForPage();

            return articles;
        }

        private static IEnumerable<Image> GetGalleryBlock(IPublishedContent currentPage, UmbracoHelper umbracoHelper)
        {
            if (currentPage is LandingPage)
            {
                return null;
            }
            var frontPage = currentPage.AncestorOrSelf<Frontpage>();
            if (frontPage == null)
            {
                return null;
            }

            var galleryBlock = frontPage.Gallery.OfType<Image>();
            return galleryBlock;

        }

        private static IEnumerable<IPublishedContent> GetListenBlock(IPublishedContent currentPage, UmbracoHelper umbracoHelper)
        {
            if (currentPage is LandingPage)
            {
                return null;
            }
            var frontPage = currentPage.AncestorOrSelf<Frontpage>();
            if (frontPage == null)
            {
                return null;
            }
            var soundFiles = frontPage.SoundFiles;
            return soundFiles;
        }

        private static HeaderModel GetHeader(IPublishedContent currentPage)
        {
            // This is set on the individual page.
            var header = (IHeader)currentPage;
            if (header == null)
            {
                return null;
            }
            return new HeaderModel()
            {
                Title = header.Title,
                SubHeading = header.SubHeading,
                Video = header.Video,
            };
        }

        private static SeoModel GetSeo(IPublishedContent currentPage)
        {
            // for all that has to do with SEO tab.
            var seoPage = (ISEO)currentPage;
            if (seoPage == null)
            {
                return null;
            }

            return new SeoModel()
            {
                Title = seoPage.MetaTitle,
                Description = seoPage.MetaDescription,
                Image = seoPage.MetaImage != null ? seoPage.MetaImage.Url(mode: UrlMode.Absolute) : string.Empty,
                PageUrl = currentPage.Url(mode: UrlMode.Absolute),
            };
        }

        private static NavigationItemModel GetNavigation(LandingPage home, IPublishedContent currentPage, UmbracoHelper umbracoHelper)
        {
            // landing page
            // Current Front page
            // pages under the current frontpage
            IEnumerable<IPublishedContent> children = null;
            IEnumerable<NavigationItemModel> navChildren = null;
            NavigationItemModel navigation = null;
            if (currentPage is Frontpage)
            {
                children = currentPage.Children;

                navChildren = NavigationItemMapper.Map<NavigationItemModel>(children, currentPage, umbracoHelper);
                navigation = new NavigationItemModel() { Children = navChildren, Url = currentPage.Url, Name = currentPage.Name, Active = true };
            }
            else if(currentPage is LandingPage)
            {
                navigation = new NavigationItemModel() { Children = null, Url = home.Url, Name = home.Title };
            }
            else
            {
                var frontPage = currentPage.AncestorsOrSelf<Frontpage>().FirstOrDefault();
                children = frontPage.Children;

                navChildren = NavigationItemMapper.Map<NavigationItemModel>(children, currentPage, umbracoHelper);
                navigation = new NavigationItemModel() { Children = navChildren, Url = frontPage.Url, Name = frontPage.Title };
            }

            return navigation;
        }
    }
}
