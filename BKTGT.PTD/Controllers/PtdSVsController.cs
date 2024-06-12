using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using BKTGT.PTD.Models;

namespace BKTGT.PTD.Controllers
{
    public class PtdSVsController : Controller
    {
        private PtdK22CNT3Lesson7Entities db = new PtdK22CNT3Lesson7Entities();

        // GET: PtdSVs
        public ActionResult PtdIndex()
        {
            var ptdSV = db.PtdSV.Include(p => p.PtdKhoa);
            return View(ptdSV.ToList());
        }

        // GET: PtdSVs/Details/5
        public ActionResult PtdDetails(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PtdSV ptdSV = db.PtdSV.Find(id);
            if (ptdSV == null)
            {
                return HttpNotFound();
            }
            return View(ptdSV);
        }

        // GET: PtdSVs/Create
        public ActionResult PTdCreate()
        {
            ViewBag.PtdMaKH = new SelectList(db.PtdKhoa, "PtdMaKH", "PtdTenKh");
            return View();
        }

        // POST: PtdSVs/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult PTdCreate([Bind(Include = "PtdMaSV,PtdHoSV,PtdTenSV,PtdNgaySinh,PtdPhai,PtdPhone,Ptdmail,PtdMaKH")] PtdSV ptdSV)
        {
            if (ModelState.IsValid)
            {
                db.PtdSV.Add(ptdSV);
                db.SaveChanges();
                return RedirectToAction("PtdIndex");
            }

            ViewBag.PtdMaKH = new SelectList(db.PtdKhoa, "PtdMaKH", "PtdTenKh", ptdSV.PtdMaKH);
            return View(ptdSV);
        }

        // GET: PtdSVs/Edit/5
        public ActionResult PtdEdit(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PtdSV ptdSV = db.PtdSV.Find(id);
            if (ptdSV == null)
            {
                return HttpNotFound();
            }
            ViewBag.PtdMaKH = new SelectList(db.PtdKhoa, "PtdMaKH", "PtdTenKh", ptdSV.PtdMaKH);
            return View(ptdSV);
        }

        // POST: PtdSVs/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult PtdEdit([Bind(Include = "PtdMaSV,PtdHoSV,PtdTenSV,PtdNgaySinh,PtdPhai,PtdPhone,Ptdmail,PtdMaKH")] PtdSV ptdSV)
        {
            if (ModelState.IsValid)
            {
                db.Entry(ptdSV).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("PtdIndex");
            }
            ViewBag.PtdMaKH = new SelectList(db.PtdKhoa, "PtdMaKH", "PtdTenKh", ptdSV.PtdMaKH);
            return View(ptdSV);
        }

        // GET: PtdSVs/Delete/5
        public ActionResult PtdDelete(string id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            PtdSV ptdSV = db.PtdSV.Find(id);
            if (ptdSV == null)
            {
                return HttpNotFound();
            }
            return View(ptdSV);
        }

        // POST: PtdSVs/Delete/5
        [HttpPost, ActionName("PtdDelete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(string id)
        {
            PtdSV ptdSV = db.PtdSV.Find(id);
            db.PtdSV.Remove(ptdSV);
            db.SaveChanges();
            return RedirectToAction("PtdIndex");
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
