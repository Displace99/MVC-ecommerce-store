//Name: ProductListViewModel.cs
//Author: Joshua Omundson
//Date: 10/18/2014
//Abstract: This is a view model that is for a Product List with Pagination.
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using EStore.Domain.Entities;

namespace EStore.WebUI.Models
{
    public class ProductListViewModel
    {
        public IEnumerable<Product> Products { get; set; }
        public PagingInfo PagingInfo { get; set; }
    }
}