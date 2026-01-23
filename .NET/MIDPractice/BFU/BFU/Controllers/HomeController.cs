using BFU.DataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.UI.WebControls;

namespace BFU.Controllers
{
    public class HomeController : Controller
    {
        // Database 
        BFUEntities db = new BFUEntities();
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        [HttpGet,]
        public ActionResult Registration()
        {
            ViewBag.Departments = db.Departments.ToList();
            return View(new Student());
        }

        [HttpPost]
        public ActionResult Registration(Student student)
        {
            db.Students.Add(student);
            db.SaveChanges();

            TempData["msg"] = "Student Registered Successfully!";
            return RedirectToAction("List");
        }

        [HttpGet]
        public ActionResult List()
        {
            ViewBag.Students = db.Students.ToList();
            return View();
        }
        public ActionResult List(string search_box)
        {
            if (search_box != null)
            {
                var filter = (from filtered_student in db.Students
                              where filtered_student.Name.Contains(search_box)
                              select filtered_student).ToList();

                ViewBag.Students(filter);

                return View(new Student());
            }

            var student = db.Students.ToList();
            ViewBag.Students(student);
            return View(student);

        }

        [HttpGet]
        public ActionResult Details(int id)
        {
            var data = db.Students.Find(id); // Searching the student by id

            return View(data);
        }

        [HttpGet]
        public ActionResult Update(int id)
        {
            ViewBag.Departments = db.Departments.ToList();
            var data = db.Students.Find(id); // Searching the student by id
            return View(data);
        }

        [HttpPost]
        public ActionResult Update(Student student)
        {
            var dbObj = db.Students.Find(student.ID);
            dbObj.ID = student.ID;

            db.Entry(dbObj).CurrentValues.SetValues(student);
            db.SaveChanges();
            return RedirectToAction("List");
        }

        [HttpGet]
        public ActionResult Delete(int id)
        {
            var student = db.Students.Find(id); // Searching the student by id
            return View(student);

        }
        [HttpPost]
        public ActionResult Delete(Student student, string yes)
        {
            if (yes != null)
            {
                var dbObj = db.Students.Find(student.ID);
                db.Students.Remove(dbObj);
                db.SaveChanges();
            }
            
            return RedirectToAction("List");
        }

    }
}