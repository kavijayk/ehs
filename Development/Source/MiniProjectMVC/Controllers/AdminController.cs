using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MiniProjectMVC.Controllers
{
    public class AdminController : Controller
    {
        Training_12Dec18_BangaloreEntities eHSContext = new Training_12Dec18_BangaloreEntities();
        // GET: Admin
        public ActionResult Index()
        {
            return View(eHSContext.Properties.ToList());
        }

        public ActionResult VerifyProperty(int Id)
        {
            Property property = eHSContext.Properties.FirstOrDefault(p => p.PropertyId == Id);

            return View(property);
        }
        [HttpPost]
        public ActionResult VerifyProperty(Property property)
        {
            Property prop = eHSContext.Properties.FirstOrDefault(p => p.PropertyId == property.PropertyId);

            prop.IsActive = true;
            eHSContext.SaveChanges();
            return View(prop);
        }

        public ActionResult DeActivateProperty(int Id)
        {
            Property property = eHSContext.Properties.FirstOrDefault(p => p.PropertyId == Id);

            return View(property);
        }
        [HttpPost]
        public ActionResult DeActivateProperty(Property property)
        {
            Property prop = eHSContext.Properties.FirstOrDefault(p => p.PropertyId == property.PropertyId);

            prop.IsActive = false;
            eHSContext.SaveChanges();
            return View(prop);
        }


        public ActionResult Delete(int Id)
        {
            Property property = eHSContext.Properties.FirstOrDefault(p => p.PropertyId == Id);
            eHSContext.Properties.Remove(property);
            eHSContext.SaveChanges();
            return RedirectToAction("Index");
        }
      
    }
}