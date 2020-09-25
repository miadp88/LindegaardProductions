using LindegaardProductions.Web.Business.Helpers;
using LindegaardProductions.Web.Models.ModelsBuilder;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using Umbraco.Core.Logging;
using Umbraco.Web;
using Umbraco.Web.Mvc;

namespace LindegaardProductions.Web.Controllers.Surface
{
    public class ContactSurfaceController : SurfaceController
    {
        private readonly ILogger logger;
        private readonly UmbracoHelper umbracoHelper;
        private readonly CaptchaHelper captchaHelper;

        public ContactSurfaceController(ILogger logger, UmbracoHelper umbracoHelper, CaptchaHelper captchaHelper)
        {
            this.logger = logger;
            this.umbracoHelper = umbracoHelper;
            this.captchaHelper = captchaHelper;
        }

        public ActionResult SendMail(string name, string email, string message, string country, string pageId)
        {
            try
            {
                string reply = captchaHelper.AuthenticateRecaptcha(Request["g-recaptcha-response"]);
                var captchaResponse = JsonConvert.DeserializeObject<CaptchaResponse>(reply);

                if (captchaResponse.Success)
                {
                    var contactPage = umbracoHelper.Content(pageId).AncestorOrSelf<Contact>();
                    var body = contactPage.EmailTemplate.ToString()
                        .Replace("##name##", name)
                        .Replace("##email##", email)
                        .Replace("##country##", message)
                        .Replace("##message##", message);

                    MailHelper.SendMail("noreply@lindegaardproduction.dk", contactPage.ReceiverEmail, "Besked fra kontaktformular", body, true);
                    return new HttpStatusCodeResult(200);
                }
                else
                {
                    return new HttpStatusCodeResult(500);
                }
            }
            catch (Exception ex)
            {
                logger.Error<ContactSurfaceController>($"Contactform message failed to send. Error: {ex}");
                return new HttpStatusCodeResult(500);
            }
        }
    }
}
