using Blood_Bank.Logics;
using DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Blood_Bank.Controllers
{
    public class RequestController : Controller
    {
        private UnitOfWork uow = null;
        public RequestController()
        {
            uow = new UnitOfWork();
        }
        public RequestController(UnitOfWork _uow)
        {
            this.uow = _uow;
        }
        // GET: Request
        public ActionResult AllRequests()
        {
            //string UserName = Session["UserName"].ToString();
            //User user = uow.Repository<User>().GetModel(x => x.UserName == UserName);
            var model = uow.Repository<Request>().GetList();
            return View(model);
        }

        public ActionResult MyRequests(int? id)
        {
            string UserName = Session["UserName"].ToString();
            User user = uow.Repository<User>().GetModel(x => x.UserName == UserName);
            if(id==null)
            {
                var model = uow.Repository<Request>().GetList(x => x.UserId == user.Id);
                return View(model);
            }
            else
            {
                var model = uow.Repository<Request>().GetList(x => x.UserId == id);
                return View(model);
            }
            
            
        }
        public ActionResult Add()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Add(Request model)
        {
            string UserName = Session["UserName"].ToString();
            User user = uow.Repository<User>().GetModel(x => x.UserName == UserName);

            model.UserId = user.Id;
            model.PostDate = DateTime.Today;
            uow.Repository<Request>().InsertModel(model);
            uow.Save();

            return RedirectToAction("MyRequests", new { user.Id });
        }


        public ActionResult Edit(int id)
        {
            var model = uow.Repository<Request>().GetModelById(id);
            return View(model);
        }
        [HttpPost]
        public ActionResult Edit(Request model)
        {
            string UserName = Session["UserName"].ToString();
            User user = uow.Repository<User>().GetModel(x => x.UserName == UserName);
            model.UserId = user.Id;
            model.PostDate = DateTime.Today;
            uow.Repository<Request>().UpdateModel(model);
            uow.Save();
            return RedirectToAction("MyRequests", new { user.Id});
        }


        public ActionResult Delete(int id)
        {
            var model = uow.Repository<Request>().GetModelById(id);
            return View(model);
        }
        [HttpPost]
        public ActionResult Delete(Request model)
        {
            string UserName = Session["UserName"].ToString();
            User user = uow.Repository<User>().GetModel(x => x.UserName == UserName);
            uow.Repository<Request>().DeleteModel(model);
            uow.Save();
            return RedirectToAction("MyRequests", new { user.Id });
        }
    }
}