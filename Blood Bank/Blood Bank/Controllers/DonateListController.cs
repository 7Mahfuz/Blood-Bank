﻿using Blood_Bank.Logics;
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
            string UserName = Session["UserName"].ToString();
            User user = uow.Repository<User>().GetModel(x => x.UserName == UserName);
            if(user.Id==id)
            { ViewBag.Same = "Yes"; }
            else { ViewBag.Same = "No"; }

            var model=uow.Repository<DonateList>().GetList(x=>x.UserId==id);
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

        public ActionResult Edit(int id)
        {
            DonateList model = uow.Repository<DonateList>().GetModelById(id);
            return View(model);
        }
        [HttpPost]
        public ActionResult Edit(int id,DonateList model)
        {
            uow.Repository<DonateList>().UpdateModel(model);
            uow.Save();
            return RedirectToAction("Index", "DonateList", new { id = model.id });
        }

        public ActionResult Delete(int id)
        {
            DonateList model = uow.Repository<DonateList>().GetModelById(id);
            return View(model);
        }
        [HttpPost]
        public ActionResult Delete(int id,DonateList model)
        {
            uow.Repository<DonateList>().DeleteModel(model);
            uow.Save();
            return RedirectToAction("Index", "DonateList", new { id = model.id });
        }
    }
}