//Name: PagingInfo.cs
//Author: Joshua Omundson
//Date: 10/18/2014
//Abstract: This class is to control paging of a list of objects.  This class is used in conjunction with PagingHelpers.cs
//Code came from "Pro ASP.NET MVC 5" by Apress
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EStore.WebUI.Models
{
    public class PagingInfo
    {
        public int TotalItems { get; set; }
        public int ItemsPerPage { get; set; }
        public int CurrentPage { get; set; }

        public int TotalPages
        {
            get { return (int)Math.Ceiling((decimal)TotalItems / ItemsPerPage); }
        }
    }
}