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

        public ProductController(IProductsRepository repo)
        {
            this.repository = repo;
        }

        public ViewResult List()
        {
            return View(repository.Products);
        }
      
	}
}