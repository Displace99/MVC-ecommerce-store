using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EStore.Domain.Abstract;
using EStore.Domain.Entities;
using EStore.WebUI.Models;

namespace EStore.WebUI.Controllers
{
    public class ProductController : Controller
    {
        private IProductsRepository repository;
        public int PageSize = 4;

        public ProductController(IProductsRepository repo)
        {
            this.repository = repo;
        }

        public ViewResult List(string category, int page = 1)
        {
            //return View(repository.Products);
            
            //This handles the paging request.  **Update: This is now used as below to take into consideration the Pagination control (Helper)
            //return View(repository.Products.OrderBy(p => p.ProductID).Skip((page - 1) * PageSize).Take(PageSize));

            ProductListViewModel model = new ProductListViewModel
            {
                Products = repository.Products
                    .Where(p => category == null || p.Category == category)
                    .OrderBy(p => p.ProductID)
                    .Skip((page - 1) * PageSize)
                    .Take(PageSize),
                PagingInfo = new PagingInfo
                {
                    CurrentPage = page,
                    ItemsPerPage = PageSize,
                    TotalItems = category == null ? 
                        repository.Products.Count() : 
                        repository.Products.Where(e => e.Category == category).Count()
                },
                CurrentCategory = category
            };

            return View(model);
        }
      
	}
}