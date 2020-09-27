using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LindegaardProductions.Web.Business.Extensions
{
    public static class StringExtensions
    {
        public static string Elipsis(this string value, int maxLength)
        {
            return value.Length <= maxLength ? value : value.Substring(0, maxLength) + "...";
        }
    }
}
