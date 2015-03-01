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
        private IOrderProcessor orderProcessor;

        public CartController(IProductsRepository repo, IOrderProcessor proc)
        {
            repository = repo;
            orderProcessor = proc;
        }

        //Get
        public ViewResult Index(Cart cart, string returnUrl)
        {
            return View (new CartIndexViewModel{
                //Cart = GetCart(),
                ReturnUrl = returnUrl,
                Cart = cart
            });
        }

        //Adds an item to the cart and shows shopping cart page.
        [HttpPost]
        public RedirectToRouteResult AddToCart(Cart cart, int productID, string returnUrl)
        {
            //Finds the product by the product id.
            Product product = repository.Products.FirstOrDefault(p => p.ProductID == productID);

            //Integrity check.  If the item exists then add one to the cart, otherwise do nothing.
            if (product != null)
            {
                //GetCart().AddItem(product, 1);
                cart.AddItem(product, 1);
            }

            //Send user to the shopping cart with a return url of where they were when they
            //clicked the "Add to cart" button.
            return RedirectToAction("Index", new { returnUrl });
        }

        //Removes an item from the cart and shows the shopping cart page.
        [HttpPost]
        public RedirectToRouteResult RemoveFromCart(Cart cart, int productID, string returnUrl)
        {
            //Finds the product by the product id.
            Product product = repository.Products.FirstOrDefault(p => p.ProductID == productID);

            //Integrity check.  If the item exists the remove, otherwise do nothing.
            if (product != null)
            {
                //GetCart().RemoveLine(product);
                cart.RemoveLine(product);
            }

            //Sends user to the shopping cart page with a return url of where they were when they
            //clicked the "remove from cart" button.
            return RedirectToAction("Index", new { returnUrl });
        }

        public PartialViewResult Summary(Cart cart)
        {
            return PartialView(cart);
        }

        public ViewResult Checkout()
        {
            return View(new ShippingDetails());
        }

        [HttpPost]
        public ViewResult Checkout(Cart cart, ShippingDetails shippingDetails)
        {
            //If there is nothing in the cart, do not let them checkout.
            if (cart.Lines.Count() == 0)
            {
                ModelState.AddModelError("", "Sorry, your cart is empty!");
            }

            if (ModelState.IsValid)
            {
                orderProcessor.ProcessOrder(cart, shippingDetails);
                cart.Clear();
                return View("Completed");
            }
            else
            {
                return View(shippingDetails);
            }
        }

        //Gets current cart from session state. //No longer needed b/c we are now using model binding.
        //private Cart GetCart()
        //{
        //    //Gets cart from session state
        //    Cart cart = (Cart)Session["Cart"];

        //    //If there is no cart object in session state create one and 
        //    //save it to session state.
        //    if (cart == null)
        //    {
        //        cart = new Cart();
        //        Session["Cart"] = cart;
        //    }

        //    return cart;
        //}
	}
}