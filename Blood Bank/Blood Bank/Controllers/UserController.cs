
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
        public ActionResult Index()
        {
            uow.Repository<User>().GetList();
            return View();
        }

        public ActionResult Register()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Register(User model)
        {
            //try
            //{
                uow.Repository<User>().InsertModel(model);
                uow.Save();
                return View();
            //}
            //catch
            //{
            //    return View();
            //}
        }


    }
}