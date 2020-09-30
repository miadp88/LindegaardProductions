using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LindegaardProductions.Web.Models.Helpers
{
    public class CultureUrlModel
    {
        public string Culture { get; set; }

        public string Url { get; set; }

        public string Name => this.Culture;

        public bool Current { get; set; }
    }
}
