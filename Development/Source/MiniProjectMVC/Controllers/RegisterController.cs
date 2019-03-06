
using MiniProjectMVC.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MiniProjectMVC.Controllers
{
    public class RegisterController : Controller
    {
        Training_12Dec18_BangaloreEntities eHSContext = new Training_12Dec18_BangaloreEntities();
        // GET: Register
        public ActionResult Index()
        {
            return View();
        }
        public ActionResult RegisterSeller()
        {
            MultipleModel mymodel = new MultipleModel();

            return View(mymodel);
        }
        [HttpPost]
        public ActionResult RegisterSeller(MultipleModel multipleModel)
        {
            int stateident = 0;
            int cityident = 0;
            
            try
            {
                //State stateId = null;
                //City cityId = null;
                Seller seller = new Seller();
                User user = new User();
                user.UserName = multipleModel.userModel.UserName;
                user.Pasword = multipleModel.userModel.Pasword;
                user.UserType = "Seller";
                eHSContext.Users.Add(user);
                stateident = multipleModel.stateModel.StateId;
                cityident = multipleModel.cityModel.CityId;
                if (stateident != 0 && cityident != 0)
                {                  
                    seller.UserName = multipleModel.userModel.UserName;
                    seller.FirstName = multipleModel.sellerModel.FirstName;
                    seller.LastName = multipleModel.sellerModel.LastName;
                    seller.DateOfBirth = multipleModel.sellerModel.DateOfBirth;
                    seller.PhoneNumber = multipleModel.sellerModel.PhoneNumber;
                    seller.Adress = multipleModel.sellerModel.Adress;
                    seller.EmailId = multipleModel.sellerModel.EmailId;
                    seller.StateId = stateident;
                    seller.CityId = cityident;                    
                    eHSContext.Sellers.Add(seller);
                }

                eHSContext.SaveChanges();
                ViewBag.Message = "Registered Successfully";
                ModelState.Clear();
                return RedirectToAction("LoginUser", "Login");
            }
            catch (DbEntityValidationException e)
            {
                foreach (var eve in e.EntityValidationErrors)
                {
                    Console.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                        eve.Entry.Entity.GetType().Name, eve.Entry.State);
                    foreach (var ve in eve.ValidationErrors)
                    {
                        Console.WriteLine("- Property: \"{0}\", Error: \"{1}\"",
                            ve.PropertyName, ve.ErrorMessage);
                    }
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return View();
        }

        public ActionResult RegisterBuyer()
        {
            MultipleModel mymodel = new MultipleModel();

            return View(mymodel);
        }
        [HttpPost]
        public ActionResult RegisterBuyer(MultipleModel multipleModel)
        {
            try
            {
                Buyer buyer = new Buyer();
                User user = new User();
                user.UserName = multipleModel.userModel.UserName;
                user.Pasword = multipleModel.userModel.Pasword;
                user.UserType = "Buyer";
                eHSContext.Users.Add(user);
                buyer.UserName = multipleModel.userModel.UserName;
                buyer.FirstName = multipleModel.buyerModel.FirstName;
                buyer.LastName = multipleModel.buyerModel.LastName;
                buyer.DateOfBirth = multipleModel.buyerModel.DateOfBirth;
                buyer.PhoneNumber = multipleModel.buyerModel.PhoneNumber;
               
                buyer.EmailId = multipleModel.buyerModel.EmailId;
                eHSContext.Buyers.Add(buyer);

                eHSContext.SaveChanges();
                ViewBag.Message = "Registered Successfully";
                ModelState.Clear();
                return RedirectToAction("LoginUser", "Login");
            }
            catch (DbEntityValidationException e)
            {
                foreach (var eve in e.EntityValidationErrors)
                {
                    Console.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                        eve.Entry.Entity.GetType().Name, eve.Entry.State);
                    foreach (var ve in eve.ValidationErrors)
                    {
                        Console.WriteLine("- Property: \"{0}\", Error: \"{1}\"",
                            ve.PropertyName, ve.ErrorMessage);
                    }
                }

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return View();
        }

    }
}
