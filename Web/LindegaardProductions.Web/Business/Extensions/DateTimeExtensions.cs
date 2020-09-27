using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LindegaardProductions.Web.Business.Extensions
{
    public static class DateTimeExtensions
    {
        public static string StandardDateTimeFormat(this DateTime dateTime)
        {
            return dateTime.ToString("dddd, dd MMMM yyyy");
        }
        public static string StandardDateTimeFormat(this DateTime dateTime, CultureInfo cultureInfo)
        {
            return dateTime.ToString("dddd, dd MMMM yyyy", cultureInfo);
        }
        public static string StandardDateTimeFormatWithTime(this DateTime dateTime, CultureInfo cultureInfo)
        {
            return dateTime.ToString("dddd, dd MMMM yyyy kl. HH:mm", cultureInfo);
        }
        public static string StandardDateTimeFormatWithTime(this DateTime dateTime)
        {
            return dateTime.ToString("dddd, dd MMMM yyyy kl. HH:mm");
        }
    }
}
