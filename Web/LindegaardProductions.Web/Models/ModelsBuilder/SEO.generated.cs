//------------------------------------------------------------------------------
// <auto-generated>
//   This code was generated by a tool.
//
//    Umbraco.ModelsBuilder v8.6.4
//
//   Changes to this file will be lost if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Web;
using Umbraco.Core.Models;
using Umbraco.Core.Models.PublishedContent;
using Umbraco.Web;
using Umbraco.ModelsBuilder.Embedded;

namespace LindegaardProductions.Web.Models.ModelsBuilder
{
	// Mixin Content Type with alias "sEO"
	/// <summary>SEO</summary>
	public partial interface ISEO : IPublishedElement
	{
		/// <summary>Meta Description</summary>
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder", "8.6.4")]
		string MetaDescription { get; }

		/// <summary>Meta Image</summary>
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder", "8.6.4")]
		global::Umbraco.Core.Models.PublishedContent.IPublishedContent MetaImage { get; }

		/// <summary>MetaTitle</summary>
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder", "8.6.4")]
		string MetaTitle { get; }
	}

	/// <summary>SEO</summary>
	[PublishedModel("sEO")]
	public partial class SEO : PublishedElementModel, ISEO
	{
		// helpers
#pragma warning disable 0109 // new is redundant
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder", "8.6.4")]
		public new const string ModelTypeAlias = "sEO";
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder", "8.6.4")]
		public new const PublishedItemType ModelItemType = PublishedItemType.Content;
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder", "8.6.4")]
		public new static IPublishedContentType GetModelContentType()
			=> PublishedModelUtility.GetModelContentType(ModelItemType, ModelTypeAlias);
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder", "8.6.4")]
		public static IPublishedPropertyType GetModelPropertyType<TValue>(Expression<Func<SEO, TValue>> selector)
			=> PublishedModelUtility.GetModelPropertyType(GetModelContentType(), selector);
#pragma warning restore 0109

		// ctor
		public SEO(IPublishedElement content)
			: base(content)
		{ }

		// properties

		///<summary>
		/// Meta Description: A short description of the content of the page. Will be shown on google and facebook etc. As well on cards on the website.
		///</summary>
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder", "8.6.4")]
		[ImplementPropertyType("metaDescription")]
		public string MetaDescription => GetMetaDescription(this);

		/// <summary>Static getter for Meta Description</summary>
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder", "8.6.4")]
		public static string GetMetaDescription(ISEO that) => that.Value<string>("metaDescription");

		///<summary>
		/// Meta Image: The image of the page, will be seen on cards, and when sharing the page on social media, or searched on google
		///</summary>
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder", "8.6.4")]
		[ImplementPropertyType("metaImage")]
		public global::Umbraco.Core.Models.PublishedContent.IPublishedContent MetaImage => GetMetaImage(this);

		/// <summary>Static getter for Meta Image</summary>
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder", "8.6.4")]
		public static global::Umbraco.Core.Models.PublishedContent.IPublishedContent GetMetaImage(ISEO that) => that.Value<global::Umbraco.Core.Models.PublishedContent.IPublishedContent>("metaImage");

		///<summary>
		/// MetaTitle: Title that will be seen on google or facebook etc. when sharing the page. And as the title in the tab in your browser.
		///</summary>
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder", "8.6.4")]
		[ImplementPropertyType("metaTitle")]
		public string MetaTitle => GetMetaTitle(this);

		/// <summary>Static getter for MetaTitle</summary>
		[global::System.CodeDom.Compiler.GeneratedCodeAttribute("Umbraco.ModelsBuilder", "8.6.4")]
		public static string GetMetaTitle(ISEO that) => that.Value<string>("metaTitle");
	}
}
