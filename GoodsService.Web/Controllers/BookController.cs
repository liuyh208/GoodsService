using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using GasWebMap.Core;
using GasWebMap.Domain;
using GasWebMap.Services.Dtos;

namespace GasWebMap.Web.Controllers
{
    public class BookController : Controller
    {
        //
        // GET: /Book/

        public ActionResult Index()
        {
            return View();
        }

        //
        // GET: /Book/Details/5

        public ActionResult Details(int id)
        {
            

            return View();
        }

        //
        // GET: /Book/Create

        public ActionResult Create()
        {
            return View();
        }

        //
        // POST: /Book/Create

        [System.Web.Mvc.HttpPost]
        public ActionResult Create([FromUri]BookMarkDto dto)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Book/Edit/5

        public ActionResult Edit(int id)
        {
            return View();
        }

        //
        // POST: /Book/Edit/5

        [System.Web.Mvc.HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        //
        // GET: /Book/Delete/5

        [System.Web.Mvc.HttpDelete]
        public ActionResult Delete(params Guid[] ids)
        {
            return new JsonResult();
        }

        //
        // POST: /Book/Delete/5

        [System.Web.Mvc.HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
