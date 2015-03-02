using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EStore.Domain.Abstract;
using EStore.Domain.Entities;

namespace EStore.WebUI.Controllers
{
    public class AdminController : Controller
    {
        private IProductsRepository repository;

        public AdminController(IProductsRepository repo)
        {
            repository = repo;
        }

        //
        // GET: /Admin/
        public ViewResult Index()
        {
            return View(repository.Products);
        }

        //
        // GET: /Admin/Edit/5
        public ViewResult Edit(int productID)
        {
            Product product = repository.Products.FirstOrDefault(x => x.ProductID == productID);
            return View(product);
        }

        //
        // POST: /Admin/Edit/5
        [HttpPost]
        public ActionResult Edit(Product product)
        {
            if (ModelState.IsValid)
            {
                repository.SaveProduct(product);
                TempData["message"] = string.Format("{0} has been saved", product.Name);
                return RedirectToAction("Index");
            }
            else
            {
                //There is something wrong with the data values
                return View(product);
            }
        }
	}
}