using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using LindegaardProductions.Web.Business.Services;
using Newtonsoft.Json;
using Umbraco.Web;

namespace LindegaardProductions.Web.Business.Helpers
{
    public class CaptchaHelper : IInjected
    {
        private readonly UmbracoHelper umbracoHelper;

        public CaptchaHelper(UmbracoHelper umbracoHelper)
        {
            this.umbracoHelper = umbracoHelper;
        }

        public string AuthenticateRecaptcha(string response)
        {
            string secretKey = umbracoHelper.GetDictionaryValue("Google Captcha Secret Key");

            var webClient = new WebClient();
            var reply =
                webClient.DownloadString(
                    string.Format("https://www.google.com/recaptcha/api/siteverify?secret={0}&response={1}",
                secretKey, response));
            return reply;
        }
    }
    public class CaptchaResponse
    {
        [JsonProperty("success")]
        public bool Success { get; set; }

        [JsonProperty("error-codes")]
        public List<string> ErrorCodes { get; set; }
    }
}