using LindegaardProductions.Web.Business.Component;
using LindegaardProductions.Web.Business.Services;
using Umbraco.Core;
using Umbraco.Core.Composing;
using Umbraco.Web;
using Umbraco.Web.Dashboards;

namespace LindegaardProductions.Web.Business.Composer
{
    public class SystemComposer : IUserComposer
    {
        public void Compose(Composition composition)
        {
            // Register "system" specific components, meaning basic things.

            composition.Components().Append<ImagePreprocessingComponent>();
            composition.Dashboards().Remove<ContentDashboard>(); // removes getting started dashboard
            composition.RegisterAuto<IInjected>(); // So any classes that implement IInjected, will be added.
        }
    }
}
