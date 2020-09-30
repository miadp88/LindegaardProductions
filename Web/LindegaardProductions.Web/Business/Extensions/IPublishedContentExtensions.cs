using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Umbraco.Core.Models.PublishedContent;
using LindegaardProductions.Web.Models.ModelsBuilder;

namespace LindegaardProductions.Web.Business.Extensions
{
    public static class IPublishedContentExtensions
    {
        /// <summary>
        /// Get the url of the image, without any cropping
        /// </summary>
        /// <param name="image"></param>
        /// <param name="fallback"></param>
        /// <returns></returns>
        public static string GetImageUrlOrDefault(this IPublishedContent image, string fallback = "/Content/Media/placeholder.png")
        {
            if (image != null)
            {
                if (image is Image img)
                {
                    return img.Url;
                }
            }
            return fallback;
        }

        /// <summary>
        /// Get the alt text for the image.
        /// </summary>
        /// <param name="image"></param>
        /// <returns></returns>
        public static string GetImageAltText(this IPublishedContent image)
        {
            if (image != null)
            {
                if (image is Image img)
                {
                    if (img != null)
                    {
                        return img.Alt;
                    }
                }
            }
            return string.Empty;
        }
    }
}
