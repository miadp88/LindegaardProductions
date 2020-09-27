using LindegaardProductions.Web.Models.ModelsBuilder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Umbraco.Core.Models.PublishedContent;

namespace LindegaardProductions.Web.Models.Helpers
{
    public class HeaderModel
    {
        public string Title { get; internal set; }
        public string SubHeading { get; internal set; }
        public IPublishedContent Video { get; internal set; }
    }
}
