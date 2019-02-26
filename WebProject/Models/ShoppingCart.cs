using System.Collections.Generic;
using System.Web;

namespace WebProject.Models
{
    public static class ShoppingCart
    {
        public static void AddItemToCart(int id)
        {
            var userCart = HttpContext.Current.Session["ShoppingCart"] as List<int> ?? new List<int>();
            var globalCart = HttpContext.Current.Application["ShoppingCart"] as List<int> ?? new List<int>();

            userCart.Add(id);
            globalCart.Add(id);

            HttpContext.Current.Session["ShoppingCart"] = userCart;
            HttpContext.Current.Application["ShoppingCart"] = globalCart;
        }

        public static void RemoveItemFromCart(int id)
        {
            var userCart = HttpContext.Current.Session["ShoppingCart"] as List<int> ?? new List<int>();
            var globalCart = HttpContext.Current.Application["ShoppingCart"] as List<int> ?? new List<int>();

            userCart.Remove(id);
            globalCart.Remove(id);

            HttpContext.Current.Session["ShoppingCart"] = userCart;
            HttpContext.Current.Application["ShoppingCart"] = globalCart;
        }

        public static void ClearShoppingCart()
        {
            var userCart = HttpContext.Current.Session["ShoppingCart"] as List<int> ?? new List<int>();
            var globalCart = HttpContext.Current.Application["ShoppingCart"] as List<int> ?? new List<int>();

            foreach (var item in userCart)
            {
                globalCart.Remove(item);
            }

            HttpContext.Current.Session.Remove("ShoppingCart");
            HttpContext.Current.Application["ShoppingCart"] = globalCart;
        }

        public static List<int> GetItemsInCart()
        {
            return HttpContext.Current.Session["ShoppingCart"] as List<int> ?? new List<int>();
        }

        public static List<int> GetAllItemsInAllShoppingCarts()
        {
            return HttpContext.Current.Application["ShoppingCart"] as List<int> ?? new List<int>();
        }
    }
}