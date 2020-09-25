using LindegaardProductions.Web.Models.ModelsBuilder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LindegaardProductions.Web.Models.Helpers
{
    public class TeaserPageModel
    {
        public string Title { get; internal set; }
        public string Description { get; internal set; }
        public Image Image { get; internal set; }
        public string Url { get; internal set; }
        public string Date { get; internal set; }
        public int Id { get; internal set; }
    }
}
