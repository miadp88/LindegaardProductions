using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Web.Mvc.Html;

namespace LindegaardProductions.Web.Business.Extensions
{
    public static class HtmlHelperExtensions
    {
        // Originally snagged from: https://github.com/umbraco/Umbraco-CMS/blob/91c52cffc8b7c70dc956f6c6610460be2d1adc51/src/Umbraco.Web/GridTemplateExtensions.cs
        public static MvcHtmlString GetGridHtml(this HtmlHelper html, JToken gridData, string framework = "bootstrap3")
        {
            var view = "Grid/" + framework;

            if (gridData == null)
            {
                return new MvcHtmlString(string.Empty);
            }

            return html.Partial(view, gridData);
        }
    }
}
