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
            TagBuilder[] builders = new TagBuilder[] { new TagBuilder("input"), new TagBuilder("button") };
            builders[0].MergeAttribute("type", "type");
            builders[0].MergeAttribute("name", "search");
            builders[0].MergeAttribute("class", "form-control");
            builders[0].MergeAttribute("placeholder", placeholder);
            builders[0].MergeAttribute("id", "searchtext");

            builders[1].MergeAttribute("type", "submit");
            builders[1].MergeAttribute("name", "search");
            builders[1].MergeAttribute("class", "btn btn-default");
            builders[1].SetInnerText("検索");

            return MvcHtmlString.Create(
                String.Format(
                    "<div class=\"input-group\">" +
                    builders[0].ToString(TagRenderMode.StartTag) +
                    "</div>" + builders[1].ToString(TagRenderMode.Normal))
                );
        }
    }
}