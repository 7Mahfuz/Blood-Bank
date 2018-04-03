using Blood_Bank.Logics;
using DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Blood_Bank.Controllers
{
    public class HomeController : Controller
    {
        private UnitOfWork uow = null;
        public HomeController()
        {
            uow = new UnitOfWork();
        }
        public HomeController(UnitOfWork _uow)
        {
            this.uow = _uow;
        }
        public ActionResult Index()
        {
            int user = uow.Repository<User>().Count();
            ViewBag.Users = user;

            int requests = uow.Repository<Request>().Count();
            ViewBag.Requests = requests;

            int donated = uow.Repository<DonateList>().Count();
            ViewBag.Donated = donated;

            int got = uow.Repository<Request>().Count(x=>x.GotBlood=="YES");
            ViewBag.Got = got;

            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}