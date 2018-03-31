using Blood_Bank.Logics;
using DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Blood_Bank.Controllers
{
    public class DonateListController : Controller
    {
        private UnitOfWork uow = null;
        public DonateListController()
        {
            uow = new UnitOfWork();
        }
        public DonateListController(UnitOfWork _uow)
        {
            this.uow = _uow;
        }
        // GET: DonateList
        public ActionResult Index(int id)
        {
            var model=uow.Repository<DonateList>().GetList();
            return View(model);
        }

        public ActionResult Add()
        {
            return View();
       
        }
        [HttpPost]
        public ActionResult Add(DonateList model)
        {
            string UserName = Session["UserName"].ToString();
            User user = uow.Repository<User>().GetModel(x => x.UserName == UserName);
            model.UserId = user.Id;
            uow.Repository<DonateList>().InsertModel(model);
            uow.Save();
            return RedirectToAction("Index", "DonateList", new { id = user.Id });
        }

    }
}