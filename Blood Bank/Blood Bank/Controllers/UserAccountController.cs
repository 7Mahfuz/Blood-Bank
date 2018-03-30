using Blood_Bank.Logics;
using DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Blood_Bank.Controllers
{
    public class UserAccountController : Controller
    {
        private UnitOfWork uow = null;
        public UserAccountController()
        {
            uow = new UnitOfWork();
        }
        public UserAccountController(UnitOfWork _uow)
        {
            this.uow = _uow;
        }
        // GET: UserAccount
        public ActionResult Login()
        {
            
            return View();
        }
        [HttpPost]
        public ActionResult Login(Login model)
        {
            int a=uow.Repository<User>().Count(x => x.UserName == model.UserName);
            if(a>0)
            {
                User user = uow.Repository<User>().GetModel(x=>x.UserName==model.UserName);
                if (model.Password == user.Password)
                {
                    Session["MemberName"] = model.UserName;
                    Response.Cookies["MemberName"].Value = model.UserName;
                    return RedirectToAction("Index", "Home");
                }
                else return View(model);
            }
            else return View(model);

            
        }


        public ActionResult Register()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Register(Register model)
        {
            int a=uow.Repository<User>().Count(x => x.UserName == model.UserName);
            if(a>0)
            {
                ViewBag.Exist = "This User Name Already Exist";
                return View(model);
            }


            if (ModelState.IsValid)
            {
                if (model.Password == model.Confirmpassword)
                {
                    User user = new User();
                    user.Name = "Not Added";
                    user.UserName = model.UserName;
                    user.Email = model.Email;
                    user.Blood = model.Blood;
                    user.BirthDate = model.Birthdate;
                    user.PhoneNumber = "Not Added";
                    user.OtherNumber = "Not Added";
                    user.Relation = "Not Added";
                    user.PreferedArea = "Not Added";
                    user.LastDonated = null;
                    user.Password = model.Password;

                    uow.Repository<User>().InsertModel(user);
                    uow.Save();
                    Session["MemberName"] = user.UserName;
                    Response.Cookies["MemberName"].Value = user.UserName;
                   // Response.Cookies["MemberRole"].Value = "User";
                    return RedirectToAction("Index", "Home");
                                        
                }
                return View(model);
            }
            else return View(model);
            
        }

        public ActionResult Logout()
        {
            Session["MemberName"] = null;
            Response.Cookies["MemberName"].Value = null;
            return RedirectToAction("Index", "Home");
        }

    }
}