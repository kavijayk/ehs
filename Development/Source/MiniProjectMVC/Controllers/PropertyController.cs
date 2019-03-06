using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MiniProjectMVC.Controllers
{
    public class PropertyController : Controller
    {
        Training_12Dec18_BangaloreEntities eHSContext = new Training_12Dec18_BangaloreEntities();
        // GET: Property
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult Create()
        {
            return View(eHSContext.Properties.ToList());
        }
        public ActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Add(Property property)
        {
            try
            {
                property.IsActive = false;
                string username=Session["userName"].ToString();
                Seller seller = eHSContext.Sellers.FirstOrDefault(p => p.UserName == username);
                property.SellerId = seller.SellerId;
                eHSContext.Properties.Add(property);
                eHSContext.SaveChanges();
                ViewBag.Message = "Added successfully!";
                ModelState.Clear();
                return View();
            }
            catch(Exception)
            {
                ViewBag.message = "Error occurred";
                return View();
            }
            
        }


        public ActionResult Edit(int id)
        {
            Property property = eHSContext.Properties.FirstOrDefault(p => p.PropertyId == id);
            return View(property);
        }
        [HttpPost]
        public ActionResult Edit(Property property)
        {
            Property properties = eHSContext.Properties.FirstOrDefault(p => p.PropertyId == property.PropertyId);
            properties.PropertyName = property.PropertyName;
            properties.PropertyType = property.PropertyType;
            properties.Descript = property.Descript;
            properties.Adress = property.Adress;
            properties.PriceRange = property.PriceRange;
            properties.InitialDeposit = property.InitialDeposit;
            properties.LandMark = property.LandMark;
            properties.IsActive = property.IsActive;
            properties.SellerId = property.SellerId;
            eHSContext.SaveChanges();
            return View();
        }
        public ActionResult Details(int id)
        {
            Property property = eHSContext.Properties.FirstOrDefault(p => p.PropertyId == id);
            return View(property);
        }
        [HttpPost]
        public ActionResult Details(Property property)
        {
            Property properties = eHSContext.Properties.FirstOrDefault(p => p.PropertyId == property.PropertyId);
            properties.PropertyName = property.PropertyName;
            properties.PropertyType = property.PropertyType;
            properties.Descript = property.Descript;
            properties.Adress = property.Adress;
            properties.PriceRange = property.PriceRange;
            properties.InitialDeposit = property.InitialDeposit;
            properties.LandMark = property.LandMark;
            properties.IsActive = property.IsActive;
            properties.SellerId = property.SellerId;
            eHSContext.SaveChanges();
            return View();
        }
    }
}