using Model;
using Repository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebProject.Models;

namespace WebProject.Controllers
{
    public class CartController : Controller
    {
        private DBManager db = new DBManager();

        // GET: Cart
        public ActionResult Index()
        {
            var itemIds = ShoppingCart.GetItemsInCart();

            var products = db.WeedRepository.GetWeed()
                .Where(weed => itemIds.Contains(weed.WeedId))
                .ToList();

            return View(products);
        }

        public ActionResult Remove(int id)
        {
            ShoppingCart.RemoveItemFromCart(id);
            return RedirectToAction("Index");
        }

        public ActionResult AddToCart(int id)
        {
            ShoppingCart.AddItemToCart(id);
            return RedirectToAction("Index", "Weed");
        }

        public ActionResult Checkout()
        {
            var itemIds = ShoppingCart.GetItemsInCart();

            foreach (var id in itemIds)
                db.WeedRepository.DeleteWeed(id);

            db.Save();
            
            ShoppingCart.ClearShoppingCart();
            return RedirectToAction("Index", "Weed");
        }
    }
}