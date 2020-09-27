using LindegaardProductions.Web.Models.ModelsBuilder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LindegaardProductions.Web.Models.ViewModels
{
    public class NewsViewModel
    {
        public News CurrentPage { get; internal set; }
        public IEnumerable<Article> Children { get; internal set; }
        public IEnumerable<string> YearsAvailable { get; internal set; }
        public int ActiveYear { get; internal set; }
    }
}
