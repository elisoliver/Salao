using Microsoft.AspNet.Identity;
using Salão.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;

namespace Salão.Controllers
{
    public class AdminController : Controller
    {
        private ApplicationDbContext db = new ApplicationDbContext();

        // GET: Admin
        public ActionResult Index()
        {
            var user = db.Users.Find(User.Identity.GetUserId());
            return View(db.AdminModels.ToList());
        }

        // GET: Admin/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            AdminModel adminModel = db.AdminModels.Find(id);
            if (adminModel == null)
            {
                return HttpNotFound();
            }

            return View(adminModel);
        }

        // GET: Admin/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Create
        [HttpPost]
        [ValidateAntiForgeryToken]

        public ActionResult Create([Bind(Include = "ID, Name, Email, Cel, Function")] AdminModel adminModel)
        {
            if (ModelState.IsValid)
            {

                MembershipHandler membership = new MembershipHandler();
                var user = new ApplicationUser { UserName = adminModel.Name, Email = adminModel.Email };

                membership.CreateUser(user, Request.Form["pass"]);

                adminModel.User = db.Users.Find(user.Id);

                membership.SetRoleAdmin(user.Id);

                db.AdminModels.Add(adminModel);
                db.SaveChanges();

                return RedirectToAction("Index");
            }
            return View(adminModel);
        }

        // GET: Admin/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            AdminModel adminModel = db.AdminModels.Find(id);
            if (adminModel == null)
            {
                return HttpNotFound();
            }

            return View(adminModel);
        }

        // POST: Admin/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID, Name, Email, Cel, Function")] AdminModel adminModel)
        {
            if (ModelState.IsValid)
            {
                db.Entry(adminModel).State = EntityState.Modified;
                db.SaveChanges();

                return RedirectToAction("Index");
            }

            return View(adminModel);
        }

        // GET: Admin/Delete/5
        public ActionResult Delete(int? id)
        {

            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            AdminModel adminModel = db.AdminModels.Find(id);
            if (adminModel == null)
            {
                return HttpNotFound();
            }

            return View(adminModel);
        }

        // POST: Admin/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            AdminModel adminModel = db.AdminModels.Find(id);
            db.AdminModels.Remove(adminModel);
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
