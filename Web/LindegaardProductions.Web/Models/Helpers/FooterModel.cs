using LindegaardProductions.Web.Models.ModelsBuilder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;

namespace LindegaardProductions.Web.Models.Helpers
{
    public class FooterModel
    {
        public IEnumerable<FooterContent> Links { get; internal set; }
        public IHtmlString About { get; internal set; }
        public IEnumerable<IconText> ContactInfo { get; internal set; }
        public IEnumerable<IconLink> SoMe { get; internal set; }
    }
}
