using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Target19_Relationship.Models
{
    public static class ViewHelpers
    {
        public static IHtmlString SearchBox(this HtmlHelper helper, string placeholder)
        {
            TagBuilder builder = new TagBuilder("input");
            builder.MergeAttribute("type", "search");
            builder.MergeAttribute("name", "search");
            builder.MergeAttribute("class", "form-control");
            builder.MergeAttribute("placeholder", placeholder);
            builder.MergeAttribute("id", "searchtext");

            return MvcHtmlString.Create(
                String.Format(
                    builder.ToString(TagRenderMode.StartTag)
                ));
        }

        public static IHtmlString AutoCompleteBox(this HtmlHelper helper, string target, string placeholper)
        {
            TagBuilder builder = new TagBuilder("input");
            builder.MergeAttribute("type", "search");
            builder.MergeAttribute("name", target);
            builder.MergeAttribute("class", "form-control");
            builder.MergeAttribute("placeholder", placeholper);
            builder.MergeAttribute("id", "autocomplete");

            return MvcHtmlString.Create(
                String.Format(
                    builder.ToString(TagRenderMode.StartTag)));
        }
    }
}