using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MiniProjectMVC.Controllers
{
    public class BuyerController : Controller
    {
        Training_12Dec18_BangaloreEntities eHSContext = new Training_12Dec18_BangaloreEntities();
        // GET: Buyer
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult ViewProperties()
        {
            return View(eHSContext.Properties.ToList());
        }      
        public ActionResult AddToCart(int id)
        {
            Cart cart = new Cart();
            cart.PropertyId = id;
            string test = Session["userName"].ToString();
            cart.BuyerId = eHSContext.Buyers.Where(x => x.UserName == test).Select(x => x.BuyerId).FirstOrDefault();

            eHSContext.Carts.Add(cart);
            eHSContext.SaveChanges();
            ViewBag.Message = "Added Successfully";
            ModelState.Clear();
            return RedirectToAction("DisplayCart", "Buyer");
        }

        public ActionResult DisplayCart()
        {
            List<Cart> carts = eHSContext.Carts.ToList();
            List<Property> CartProperties = null;
            foreach (var prop in carts)
            {
                CartProperties = eHSContext.Properties.Where(p => p.PropertyId == prop.PropertyId).ToList();
            }
            return View(CartProperties);
        }
        //public ActionResult DeleteCart(int Id)
        //{
        //    Cart cartToDelete = eHSContext.Carts.FirstOrDefault(c => c.CartId == Id);
        //    eHSContext.Carts.Remove(cartToDelete);
        //    eHSContext.SaveChanges();
        //    return RedirectToAction("DisplayCart");
        //}

    }
}