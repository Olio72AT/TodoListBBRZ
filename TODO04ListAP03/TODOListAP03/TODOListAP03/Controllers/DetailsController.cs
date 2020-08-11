﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TODOListAP03.Models;
using TODOListAP03.Controllers;

namespace TODOListAP03.Controllers
{
    public class DetailsController : Controller
    {
        public static List<Details> DetailsListe = new List<Details>();

        // GET: Details
        public ActionResult Index()
        {
            //  V5-Cookies-Sessions-Authorization
            TODOListAP03.MvcApplication.CallCookieOnce();

            return View(DetailsListe);
        }

        // GET: Details/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Details/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Details/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
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

        // GET: Details/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Details/Edit/5
        [HttpPost]
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

        // GET: Details/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Details/Delete/5
        [HttpPost]
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
