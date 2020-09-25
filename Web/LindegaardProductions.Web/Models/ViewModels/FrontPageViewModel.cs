using LindegaardProductions.Web.Models.ModelsBuilder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LindegaardProductions.Web.Models.ViewModels
{
    public class FrontPageViewModel
    {
        public Frontpage CurrentPage { get; internal set; }
        public IEnumerable<Article> News { get; internal set; }
    }
}
