using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EStore.Domain.Abstract;
using EStore.Domain.Entities;

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

        public ViewResult List(int page = 1)
        {
            //return View(repository.Products);
            
            //This handles the paging request.  
            return View(repository.Products.OrderBy(p => p.ProductID).Skip((page - 1) * PageSize).Take(PageSize));
        }
      
	}
}