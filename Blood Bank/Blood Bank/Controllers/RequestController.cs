using Blood_Bank.Logics;
using DataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using PagedList;
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
        public ActionResult AllRequests(string Search,int? page)
        {
            //string UserName = Session["UserName"].ToString();
            //User user = uow.Repository<User>().GetModel(x => x.UserName == UserName);
            if(Search==null)
            {
                var model = uow.Repository<Request>().GetList();
                var obj = model.ToList().ToPagedList(page ?? 1, 2);
                return View(obj);
            }
            else
            {
                var model = uow.Repository<Request>().GetList(x=>x.Blood==Search);
                var obj = model.ToList().ToPagedList(page ?? 1, 2);
                return View(obj);
            }

            
        }

        public ActionResult MyRequests(int? id, int? page)
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