using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using CardonCodingExercise.Models;
using System.Globalization;

namespace CardonCodingExercise.Controllers
{
    public class CandidatesController : Controller
    {
        private CandidateDBContext db = new CandidateDBContext();

        // GET: Candidates
        public ActionResult Index(string searchString,string qualTypes)
        {
            var candidates = from s in db.Candidates
                           select s;

            //For the Search dropbox
            var qualList = new List<string>();
            qualList.Add("College Degree");
            qualList.Add("Professional Certification");
            qualList.Add("Work Experience");
            ViewBag.qualTypes = new SelectList(qualList);


            DateTime dateValue;
            DateTime? dateSearch= null;
            //DateTime Search variable
            if (DateTime.TryParse(searchString, out dateValue))
            {
                dateSearch = DateTime.Parse(searchString,
                     System.Globalization.CultureInfo.InvariantCulture);
            }
            
            //User input search
            if (!String.IsNullOrEmpty(searchString))
            {

                var query2 = from c in db.Candidates
                             join q in db.Qualifications on c.ID equals q.CandidateID
                             where q.QualificationName == searchString || c.FirstName == searchString || c.LastName == searchString || c.Email == searchString ||
                             c.PhoneNumber == searchString || c.ZipCode == searchString || dateSearch >=q.DateStarted && dateSearch <= q.DateCompleted
                             select c;
               
                candidates = query2.Distinct();
            }
                        
            //Search with qualification type dropbox
            if (!string.IsNullOrEmpty(qualTypes))
            {
                var query = from c in db.Candidates
                            join q in db.Qualifications on c.ID equals q.CandidateID
                            where q.Type == qualTypes
                            select c;
                candidates = query.Distinct();
            }
            
            //Search with qualification type dropbox and user input search
            if (!string.IsNullOrEmpty(qualTypes) && !String.IsNullOrEmpty(searchString))
            {
                var test = from c in candidates
                           join q in db.Qualifications on c.ID equals q.CandidateID
                           where q.QualificationName == searchString || c.FirstName == searchString || c.LastName == searchString || c.Email == searchString ||
                            c.PhoneNumber == searchString || c.ZipCode == searchString || dateSearch >= q.DateStarted && dateSearch <= q.DateCompleted
                           select c;

                candidates = test.Distinct();       
            }     
            return View(candidates.ToList());
        }

        // GET: Candidates/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Candidate candidate = db.Candidates.Find(id);
            if (candidate == null)
            {
                return HttpNotFound();
            }
            return View(candidate);
        }

        // GET: Candidates/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Candidates/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,FirstName,LastName,Email,PhoneNumber,ZipCode")] Candidate candidate)
        {
            if (ModelState.IsValid)
            {
                db.Candidates.Add(candidate);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            return View(candidate);
        }

        // GET: Candidates/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Candidate candidate = db.Candidates.Find(id);
            if (candidate == null)
            {
                return HttpNotFound();
            }
            return View(candidate);
        }

        // POST: Candidates/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,FirstName,LastName,Email,PhoneNumber,ZipCode")] Candidate candidate)
        {
            if (ModelState.IsValid)
            {
                db.Entry(candidate).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View(candidate);
        }

        // GET: Candidates/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Candidate candidate = db.Candidates.Find(id);
            if (candidate == null)
            {
                return HttpNotFound();
            }
            return View(candidate);
        }

        // POST: Candidates/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Candidate candidate = db.Candidates.Find(id);
            db.Candidates.Remove(candidate);
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
