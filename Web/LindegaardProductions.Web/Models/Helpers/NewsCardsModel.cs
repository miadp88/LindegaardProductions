using LindegaardProductions.Web.Models.ModelsBuilder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LindegaardProductions.Web.Models.Helpers
{
    public class NewsCardsModel
    {
        public IEnumerable<Article> Cards { get; internal set; }
        public IEnumerable<string> YearsAvailable { get; internal set; }
        public int ActiveYear { get; internal set; }
        public int PageId { get; internal set; }
    }
}
