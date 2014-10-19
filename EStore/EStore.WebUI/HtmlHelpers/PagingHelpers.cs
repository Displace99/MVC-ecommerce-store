//Name: PagingHelpers.cs
//Author: Joshua Omundson
//Date: 10/18/2014
//Abstract: This is an extention method that creates a pagination element.  This came from "Pro ASP.NET MVC 5" from Apress.
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using EStore.WebUI.Models;

namespace EStore.WebUI.HtmlHelpers
{
    public static class PagingHelpers
    {
        public static MvcHtmlString PageLinks(this HtmlHelper html, PagingInfo pagingInfo, Func<int, string> pageUrl)
        {
            StringBuilder result = new StringBuilder();

            for (int i = 1; i <= pagingInfo.TotalPages; i++)
            {
                TagBuilder tag = new TagBuilder("a");
                tag.MergeAttribute("href", pageUrl(i));
                tag.InnerHtml = i.ToString();

                if (i == pagingInfo.CurrentPage)
                {
                    tag.AddCssClass("selected");
                    tag.AddCssClass("btn-primary");
                }
                tag.AddCssClass("btn btn-default"); //Why is this after the if statement?

                result.Append(tag.ToString());
            }

            return MvcHtmlString.Create(result.ToString());

        }
    }
}