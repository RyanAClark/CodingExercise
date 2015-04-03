using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CardonCodingExercise.Models;

namespace CardonCodingExercise.Controllers
{
    public class QualificationsController : Controller
    {
        private CandidateDBContext db = new CandidateDBContext();

        // GET: Qualifications
        public ActionResult Index()
        {
           
           
            var qualifications = db.Qualifications.Include(q => q.Candidate);
            return View(qualifications.ToList());
        }

        // GET: Qualifications/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Qualification qualification = db.Qualifications.Find(id);
            if (qualification == null)
            {
                return HttpNotFound();
            }
            return View(qualification);
        }

        // GET: Qualifications/Create
        public ActionResult Create(string qualTypes)
        {
            //View Data to for Qualification Type DropBox
            List<SelectListItem> li = new List<SelectListItem>();
            li.Add(new SelectListItem { Text = "College Degree", Value = "College Degree" });
            li.Add(new SelectListItem { Text = "Professional Certification", Value = "Professional Certification" });
            li.Add(new SelectListItem { Text = "Work Experience", Value = "Work Experience" });
            ViewData["qual"] = li;

            
            ViewBag.CandidateID = new SelectList(db.Candidates, "ID", "FirstName");
            return View();
        }

        // POST: Qualifications/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "QualificationID,CandidateID,Type,QualificationName,DateStarted,DateCompleted")] Qualification qualification)
        {
            if (ModelState.IsValid)
            {
                db.Qualifications.Add(qualification);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.CandidateID = new SelectList(db.Candidates, "ID", "FirstName", qualification.CandidateID);
            return View(qualification);
        }

        // GET: Qualifications/Edit/5
        public ActionResult Edit(int? id)
        {
            //View Data to for Qualification Type DropBox
            List<SelectListItem> li = new List<SelectListItem>();
            li.Add(new SelectListItem { Text = "College Degree", Value = "College Degree" });
            li.Add(new SelectListItem { Text = "Professional Certification", Value = "Professional Certification" });
            li.Add(new SelectListItem { Text = "Work Experience", Value = "Work Experience" });
            ViewData["qual"] = li;

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Qualification qualification = db.Qualifications.Find(id);
            if (qualification == null)
            {
                return HttpNotFound();
            }
            ViewBag.CandidateID = new SelectList(db.Candidates, "ID", "FirstName", qualification.CandidateID);
            return View(qualification);
        }

        // POST: Qualifications/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "QualificationID,CandidateID,Type,QualificationName,DateStarted,DateCompleted")] Qualification qualification)
        {
            if (ModelState.IsValid)
            {
                db.Entry(qualification).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            ViewBag.CandidateID = new SelectList(db.Candidates, "ID", "FirstName", qualification.CandidateID);
            return View(qualification);
        }

        // GET: Qualifications/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Qualification qualification = db.Qualifications.Find(id);
            if (qualification == null)
            {
                return HttpNotFound();
            }
            return View(qualification);
        }

        // POST: Qualifications/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Qualification qualification = db.Qualifications.Find(id);
            db.Qualifications.Remove(qualification);
            db.SaveChanges();
            return RedirectToAction("Index");
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
