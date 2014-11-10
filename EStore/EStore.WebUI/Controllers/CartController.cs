using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EStore.Domain.Entities;
using EStore.Domain.Abstract;
using EStore.WebUI.Models;

namespace EStore.WebUI.Controllers
{
    public class CartController : Controller
    {
        private IProductsRepository repository;

        public CartController(IProductsRepository repo)
        {
            repository = repo;
        }

        //Get
        public ViewResult Index(string returnUrl)
        {
            return View (new CartIndexViewModel{
                Cart = GetCart(),
                ReturnUrl = returnUrl
            });
        }

        //Adds an item to the cart and shows shopping cart page.
        [HttpPost]
        public RedirectToRouteResult AddToCart(int productID, string returnUrl)
        {
            //Finds the product by the product id.
            Product product = repository.Products.FirstOrDefault(p => p.ProductID == productID);

            //Integrity check.  If the item exists then add one to the cart, otherwise do nothing.
            if (product != null)
            {
                GetCart().AddItem(product, 1);
            }

            //Send user to the shopping cart with a return url of where they were when they
            //clicked the "Add to cart" button.
            return RedirectToAction("Index", new { returnUrl });
        }

        //Removes an item from the cart and shows the shopping cart page.
        [HttpPost]
        public RedirectToRouteResult RemoveFromCart(int productID, string returnUrl)
        {
            //Finds the product by the product id.
            Product product = repository.Products.FirstOrDefault(p => p.ProductID == productID);

            //Integrity check.  If the item exists the remove, otherwise do nothing.
            if (product != null)
            {
                GetCart().RemoveLine(product);
            }

            //Sends user to the shopping cart page with a return url of where they were when they
            //clicked the "remove from cart" button.
            return RedirectToAction("Index", new { returnUrl });
        }

        //Gets current cart from session state.
        private Cart GetCart()
        {
            //Gets cart from session state
            Cart cart = (Cart)Session["Cart"];

            //If there is no cart object in session state create one and 
            //save it to session state.
            if (cart == null)
            {
                cart = new Cart();
                Session["Cart"] = cart;
            }

            return cart;
        }
	}
}