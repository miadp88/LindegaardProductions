﻿using LindegaardProductions.Web.Models.Helpers;
using System.Globalization;
using System.Web.Mvc;
using Umbraco.Web.Mvc;

namespace LindegaardProductions.Web.Business.ViewPages
{
    public abstract class AbstractViewPage : AbstractViewPage<dynamic>
    {
        
    }
    public abstract class AbstractViewPage<TModel> : UmbracoViewPage<TModel>
    {
        internal const string GlobalModelViewDataKey = "global";

        public GlobalModel Global { get; private set; }
        public string CurrentLanguageCode => CultureInfo.CurrentUICulture.TwoLetterISOLanguageName;

        protected override void SetViewData(ViewDataDictionary viewData)
        {
            if (viewData.TryGetValue(GlobalModelViewDataKey, out var globalObj) && globalObj is GlobalModel globalModel)
            {
                this.Global = globalModel;
            }
            base.SetViewData(viewData);
        }
    }
}