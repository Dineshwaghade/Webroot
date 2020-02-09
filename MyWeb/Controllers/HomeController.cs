using MyWeb.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyWeb.Controllers
{
    public class HomeController : Controller
    {
        DataContext db = new DataContext();
        // GET: Home
        public ActionResult Index()
        {
            var data=db.Users.ToList();
            return View(data);
        }

        // GET: Home/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Home/Create
        public ActionResult Create()
        {
            
            return View();
        }

        // POST: Home/Create
        [HttpPost]
        public ActionResult Create(User usr)
        {
            try
            {
                // TODO: Add insert logic here
                db.Users.Add(usr);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Home/Edit/5
        public ActionResult Edit(int id)
        {
            var data = db.Users.SqlQuery("select * from Users where User_id=@p0", id).SingleOrDefault();
            return View(data);
        }

        // POST: Home/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, User usr)
        {
            try
            {
                // TODO: Add update logic here
                var data = db.Users.Where(x => x.User_id == id).FirstOrDefault() ;
                db.Entry(data).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Home/Delete/5
        public ActionResult Delete(int id)
        {
            var data = db.Users.SqlQuery("select * from Users where User_id=@p0", id).SingleOrDefault();
            return View(data);
        }

        // POST: Home/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, User usr)
        {
            try
            {
                // TODO: Add delete logic here
                var data = db.Users.Where(x => x.User_id == id).FirstOrDefault();
                if (data != null)
                {
                    db.Entry(data).State = EntityState.Deleted;
                    db.SaveChanges();
                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
        public ActionResult Detail(int id)
        {
            var data = db.Users.SqlQuery("select * from Users where User_id=@p0", id).SingleOrDefault();
            return View(data);
        }
    }
}
