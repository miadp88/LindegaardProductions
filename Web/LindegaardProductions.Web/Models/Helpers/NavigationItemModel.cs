using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LindegaardProductions.Web.Models.Helpers
{
    public class NavigationItemModel
    {
        public bool Active { get; set; }
        public string Name { get; set; }
        public bool IsHidden { get; set; }
        public string Url { get; set; }
        public IEnumerable<NavigationItemModel> Children { get; internal set; }
    }
}
