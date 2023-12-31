﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using DatabaseLayer;

namespace JobPortalMVC.Controllers
{
    public class JobCategoryTablesController : Controller
    {
        private JobshuntDbEntities db = new JobshuntDbEntities();

        // GET: JobCategoryTables
        public ActionResult Index()
        {
            return View(db.JobCategoryTables.ToList());
        }

        

        // GET: JobCategoryTables/Create
        public ActionResult Create()
        {
            return View(new JobCategoryTable());
        }

        // POST: JobCategoryTables/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create( JobCategoryTable jobCategoryTable)
        {
            if (ModelState.IsValid)
            {
                db.JobCategoryTables.Add(jobCategoryTable);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(jobCategoryTable);
        }

        // GET: JobCategoryTables/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            JobCategoryTable jobCategoryTable = db.JobCategoryTables.Find(id);
            if (jobCategoryTable == null)
            {
                return HttpNotFound();
            }
            return View(jobCategoryTable);
        }

        // POST: JobCategoryTables/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "JobCategoryID,JobCategory,Description")] JobCategoryTable jobCategoryTable)
        {
            if (ModelState.IsValid)
            {
                db.Entry(jobCategoryTable).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(jobCategoryTable);
        }

        

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
