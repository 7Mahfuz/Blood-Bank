
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Blood_Bank.Logics;
using DataLayer;

namespace Blood_Bank.Controllers
{
      public class UserController : Controller
    {
        
        private UnitOfWork uow = null;
        public UserController()
        {
            uow = new UnitOfWork();
        }
        public UserController(UnitOfWork _uow)
        {
            this.uow = _uow;
        }
        // GET: User
        public ActionResult UserDetail()
        {
            if (Session["UserName"] != null)
            {
                string Username = Session["UserName"].ToString();
                User user = uow.Repository<User>().GetModel(x => x.UserName == Username);
                return View(user);
            }
            else return RedirectToAction("Login", "UserAccount");
        }

        public ActionResult Update()
        {
            string Username = Session["UserName"].ToString();
            User user = uow.Repository<User>().GetModel(x => x.UserName == Username);
            return View(user);
        }
        [HttpPost]
        public ActionResult Update(int id,User model)
        {
            User user= uow.Repository<User>().GetModelById(id);
            string pass = user.Password;
            user = model;
            user.Password = pass;
            //BloodBankContext context = new BloodBankContext();
            //context.Entry(user).State = System.Data.Entity.EntityState.Modified;
            uow.Repository<User>().UpdateModel(model);
            uow.Save();
            return View();
        }


    }
}