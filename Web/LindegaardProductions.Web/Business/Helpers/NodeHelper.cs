using LindegaardProductions.Web.Business.Services;
using LindegaardProductions.Web.Models.ModelsBuilder;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using Umbraco.Core.Models;
using Umbraco.Web;

namespace LindegaardProductions.Web.Business.Helpers
{
	public class NodeHelper : IInjected
	{
		private readonly HttpContextBase httpContext;
		private readonly UmbracoHelper umbracoHelper;
		public NodeHelper(
			HttpContextBase httpContext,
			UmbracoHelper umbracoHelper)
		{
			this.httpContext = httpContext;
			this.umbracoHelper = umbracoHelper;
		}
		public LandingPage GetLandingpage()
		{
			Uri url = this.httpContext.Request.Url;

			var registeredDomains = Umbraco.Core.Composing.Current.Services.DomainService.GetAll(false).ToList();

			var domains = (from d in registeredDomains
						   where d.DomainName.StartsWith($"{url.Scheme}://{url.Authority}") ||
						   d.DomainName.StartsWith($"{url.Scheme}://{url.Host}") ||
						   d.DomainName.Contains(url.Authority) ||
						   d.DomainName.Contains(url.Host)
						   select d).ToList();

			var domain = domains.FirstOrDefault();

			return this.GetLandingpage(domain);
		}

		public LandingPage GetLandingpage(IDomain domain)
		{
			if (domain == null || domain.RootContentId.HasValue == false)
			{
				return null;
			}
			else
			{
				var content = this.umbracoHelper.Content(domain.RootContentId.Value) as LandingPage;
				return content;
			}
		}
	}
}
